using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace FreeSmokyMarket.Models
{
    public class FreeSmokyMarketContext : DbContext
    {
        public DbSet<Tabacco> Tabaccos { get; set; }
        public DbSet<Order> Orders { get; set; }

        public FreeSmokyMarketContext(DbContextOptions<FreeSmokyMarketContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
