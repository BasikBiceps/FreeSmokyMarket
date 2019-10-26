using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeSmokyMarket.Data.Entities
{
    public class Brand
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public Product Product { get; set; }

        public List<ConcreteProduct> concreteProducts;
    }
}
