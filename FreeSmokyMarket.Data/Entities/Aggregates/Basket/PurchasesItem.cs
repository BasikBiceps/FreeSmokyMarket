using System;
using System.Collections.Generic;
using System.Text;

namespace FreeSmokyMarket.Data.Entities.Aggregates
{
    public class PurchasesItem
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
    }
}
