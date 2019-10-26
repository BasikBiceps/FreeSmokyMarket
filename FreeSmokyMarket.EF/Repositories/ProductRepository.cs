using System;
using System.Collections.Generic;
using System.Text;

using FreeSmokyMarket.Data.Entities;
using FreeSmokyMarket.Data.Repositories;

namespace FreeSmokyMarket.EF.Repositories
{
    public class ProductRepository
    {
        List<Product> GetAllProducts() { return new List<Product>(); }
        Product GetProductDetails(int productId) { return new Product(); }
        void CreateProduct(Product product) { }
        void UpdateProduct(Product product) { }
        void DeleteProduct(Product product) { }
    }
}
