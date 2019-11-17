using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FreeSmokyMarket.Data.Repositories;
using FreeSmokyMarket.EF;

namespace FreeSmokyMarket.Controllers
{
    public class ProductsController : Controller
    {
        FreeSmokyMarketContext _ctx;
        IProductRepository _productRepository;
        
        public ProductsController(FreeSmokyMarketContext ctx,
                                  IProductRepository productRepository)
        {
            _ctx = ctx;
            _productRepository = productRepository;
        }

        public IActionResult ShowProducts(int id)
        {
            return View(_productRepository.GetAllProducts(id));
        }

        public IActionResult ProductDescription(int id)
        {
            return View(_productRepository.GetProduct(id));
        }

        public string Reserve(int id)
        {
            var selectedProducts = HttpContext.Session.Get<List<int>>("SelectedProducts");

            if (selectedProducts == null)
            {
                selectedProducts = new List<int>();
            }

            selectedProducts.Add(id);

            HttpContext.Session.Set("SelectedProducts", selectedProducts);

            return "Product added to the basket";
        }
    }
}