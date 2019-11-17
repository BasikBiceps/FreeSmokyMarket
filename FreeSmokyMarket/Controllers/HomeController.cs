using System.Linq;

using Microsoft.AspNetCore.Mvc;

using FreeSmokyMarket.EF;

namespace FreeSmokyMarket.Controllers
{
    public class HomeController : Controller
    {
        private FreeSmokyMarketContext _ctx;

        public HomeController(FreeSmokyMarketContext ctx)
        {
            _ctx = ctx;
        }

        public  IActionResult About()
        {
            return View();
        }

        public IActionResult MainPage()
        {
            return View(_ctx.Categories.ToList());
        }
    }
}
