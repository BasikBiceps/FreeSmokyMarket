using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeSmokyMarket.Models
{
    public class Product //jguyuyf
    {
        public int Id { get; set; }
        public string ProductName { get; set; }

        public List<Brand> Brands;
    }
}
