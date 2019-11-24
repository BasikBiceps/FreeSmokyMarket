using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using FreeSmokyMarket.Data.Repositories;
using FreeSmokyMarket.EF;
using FreeSmokyMarket.Domain.Interfaces;

namespace FreeSmokyMarket.Controllers
{
    public class ProductsController : Controller
    {
        IProductRepository _productRepository;
        IBrandRepository _brandRepository;
        IReservationService _reservationService;
        
        public ProductsController(FreeSmokyMarketContext ctx,
                                  IProductRepository productRepository,
                                  IBrandRepository brandRepository,
                                  IReservationService reservationService)
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _reservationService = reservationService;
        }

        public IActionResult ShowProducts(int id)
        {
            HttpContext.Session.Set("BrandId", id);

            return View(_productRepository.GetAllProducts(id));
        }

        public IActionResult ProductDescription(int id)
        {
            ViewData["BrandName"] = _brandRepository.GetBrand(_productRepository.GetProduct(id).BrandId).BrandName;

            return View(_productRepository.GetProduct(id));
        }

        public IActionResult Reserve(int id)
        {
            _reservationService.ReserveProduct(HttpContext.Session.Id, id);

            return Redirect("/Products/ShowProducts/" + HttpContext.Session.Get<int>("BrandId"));
        }
    }
}