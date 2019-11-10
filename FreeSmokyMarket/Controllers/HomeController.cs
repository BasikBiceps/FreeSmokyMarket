using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using Microsoft.Extensions.Logging;
using FreeSmokyMarket.Logging;
using FreeSmokyMarket.Data.Repositories;
using FreeSmokyMarket.Data.Entities;
using FreeSmokyMarket.EF;
using FreeSmokyMarket.EF.Repositories;

using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace FreeSmokyMarket.Controllers
{
    public class HomeController : Controller
    {
        FreeSmokyMarketContext _ctx;
        ILogger _logger;
        IProductRepository _productRepository;
        IBrandRepository _brandRepository;
        IOrderRepository _orderRepository;
        ICategoryRepository _categoryRepository;


        public HomeController(FreeSmokyMarketContext ctx, 
            ILoggerFactory loggerFactory, 
            IProductRepository productRepository, 
            IBrandRepository brandRepository, 
            IOrderRepository orderRepository, 
            ICategoryRepository categoryRepository)
        {
            _ctx = ctx;
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _orderRepository = orderRepository;
            _categoryRepository = categoryRepository;

            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "HomeControllerLogs.txt"));
            _logger = loggerFactory.CreateLogger("FileLogger");
        }

        public IActionResult MainPage()
        {
            Infrastructure.MailSender.MailSender.SendEmailAsync("freesmokymarket@gmail.com", "smokyphilip", "nokem.noks@gmail.com", "Test");
            return View(_ctx.Categories.ToList());
        }

        public IActionResult ShowBrands(int id)
        {
            _logger.LogInformation("ShowBrands method in Home controller: ID == {0}", id);

            return View(_brandRepository.GetAllBrands(id));
        }

        public IActionResult ShowProducts(int id)
        {
            _logger.LogInformation("ShowProducts method in Home controller: ID == {0}", id);

            return View(_productRepository.GetAllProducts(id));
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

        public IActionResult Buy()
        {
            return View();
        }
        
    }
}
