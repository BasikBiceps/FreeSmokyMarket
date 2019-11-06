using System;
using System.Collections.Generic;
using System.Text;

using FreeSmokyMarket.Data.Entities;

namespace FreeSmokyMarket.Data.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts(int brandId);
        Product GetProduct(int productId);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}