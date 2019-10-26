using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeSmokyMarket.Data.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }

        public List<Brand> Brands;
    }
}
