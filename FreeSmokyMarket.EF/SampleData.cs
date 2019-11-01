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

            Image brand1Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "\\Images\\fumari.jpg");
            System.IO.MemoryStream brand1ImageMemoryStream = new System.IO.MemoryStream();
            brand1Image.Save(brand1ImageMemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            brand1.BrandPicture = brand1ImageMemoryStream.ToArray();
            brand1ImageMemoryStream.Dispose();

            var brand2 = new Brand
            {
                Category = category1,
                BrandName = "Dark Side",
                Products = new List<Product>()
            };

            Image brand2Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "\\Images\\darkside.jpg");
            System.IO.MemoryStream brand2ImageMemoryStream = new System.IO.MemoryStream();
            brand2Image.Save(brand2ImageMemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            brand2.BrandPicture = brand2ImageMemoryStream.ToArray();
            brand2ImageMemoryStream.Dispose();

            var brand3 = new Brand
            {
                Category = category1,
                BrandName = "Serbetli",
                Products = new List<Product>()
            };

            Image brand3Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "\\Images\\serbetli.jpg");
            System.IO.MemoryStream brand3ImageMemoryStream = new System.IO.MemoryStream();
            brand3Image.Save(brand3ImageMemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            brand3.BrandPicture = brand3ImageMemoryStream.ToArray();
            brand3ImageMemoryStream.Dispose();

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
            ctx.Brands.Add(brand2);
            ctx.Brands.Add(brand3);
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