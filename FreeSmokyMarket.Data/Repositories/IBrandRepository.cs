using System;
using System.Collections.Generic;
using System.Text;
using FreeSmokyMarket.Data.Entities;

namespace FreeSmokyMarket.Data.Repositories
{
    public interface IBrandRepository
    {
        List<Brand> GetAllBrands(int categoryId);
        void CreateBrand(Brand brand);
        void UpdateBrand(Brand brand);
        void DeleteBrand(Brand brand);
    }
}
