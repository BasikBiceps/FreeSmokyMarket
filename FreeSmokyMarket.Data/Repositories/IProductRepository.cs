using System;
using System.Collections.Generic;
using System.Text;

using FreeSmokyMarket.Data.Entities;

namespace FreeSmokyMarket.Data.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        Product GetProductDetails(int productId);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);

        List<Brand> GetAllBrands(int productId);
        void CreateBrand(Brand brand);
        void UpdateBrand(Brand brand);
        void DeleteBrand(Brand brand);

        List<ConcreteProduct> GetAllConcreteProducts(int brandId);
        void CreateConcreteProduct(ConcreteProduct concreteProduct);
        void UpdateConcreteProduct(ConcreteProduct concreteProduct);
        void DeleteConcreteProduct(ConcreteProduct concreteProduct);
    }
}