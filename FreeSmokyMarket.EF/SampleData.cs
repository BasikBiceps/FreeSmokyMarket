using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeSmokyMarket.Data;
using FreeSmokyMarket.Data.Entities;

namespace FreeSmokyMarket.EF
{
    public static class SampleData
    {
        public static void Initialize(FreeSmokyMarketContext ctx)
        {
            if (ctx.Categories.Any()) return;
            var category1 = new Category { CategoryName = "Tobaccos" };

            var brand1 = new Brand
            {
                Category = category1,
                BrandName = "Fumari",
                Products = new List<Product>()
            };

            var tobacco = new Product
            {
                Brand = brand1,
                Amount = 10,
                Description = "Strength: light;\nTaste: blackBerry;",
                Price = 500
            };
            brand1.Products.Add(tobacco);

            ctx.Categories.Add(category1);
            ctx.Brands.Add(brand1);
            ctx.Products.Add(tobacco);

            var category2 = new Category { CategoryName = "Coals" };
            var category3 = new Category { CategoryName = "Hookahs" };

            ctx.Categories.Add(category2);
            ctx.Categories.Add(category3);

            ctx.SaveChanges();
        }
    }
}