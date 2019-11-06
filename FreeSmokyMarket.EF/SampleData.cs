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

            Product product1 = new Product();
            product1.Amount = 3;
            product1.Brand = brand1;
            product1.Description = "Cherry";
            product1.Price = 200;
            Image product1Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "\\Images\\fumari_cherry.jpg");
            System.IO.MemoryStream product1ImageMemoryStream = new System.IO.MemoryStream();
            product1Image.Save(product1ImageMemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            product1.ProductPicture = product1ImageMemoryStream.ToArray();
            product1ImageMemoryStream.Dispose();


            Product product2 = new Product();
            product2.Amount = 3;
            product2.Brand = brand1;
            product2.Description = "Chocolate-mint ice-cream";
            product2.Price = 200;
            Image product2Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "\\Images\\fumari_chocolate_mint_ice_cream.jpg");
            System.IO.MemoryStream product2ImageMemoryStream = new System.IO.MemoryStream();
            product2Image.Save(product2ImageMemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            product2.ProductPicture = product2ImageMemoryStream.ToArray();
            product2ImageMemoryStream.Dispose();


            Product product3 = new Product();
            product3.Amount = 3;
            product3.Brand = brand1;
            product3.Description = "Raspberry";
            product3.Price = 200;
            Image product3Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "\\Images\\fumari_raspberry.jpg");
            System.IO.MemoryStream product3ImageMemoryStream = new System.IO.MemoryStream();
            product3Image.Save(product3ImageMemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            product3.ProductPicture = product3ImageMemoryStream.ToArray();
            product3ImageMemoryStream.Dispose();

            Product product4 = new Product();
            product4.Amount = 3;
            product4.Brand = brand1;
            product4.Description = "Pineapple and coconut";
            product4.Price = 200;
            Image product4Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "\\Images\\fumari_pineapple_coconut.jpg");
            System.IO.MemoryStream product4ImageMemoryStream = new System.IO.MemoryStream();
            product4Image.Save(product4ImageMemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            product4.ProductPicture = product4ImageMemoryStream.ToArray();
            product4ImageMemoryStream.Dispose();

            Product product5 = new Product();
            product5.Amount = 3;
            product5.Brand = brand1;
            product5.Description = "Apple";
            product5.Price = 200;
            Image product5Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "\\Images\\fumari_apple.jpg");
            System.IO.MemoryStream product5ImageMemoryStream = new System.IO.MemoryStream();
            product5Image.Save(product5ImageMemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            product5.ProductPicture = product5ImageMemoryStream.ToArray();
            product5ImageMemoryStream.Dispose();

            Product product6 = new Product();
            product6.Amount = 3;
            product6.Brand = brand1;
            product6.Description = "Grape";
            product6.Price = 200;
            Image product6Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "\\Images\\fumari_grape.jpg");
            System.IO.MemoryStream product6ImageMemoryStream = new System.IO.MemoryStream();
            product6Image.Save(product6ImageMemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            product6.ProductPicture = product6ImageMemoryStream.ToArray();
            product6ImageMemoryStream.Dispose();

            Product product7 = new Product();
            product7.Amount = 3;
            product7.Brand = brand1;
            product7.Description = "Lemon";
            product7.Price = 200;
            Image product7Image = Image.FromFile(System.IO.Directory.GetCurrentDirectory() + "\\Images\\fumari_lemon.jpg");
            System.IO.MemoryStream product7ImageMemoryStream = new System.IO.MemoryStream();
            product7Image.Save(product7ImageMemoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            product7.ProductPicture = product7ImageMemoryStream.ToArray();
            product7ImageMemoryStream.Dispose();

            brand1.Products.Add(product1);
            brand1.Products.Add(product2);
            brand1.Products.Add(product3);
            brand1.Products.Add(product4);
            brand1.Products.Add(product5);
            brand1.Products.Add(product6);
            brand1.Products.Add(product7);

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

            ctx.Categories.Add(category1);
            ctx.Brands.Add(brand1);
            ctx.Brands.Add(brand2);
            ctx.Brands.Add(brand3);

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