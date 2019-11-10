using System.IO;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using FreeSmokyMarket.Logging;
using FreeSmokyMarket.Data.Repositories;
using FreeSmokyMarket.Data.Entities;

namespace FreeSmokyMarket.Controllers
{
    public class BasketController : Controller
    {
        ILogger _logger;
        IProductRepository _productRepository;

        public BasketController(ILoggerFactory loggerFactory,
                                IProductRepository productRepository)
        {
            _productRepository = productRepository;

            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "HomeControllerLogs.txt"));
            _logger = loggerFactory.CreateLogger("FileLogger");
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