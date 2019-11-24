using Microsoft.AspNetCore.Mvc;

using FreeSmokyMarket.Data.Repositories;

namespace FreeSmokyMarket.Controllers
{
    public class HomeController : Controller
    {
        private ICategoryRepository _categoryRepository;

        public HomeController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public  IActionResult About()
        {
            return View();
        }

        public IActionResult MainPage()
        {
            return View(_categoryRepository.GetAllCategories());
        }
    }
}