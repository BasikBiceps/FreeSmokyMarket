using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using FreeSmokyMarket.Data.Entities;

namespace FreeSmokyMarket
{
    public class FreeSmokyMarketContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ConcreteProduct> ConcreteProducts { get; set; }
        public DbSet<Product> Products { get; set; }

        public FreeSmokyMarketContext(DbContextOptions<FreeSmokyMarketContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
