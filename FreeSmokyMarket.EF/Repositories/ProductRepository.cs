using System;
using System.Collections.Generic;
using System.Text;

using FreeSmokyMarket.Data.Entities;
using FreeSmokyMarket.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace FreeSmokyMarket.EF.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public List<Product> GetAllProducts()
        {
            using (var ctx = new FreeSmokyMarketContext())
            {
                return ctx.Products.ToList();
            }
        }

        public Product GetProductDetails(int productId)
        {
            using (var ctx = new FreeSmokyMarketContext())
            {
                return ctx.Products.Include(p => p.Brands).ThenInclude(cp => cp.ConcreteProducts).Where(p => p.Id == productId).FirstOrDefault();
            }
        }

        public void CreateProduct(Product product)
        {
            using (var ctx = new FreeSmokyMarketContext())
            {
                ctx.Add(product);
                ctx.SaveChanges();
            }
        }

        public void UpdateProduct(Product product)
        {
            using (var ctx = new FreeSmokyMarketContext())
            {
                ctx.Update(product);
                ctx.SaveChanges();
            }
        }

        public void DeleteProduct(Product product)
        {
            using (var ctx = new FreeSmokyMarketContext())
            {
                ctx.Remove(product);
                ctx.SaveChanges();
            }
        }

        public List<Brand> GetAllBrands(int productId)
        {
            using (var ctx = new FreeSmokyMarketContext())
            {
                return ctx.Brands.Include(b => b.Product).Where(b => b.Product.Id == productId).ToList();
            }
        }

        public List<ConcreteProduct> GetAllConcreteProducts(int brandId)
        {
            using (var ctx = new FreeSmokyMarketContext())
            {
                return ctx.ConcreteProducts.Include(cp => cp.Brand).Where(cp => cp.Brand.Id == brandId).ToList();
            }
        }

        public void CreateBrand(Brand brand)
        {
            using (var ctx = new FreeSmokyMarketContext())
            {
                ctx.Add(brand);
                ctx.SaveChanges();
            }
        }

        public void UpdateBrand(Brand brand)
        {
            using (var ctx = new FreeSmokyMarketContext())
            {
                ctx.Update(brand);
                ctx.SaveChanges();
            }
        }

        public void DeleteBrand(Brand brand)
        {
            using (var ctx = new FreeSmokyMarketContext())
            {
                ctx.Remove(brand);
                ctx.SaveChanges();
            }
        }

        public void CreateConcreteProduct(ConcreteProduct concreteProduct)
        {
            using (var ctx = new FreeSmokyMarketContext())
            {
                ctx.Add(concreteProduct);
                ctx.SaveChanges();
            }
        }

        public void UpdateConcreteProduct(ConcreteProduct concreteProduct)
        {
            using (var ctx = new FreeSmokyMarketContext())
            {
                ctx.Update(concreteProduct);
                ctx.SaveChanges();
            }
        }

        public void DeleteConcreteProduct(ConcreteProduct concreteProduct)
        {
            using (var ctx = new FreeSmokyMarketContext())
            {
                ctx.Remove(concreteProduct);
                ctx.SaveChanges();
            }
        }
    }
}