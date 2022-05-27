using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2Project_FoodDelivery.Models;

namespace Web2Project_FoodDelivery.Infrastructure.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<OrderModel>
    {
        public void Configure(EntityTypeBuilder<OrderModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Comment).HasMaxLength(300);

            builder.Property(x => x.Address).HasMaxLength(100);

            builder.Property(x => x.Status);

            builder.HasOne(x => x.Creator)
                   .WithMany(x => x.Orders)
                   .HasForeignKey(x => x.CreatorEmail);

            //builder.HasOne(x => x.Deliverer)
            //       .WithMany(x => x.Deliveris)
            //       .HasForeignKey(x => x.DelivererEmail);

            builder.HasMany(x => x.OrderDetails).WithOne(x => x.Order);
        }
    }
}
