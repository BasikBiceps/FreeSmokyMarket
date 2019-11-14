using System.IO;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

using FreeSmokyMarket.Infrastructure.Logging;
using FreeSmokyMarket.Data.Repositories;
using FreeSmokyMarket.EF;
using FreeSmokyMarket.Data.Entities;

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
            var purchasesItems = HttpContext.Session.Get<List<PurchasesItem>>("SelectedProducts");
            if (purchasesItems == null)
            {
                purchasesItems = new List<PurchasesItem>();
            }
            else
            {
                var item = purchasesItems.Find(p => { return p.ProductId == id; });

                if (item != null)
                {
                    if (_productRepository.GetProduct(id).Amount <= item.Amount)
                    {
                        return "Sorry, but this product limited!";
                    }

                    item.Amount++;

                    HttpContext.Session.Set("SelectedProducts", purchasesItems);

                    return "Product added to the basket";
                }
            }

            var newPurchasesItem = new PurchasesItem();
            newPurchasesItem.ProductId = id;
            newPurchasesItem.Amount = 1;

            purchasesItems.Add(newPurchasesItem);

            HttpContext.Session.Set("SelectedProducts", purchasesItems);

            return "Product added to the basket";
        }
    }
}