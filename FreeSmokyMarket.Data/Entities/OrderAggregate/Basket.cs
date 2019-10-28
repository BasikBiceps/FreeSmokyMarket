using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace FreeSmokyMarket.Data.Entities
{
    public class Basket
    {
        public int Id { get; set; }
        public int SessionId { set; get; }
        public DateTime SessionStart { get; set; }

        public Order Order { get; set; }

        public List<Product> Products { get; set; }
    }
}