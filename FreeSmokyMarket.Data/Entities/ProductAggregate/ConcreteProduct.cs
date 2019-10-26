using System;
using System.Collections.Generic;
using System.Text;

namespace FreeSmokyMarket.Data.Entities
{
    public class ConcreteProduct
    {
            public int Id { get; set; }
            public decimal Price { get; set; }
            public int Amount { get; set; }
            public string Description { get; set; }
            public Brand Brand { get; set; }
    }
}
