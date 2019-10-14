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
            return View(_ctx.Products.ToList());
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
                order.PhoneNumber);

            _ctx.Orders.Add(order);
            _ctx.SaveChanges();
            return "Спасибо, " + order.FirstName + " " + order.LastName + ", за покупку!";
        }
    }
}
