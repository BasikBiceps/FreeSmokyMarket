using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeSmokyMarket.Models;

namespace FreeSmokyMarket
{
    public static class SampleData
    {
        public static void Initialize(FreeSmokyMarketContext ctx)
        {
            if (!ctx.Products.Any())
            {
                var product = new Product {ProductName = "Tobacco"};
                var brand = new Brand
                {
                    Product = product,
                    BrandName = "Fumari",
                    Tobaccos = new List<Tobacco>()
                };
                var tobacco = new Tobacco
                {
                    Brand = brand,
                    Amount = 10,
                    Description = "zalupka",
                    TobaccoStrength = TobaccoStrength.Light,
                    Price = 500,
                    Taste = "Blackberry"
                };
                brand.Tobaccos.Add(tobacco);

                ctx.Tobaccos.Add(tobacco);
                ctx.Brands.Add(brand);
                ctx.Products.Add(product);
               

                ctx.SaveChanges();
            }
        }
    }
}
