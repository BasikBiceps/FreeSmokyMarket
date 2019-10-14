using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace FreeSmokyMarket.Models
{
    public class FreeSmokyMarketContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Tobacco> Tobaccos { get; set; }
        public DbSet<Product> Products { get; set; }

        public FreeSmokyMarketContext(DbContextOptions<FreeSmokyMarketContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
