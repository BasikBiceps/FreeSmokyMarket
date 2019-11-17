using System.IO;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FreeSmokyMarket.Data.Repositories;
using FreeSmokyMarket.Data.Entities;

namespace FreeSmokyMarket.Controllers
{
    public class BasketController : Controller
    {
        IProductRepository _productRepository;

        public BasketController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult ShowBasket()
        {
            var selectedProductsId = HttpContext.Session.Get<List<int>>("SelectedProducts");

            if (selectedProductsId == null)
            {
                selectedProductsId = new List<int>();
            }

            var selectedProducts = new List<Product>();

            foreach (var el in selectedProductsId)
            {
                selectedProducts.Add(_productRepository.GetProduct(el));
            }

            return View(selectedProducts);
        }
    }
}