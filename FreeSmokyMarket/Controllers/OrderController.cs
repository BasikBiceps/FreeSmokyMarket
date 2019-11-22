using System;
using System.IO;
using System.Collections.Generic;
using System.Globalization;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc.RazorPages;

using FreeSmokyMarket.Infrastructure.Logging;
using FreeSmokyMarket.Data.Repositories;
using FreeSmokyMarket.Data.Entities;
using FreeSmokyMarket.EF;
using FreeSmokyMarket.Infrastructure.Interfaces;

namespace FreeSmokyMarket.Controllers
{
    public class OrderController : Controller
    {
        FreeSmokyMarketContext _ctx;
        ILogger _logger;
        IOrderRepository _orderRepository;
        ISenderFactory _senderFactory;
        IConfiguration _configuration;
        IProductRepository _productRepository;
        IBasketRepository _basketRepository;
        IPurchasesItemRepository _purchasesItemRepository;

        public OrderController(FreeSmokyMarketContext ctx,
                               ILoggerFactory loggerFactory,
                               IOrderRepository orderRepository,
                               IConfiguration configuration,
                               ISenderFactory senderFactory,
                               IProductRepository productRepository,
                               IBasketRepository basketRepository,
                               IPurchasesItemRepository purchasesItemRepository)
        {
            _ctx = ctx;
            _orderRepository = orderRepository;
            _senderFactory = senderFactory;
            _configuration = configuration;
            _productRepository = productRepository;
            _basketRepository = basketRepository;
            _purchasesItemRepository = purchasesItemRepository;

            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "HomeControllerLogs.txt"));
            _logger = loggerFactory.CreateLogger("FileLogger");
        }

        [HttpGet]
        public IActionResult Buy()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Buy(Order order)
        {
            if (!ModelState.IsValid)
                return View(new ViewModels.Order());

            var ctx = new FreeSmokyMarketContext();
            var message = "Orders fields: \nFirstName: "
                    + order.FirstName
                    + "\nLastName: "
                    + order.LastName
                    + "\nPhoneNumber:"
                    + order.PhoneNumber
                    + "\nAddress: "
                    + order.Address
                    + "\nOrderId: "
                    + order.Id;

            using (var transaction = ctx.Database.BeginTransaction())
            {
                var purchasesItems = HttpContext.Session.Get<List<PurchasesItem>>("SelectedProducts");
                var updatingProducts = new List<Product>();

                foreach (var el in purchasesItems)
                {
                    var product = _productRepository.GetProduct(el.ProductId);

                    if (product.Amount >= el.Amount)
                    {
                        product.Amount -= el.Amount;
                    }
                    else
                    {
                        transaction.Rollback();

                        return NotFound();
                    }

                    updatingProducts.Add(product);
                }

                foreach (var product in updatingProducts)
                {
                    _productRepository.UpdateProduct(product);
                }

                order.OrderDate = DateTime.Now;
                _orderRepository.CreateOrder(order);

                var basket = new Basket();
                basket.OrderId = _orderRepository.GetLastId();
                basket.SessionId = HttpContext.Session.Id;
                _basketRepository.CreateBasket(basket);

                foreach (var el in purchasesItems)
                {
                    el.BasketId = _basketRepository.GetLastId();
                    _purchasesItemRepository.CreatePurchasesItem(el);
                }
                transaction.Commit();
            }
            
            HttpContext.Session.Set("SelectedProducts", new List<PurchasesItem>());

            _logger.LogInformation(message);

            _senderFactory.CreateSender("mail")?.SendMessageAsync(message);
            _senderFactory.CreateSender("telegram")?.SendMessageAsync(message);

            return Content("Спасибо, " + order.FirstName + " " + order.LastName + ", за покупку!");
        }
    }
}