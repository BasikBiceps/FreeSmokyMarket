using System.IO;
using System.Collections.Generic;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

using FreeSmokyMarket.Infrastructure.Logging;
using FreeSmokyMarket.Data.Repositories;
using FreeSmokyMarket.EF;
using FreeSmokyMarket.Data.Entities;
using FreeSmokyMarket.Data.Entities.Aggregates;

namespace FreeSmokyMarket.Controllers
{
    public class ProductsController : Controller
    {
        FreeSmokyMarketContext _ctx;
        ILogger _logger;
        IProductRepository _productRepository;
        IBrandRepository _brandRepository;
        
        public ProductsController(FreeSmokyMarketContext ctx,
                                  ILoggerFactory loggerFactory,
                                  IProductRepository productRepository,
                                  IBrandRepository brandRepository)
        {
            _ctx = ctx;
            _productRepository = productRepository;
            _brandRepository = brandRepository;

            loggerFactory.AddFile(Path.Combine(Directory.GetCurrentDirectory(), "HomeControllerLogs.txt"));
            _logger = loggerFactory.CreateLogger("FileLogger");
        }

        public IActionResult ShowProducts(int id)
        {
            HttpContext.Session.Set("BrandId", id);

            _logger.LogInformation("ShowProducts method in Home controller: ID == {0}", id);

            return View(_productRepository.GetAllProducts(id));
        }

        public IActionResult ProductDescription(int id)
        {
            _logger.LogInformation("ProductDescription method in Home controller: ID == {0}", id);

            ViewData["BrandName"] = _brandRepository.GetBrand(_productRepository.GetProduct(id).BrandId).BrandName;

            return View(_productRepository.GetProduct(id));
        }

        public IActionResult Reserve(int id)
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
                        return Redirect("/Products/ShowProducts/" + HttpContext.Session.Get<int>("BrandId"));
                    }

                    item.Amount++;

                    HttpContext.Session.Set("SelectedProducts", purchasesItems);

                    return Redirect("/Products/ShowProducts/" + HttpContext.Session.Get<int>("BrandId"));
                }
            }
            var newPurchasesItem = new PurchasesItem();
            newPurchasesItem.ProductId = id;
            newPurchasesItem.Amount = 1;

            purchasesItems.Add(newPurchasesItem);

            HttpContext.Session.Set("SelectedProducts", purchasesItems);

            return Redirect("/Products/ShowProducts/" + HttpContext.Session.Get<int>("BrandId"));
        }
    }
}