using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2Project_FoodDelivery.Models;

namespace Web2Project_FoodDelivery.Infrastructure.Configurations
{
    public class OrderDetailsConfiguration : IEntityTypeConfiguration<OrderDetailsModel>
    {
        public void Configure(EntityTypeBuilder<OrderDetailsModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Amount);

            builder.Property(x => x.CurrentPrice);

            builder.Property(x => x.OrderDate);

            builder.HasOne(x => x.Order)
                   .WithMany(x => x.OrderDetails)
                   .HasForeignKey(x => x.OrderId);

            builder.HasOne(x => x.Product)
                   .WithMany(x => x.ProductDetails)
                   .HasForeignKey(x => x.ProductId);
        }
    }
}
