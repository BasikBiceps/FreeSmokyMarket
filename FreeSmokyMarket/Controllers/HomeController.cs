﻿using System;
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


namespace SmokyMarket.Controllers
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
            if (!HttpContext.Session.Keys.Contains("SessionId"))
                HttpContext.Session.SetString("SessionId", HttpContext.Session.Id);

            ViewData["test"] = HttpContext.Session.Id;

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

        public IActionResult ProductDescription(int id)
        {
            _logger.LogInformation("ProductDescription method in Home controller: ID == {0}", id);

            return View(_productRepository.GetProduct(id));
        }

        [HttpPost]
        public string Buy(Order order)
        {
            _logger.LogInformation("Orders fields: \nFirstName: {0}\nLastName: {0}\nPhoneNumber: {0}\nAddress: {0}", 
                order.FirstName, 
                order.LastName, 
                order.PhoneNumber,
                order.Address);

            _ctx.Orders.Add(order);
            _ctx.SaveChanges();
            return "Спасибо, " + order.FirstName + " " + order.LastName + ", за покупку!";
        }
    }
}
