using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace FreeSmokyMarket.Data.Entities.Aggregates
{
    public class Basket
    {
        public int Id { get; set; }
        public string SessionId { get; set; }
        public List<PurchasesItem> PurchasesItems { get; set; }
    }
}