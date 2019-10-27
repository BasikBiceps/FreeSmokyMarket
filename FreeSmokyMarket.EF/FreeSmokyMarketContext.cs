using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using FreeSmokyMarket.Data.Entities;
using System.Data.SqlTypes;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace FreeSmokyMarket.EF
{
    public class FreeSmokyMarketContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ConcreteProduct> ConcreteProducts { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            optionsBuilder.UseSqlServer(builder.Build().GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Product>().HasMany(p => p.Brands).WithOne(b => b.Product);

            //modelBuilder.Entity<Brand>().HasMany(cp => cp.concreteProducts).WithOne(b => b.Brand);

            //modelBuilder.Entity<ConcreteProduct>().HasOne(cp => cp.Brand);

            //modelBuilder.Entity<Order>().HasOne(o => o.Basket);

            //modelBuilder.Entity<Basket>().HasMany(cp => cp.concreteProducts);
        }
    }
}
