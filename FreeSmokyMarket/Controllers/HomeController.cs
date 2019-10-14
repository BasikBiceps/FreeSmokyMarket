using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FreeSmokyMarket.Models;

using Microsoft.Extensions.Logging;
using FreeSmokyMarket.Logging;
using System.IO;

using Microsoft.EntityFrameworkCore;


namespace SmokyMarket.Controllers
{
    public class HomeController : Controller
    {
        FreeSmokyMarketContext _ctx;
        ILogger _logger;

        public HomeController(FreeSmokyMarketContext ctx, ILoggerFactory loggerFactory)
        {
            _ctx = ctx;

            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "HomeControllerLogs.txt"));
            _logger = loggerFactory.CreateLogger("FileLogger");
        }
        public IActionResult Index()
        {
            var test = _ctx.Products;
            var test2 = _ctx.Brands;
            var test3 = _ctx.Tobaccos;

            test.First().Brands = test2.ToList();
            test.First().Brands.First().Tobaccos = test3.ToList();


            return View(test);
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
            _logger.LogInformation("Orders fields: \nFirstName: {0}\nLastName: {0}\nPhoneNumber: {0}\nTobaccoId: {0}", 
                order.FirstName, 
                order.LastName, 
                order.PhoneNumber, 
                order.TabaccoId);

            _ctx.Orders.Add(order);
            _ctx.SaveChanges();
            return "Спасибо, " + order.FirstName + " " + order.LastName + ", за покупку!";
        }
    }
}
