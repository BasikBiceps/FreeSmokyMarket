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
        public List<Category> GetAllCategories()
        {
            using (var ctx = new FreeSmokyMarketContext())
            {
                return ctx.Categories.ToList();
            }
        }

        public Category GetCategoryDetails(int categoryId)
        {
            using (var ctx = new FreeSmokyMarketContext())
            {
                return ctx.Categories.Include(c => c.Brands).ThenInclude(b => b.Products).Where(c => c.Id == categoryId).FirstOrDefault();
            }
        }

        public void CreateCategory(Category category)
        {
            using (var ctx = new FreeSmokyMarketContext())
            {
                ctx.Add(category);
                ctx.SaveChanges();
            }
        }

        public void UpdateCategory(Category category)
        {
            using (var ctx = new FreeSmokyMarketContext())
            {
                ctx.Update(category);
                ctx.SaveChanges();
            }
        }

        public void DeleteCategory(Category category)
        {
            using (var ctx = new FreeSmokyMarketContext())
            {
                ctx.Remove(category);
                ctx.SaveChanges();
            }
        }

        public List<Brand> GetAllBrands(int categoryId)
        {
            using (var ctx = new FreeSmokyMarketContext())
            {
                return ctx.Brands.Include(b => b.Category).Where(b => b.Category.Id == categoryId).ToList();
            }
        }

        public List<Product> GetAllProducts(int brandId)
        {
            using (var ctx = new FreeSmokyMarketContext())
            {
                return ctx.Products.Include(cp => cp.Brand).Where(cp => cp.Brand.Id == brandId).ToList();
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