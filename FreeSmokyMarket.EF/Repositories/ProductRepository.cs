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

            //using (var ctx = new FreeSmokyMarketContext())
            //{
            //    return ctx.Products.ToList();
            //}
            return new List<Product>();
        }

        public Product GetProductDetails(int productId)
        {
            //using (var ctx = new FreeSmokyMarketContext())
            //{
            //    var product = ctx.Products.Include(p => p.Brands).ThenInclude(cp => cp.con)
            //}
            return new Product();
        }
        public void CreateProduct(Product product) { }
        public void UpdateProduct(Product product) { }
        public void DeleteProduct(Product product) { }
    }
}
