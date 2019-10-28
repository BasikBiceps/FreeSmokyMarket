using System;
using System.Collections.Generic;
using System.Text;

using FreeSmokyMarket.Data.Entities;

namespace FreeSmokyMarket.Data.Repositories
{
    public interface IProductRepository
    {
        List<Category> GetAllCategories();
        Category GetCategoryDetails(int categoryId);
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);

        List<Brand> GetAllBrands(int categoryId);
        void CreateBrand(Brand brand);
        void UpdateBrand(Brand brand);
        void DeleteBrand(Brand brand);

        List<Product> GetAllProducts(int brandId);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}