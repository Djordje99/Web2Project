using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2Project_FoodDelivery.Models;

namespace Web2Project_FoodDelivery.Infrastructure.Configurations
{
    public class DeliveryConfiguration : IEntityTypeConfiguration<DeliveryModel>
    {
        public void Configure(EntityTypeBuilder<DeliveryModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Deliverer)
                   .WithMany(x => x.Deliveris)
                   .HasForeignKey(x => x.DelivererEmail);

            builder.HasOne(x => x.Order).WithOne(x => x.Delivery);
        }
    }
}
