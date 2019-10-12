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
            return View(_ctx.Tabaccos.ToList());
        }
    }
}