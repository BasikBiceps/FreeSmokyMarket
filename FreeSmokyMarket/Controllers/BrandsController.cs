using Microsoft.AspNetCore.Mvc;

using FreeSmokyMarket.Data.Repositories;

namespace FreeSmokyMarket.Controllers
{
    public class BrandsController : Controller
    {
        IBrandRepository _brandRepository;

        public BrandsController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public IActionResult ShowBrands(int id)
        {
            return View(_brandRepository.GetAllBrands(id));
        }
    }
}