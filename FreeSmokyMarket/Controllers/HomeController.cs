using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FreeSmokyMarket.Models;

namespace SmokyMarket.Controllers
{
    public class HomeController : Controller
    {
        FreeSmokyMarketContext _ctx;

        public HomeController(FreeSmokyMarketContext ctx)
        {
            _ctx = ctx;
        }
        public IActionResult Index()
        {
            return View(_ctx.Tobaccos.ToList());
        }

        [HttpGet]
        public IActionResult Buy(int id)
        {
            ViewBag.TabaccoId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Order order)
        {
            _ctx.Orders.Add(order);
            _ctx.SaveChanges();
            return "Спасибо, " + order.FirstName + " " + order.LastName + ", за покупку!";
        }
    }
}