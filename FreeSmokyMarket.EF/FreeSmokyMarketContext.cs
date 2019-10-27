﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using FreeSmokyMarket.Data.Entities;
using System.Data.SqlTypes;
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

        public FreeSmokyMarketContext(DbContextOptions<FreeSmokyMarketContext> options)
            : base(options)
        {
            // Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ConcreteProduct>().Property(cp => cp.Price).HasColumnType("decimal(18, 2)");

            //modelBuilder.Entity<Product>()
            //    .HasMany<Brand>()
            //    .WithOne(b => b.Product);

            //modelBuilder.Entity<Brand>()
            //    .HasMany<ConcreteProduct>()
            //    .WithOne(cp => cp.Brand);

            //modelBuilder.Entity<Basket>()
            //    .HasMany<ConcreteProduct>()
            //    .WithOne(bt => bt.Basket);

            //modelBuilder.Entity<Order>()
            //    .HasOne(o => o.Basket);

        }
    }
}
