using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FreeSmokyMarket.Data.Entities
{
    public enum TobaccoStrength
    {
        Light,
        Medium,
        Hard
    }

    public class Tobacco
    {
        public int Id { get; set; }
        public string Taste { get; set; }
        public decimal Price { get; set; }
        public TobaccoStrength TobaccoStrength { get; set; }
        public int Amount { get; set; }
        public string Description { get; set; }
        public Brand Brand { get; set; }
    }
}
