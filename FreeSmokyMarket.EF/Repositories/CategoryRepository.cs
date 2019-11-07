using System;
using System.Collections.Generic;
using System.Text;
using FreeSmokyMarket.Data.Repositories;
using FreeSmokyMarket.Data.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FreeSmokyMarket.EF.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        public List<Category> GetAllCategories()
        {
            using (var ctx = new FreeSmokyMarketContext())
            {
                return ctx.Categories.ToList();
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
    }
}
