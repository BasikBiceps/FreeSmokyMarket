using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using FreeSmokyMarket.Data;
using FreeSmokyMarket.Data.Entities;

namespace FreeSmokyMarket
{
    public static class SampleData
    {
        public static void Initialize(FreeSmokyMarketContext ctx)
        {
            if (!ctx.Products.Any())
            {
                var product1 = new Product { ProductName = "Tobaccos" };

                var brand1 = new Brand
                {
                    Product = product1,
                    BrandName = "Fumari",
                    Tobaccos = new List<Tobacco>()
                };

                var tobacco = new Tobacco
                {
                    Brand = brand1,
                    Amount = 10,
                    Description = "Sanya pidr)",
                    TobaccoStrength = TobaccoStrength.Light,
                    Price = 500,
                    Taste = "Blackberry"
                };
                brand1.Tobaccos.Add(tobacco);

                ctx.Products.Add(product1);
                ctx.Brands.Add(brand1);
                ctx.Tobaccos.Add(tobacco);

                var product2 = new Product { ProductName = "Coals" };
                var product3 = new Product { ProductName = "Hookahs" };

                ctx.Products.Add(product2);
                ctx.Products.Add(product3);

                ctx.SaveChanges();
            }
        }
    }
}
