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
                var brandIdHashSet = ctx.Products.Where(p => p.CategoryId == categoryId).Select(p => p.BrandId).ToHashSet();
                var brandList = new List<Brand>();

                foreach (var el in brandIdHashSet)
                {
                    brandList.Add(GetBrand(el));
                }

                return brandList;
            }
        }

        public Brand GetBrand(int brandId)
        {
            using (var ctx = new FreeSmokyMarketContext())
            {
                return ctx.Brands.Where(b => b.Id == brandId).FirstOrDefault();
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
