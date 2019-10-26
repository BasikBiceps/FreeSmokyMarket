using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeSmokyMarket.Data.Entities
{
    public class Basket
    {
        public int Id { get; set; }
        public int SessionId { set; get; }
        public DateTime SessionStart { get; set; }

        public List<ConcreteProduct> concreteProducts;
    }
}
