using System.IO;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

using FreeSmokyMarket.Logging;
using FreeSmokyMarket.Data.Repositories;
using FreeSmokyMarket.EF;

namespace FreeSmokyMarket.Controllers
{
    public class ProductsController : Controller
    {
        FreeSmokyMarketContext _ctx;
        ILogger _logger;
        IProductRepository _productRepository;
        
        public ProductsController(FreeSmokyMarketContext ctx,
                                  ILoggerFactory loggerFactory,
                                  IProductRepository productRepository)
        {
            _ctx = ctx;
            _productRepository = productRepository;

            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "HomeControllerLogs.txt"));
            _logger = loggerFactory.CreateLogger("FileLogger");
        }

        public IActionResult ShowProducts(int id)
        {
            _logger.LogInformation("ShowProducts method in Home controller: ID == {0}", id);

            return View(_productRepository.GetAllProducts(id));
        }

        public IActionResult ProductDescription(int id)
        {
            _logger.LogInformation("ProductDescription method in Home controller: ID == {0}", id);

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