﻿using System;
using System.Collections.Generic;
using System.Text;
using FreeSmokyMarket.Data.Entities;

namespace FreeSmokyMarket.Data.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAllCategories();
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
    }
}
