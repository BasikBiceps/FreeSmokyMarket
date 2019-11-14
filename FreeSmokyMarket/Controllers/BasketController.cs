using System.IO;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using FreeSmokyMarket.Data.Repositories;
using FreeSmokyMarket.Data.Entities;
using FreeSmokyMarket.Infrastructure.Logging;

namespace FreeSmokyMarket.Controllers
{
    public class BasketController : Controller
    {
        ILogger _logger;
        IProductRepository _productRepository;

        public BasketController(ILoggerFactory loggerFactory,
                                IProductRepository productRepository)
        {
            _productRepository = productRepository;

            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "HomeControllerLogs.txt"));
            _logger = loggerFactory.CreateLogger("FileLogger");
        }

        public IActionResult ShowBasket()
        {
            var purchasesItems = HttpContext.Session.Get<List<PurchasesItem>>("SelectedProducts");

            if (purchasesItems == null)
            {
                purchasesItems = new List<PurchasesItem>();
            }

            var selectedProducts = new List<Product>();

            foreach (var el in purchasesItems)
            {
                selectedProducts.Add(_productRepository.GetProduct(el.ProductId));
            }

            ViewData["PurchasesItems"] = purchasesItems;

            return View(selectedProducts);
        }

        public IActionResult DeleteFromBasket(int id)
        {
            var purchasesItems = HttpContext.Session.Get<List<PurchasesItem>>("SelectedProducts");

            var item = purchasesItems.Find(p => { return p.ProductId == id; });

            item.Amount--;

            if (item.Amount <= 0)
            {
                purchasesItems.Remove(item);
            }

            HttpContext.Session.Set("SelectedProducts", purchasesItems);

            return Redirect("/Basket/ShowBasket");
        }
    }
}