using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2Project_FoodDelivery.Models;

namespace Web2Project_FoodDelivery.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<ProductModel>
    {
        public void Configure(EntityTypeBuilder<ProductModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).HasMaxLength(30);

            builder.Property(x => x.Price);

            builder.Property(x => x.Ingredients).HasMaxLength(100);

            builder.HasMany(x => x.ProductDetails).WithOne(x => x.Product);
        }
    }
}
