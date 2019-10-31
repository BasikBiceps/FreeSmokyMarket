using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FreeSmokyMarket.Data;
using FreeSmokyMarket.Data.Entities;
using System.Drawing;

namespace FreeSmokyMarket.EF
{
    public static class SampleData
    {
        public static void Initialize(FreeSmokyMarketContext ctx)
        {
            if (ctx.Categories.Any())
                return;

            var category1 = new Category { CategoryName = "Tobaccos" };

            Image category1Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "\\Images\\tobacco.jpg");
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            category1Image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            category1.CategoryPicture = memoryStream.ToArray();
            memoryStream.Dispose();

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

            Image category2Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "\\Images\\Coals.jpeg");
            System.IO.MemoryStream memoryStream2 = new System.IO.MemoryStream();
            category2Image.Save(memoryStream2, System.Drawing.Imaging.ImageFormat.Jpeg);
            category2.CategoryPicture = memoryStream2.ToArray();
            memoryStream2.Dispose();

            var category3 = new Category { CategoryName = "Hookahs" };

            Image category3Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "\\Images\\Hookahs.jpeg");
            System.IO.MemoryStream memoryStream3 = new System.IO.MemoryStream();
            category3Image.Save(memoryStream3, System.Drawing.Imaging.ImageFormat.Jpeg);
            category3.CategoryPicture = memoryStream3.ToArray();
            memoryStream3.Dispose();

            ctx.Categories.Add(category2);
            ctx.Categories.Add(category3);

            ctx.SaveChanges();
        }
    }
}