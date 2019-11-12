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
        public List<Product> GetAllProducts(int brandId)
        {
            using (var ctx = new FreeSmokyMarketContext())
            {
                return ctx.Products.Where(p => p.BrandId == brandId).ToList();
            }
        }

        public Product GetProduct(int productId)
        {
            using (var ctx = new FreeSmokyMarketContext())
            {
                return ctx.Products.Where(p => p.Id == productId).FirstOrDefault();
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
    }
}