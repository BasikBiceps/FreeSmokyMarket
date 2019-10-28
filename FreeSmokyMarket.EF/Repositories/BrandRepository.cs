using System;
using System.Collections.Generic;
using System.Text;
using FreeSmokyMarket.Data.Repositories;
using FreeSmokyMarket.Data.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace FreeSmokyMarket.EF.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        public List<Brand> GetAllBrands(int categoryId)
        {
            using (var ctx = new FreeSmokyMarketContext())
            {
                return ctx.Brands.Include(b => b.Category).Where(b => b.Category.Id == categoryId).ToList();
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
    }
}
