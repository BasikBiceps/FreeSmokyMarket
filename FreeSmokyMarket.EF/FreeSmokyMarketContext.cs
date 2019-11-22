using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using FreeSmokyMarket.Data.Entities;
using System.Data.SqlTypes;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using FreeSmokyMarket.Data.Entities.Aggregates;

namespace FreeSmokyMarket.EF
{
    public class FreeSmokyMarketContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Basket> Baskets { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PurchasesItem> PurchasesItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            optionsBuilder.UseSqlServer(builder.Build().GetConnectionString("DefaultConnection"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().Property(cp => cp.Price).HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<Order>().Property(o => o.LastName).IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.FirstName).IsRequired();
            modelBuilder.Entity<Order>().Property(o => o.PhoneNumber).IsRequired();

            modelBuilder.Entity<Product>()
                .HasOne<Category>()
                .WithMany()
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Product>()
                .HasOne<Brand>()
                .WithMany()
                .HasForeignKey(p => p.BrandId);

            modelBuilder.Entity<Order>()
                .HasOne<Basket>()
                .WithMany()
                .HasForeignKey(bt => bt.BasketId);
        }
    }
}