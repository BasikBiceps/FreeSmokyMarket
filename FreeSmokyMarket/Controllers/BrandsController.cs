using System.IO;
using Microsoft.AspNetCore.Mvc;
using FreeSmokyMarket.Data.Repositories;
using FreeSmokyMarket.EF;

namespace FreeSmokyMarket.Controllers
{
    public class BrandsController : Controller
    {
        FreeSmokyMarketContext _ctx;
        IBrandRepository _brandRepository;

        public BrandsController(FreeSmokyMarketContext ctx,
                                IBrandRepository brandRepository)
        {
            _ctx = ctx;
            _brandRepository = brandRepository;
        }
        public IActionResult ShowBrands(int id)
        {
            return View(_brandRepository.GetAllBrands(id));
        }
    }
}