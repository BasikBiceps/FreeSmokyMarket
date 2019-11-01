using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Logging;
using FreeSmokyMarket.Logging;
using FreeSmokyMarket.Data.Repositories;
using FreeSmokyMarket.Data.Entities;
using FreeSmokyMarket.EF;
using FreeSmokyMarket.EF.Repositories;

namespace SmokyMarket.Controllers
{
    public class HomeController : Controller
    {
        FreeSmokyMarketContext _ctx;
        ILogger _logger;
        IProductRepository _productRepository;
        IBrandRepository _brandRepository;
        IOrderRepository _orderRepository;
        ICategoryRepository _categoryRepository;


        public HomeController(FreeSmokyMarketContext ctx, 
            ILoggerFactory loggerFactory, 
            IProductRepository productRepository, 
            IBrandRepository brandRepository, 
            IOrderRepository orderRepository, 
            ICategoryRepository categoryRepository)
        {
            _ctx = ctx;
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _orderRepository = orderRepository;
            _categoryRepository = categoryRepository;

            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "HomeControllerLogs.txt"));
            _logger = loggerFactory.CreateLogger("FileLogger");
        }

        public IActionResult MainPage()
        {
            return View(_ctx.Categories.ToList());
        }

        [HttpGet]
        public IActionResult Buy(int id)
        {
            _logger.LogInformation("Buy method in Home controller: ID == {0}", id);

            ViewBag.TabaccoId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Order order)
        {
            _logger.LogInformation("Orders fields: \nFirstName: {0}\nLastName: {0}\nPhoneNumber: {0}\nAddress: {0}", 
                order.FirstName, 
                order.LastName, 
                order.PhoneNumber,
                order.Address);

            _ctx.Orders.Add(order);
            _ctx.SaveChanges();
            return "Спасибо, " + order.FirstName + " " + order.LastName + ", за покупку!";
        }
    }
}
