using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2Project_FoodDelivery.Models;

namespace Web2Project_FoodDelivery.Infrastructure
{
    public class FoodDeliveryDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<OrderDetailsModel> OrderDetails { get; set; }
        public DbSet<DeliveryModel> Deliveries { get; set; }

        public FoodDeliveryDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FoodDeliveryDbContext).Assembly);
        }
    }
}
