using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web2Project_FoodDelivery.Models;

namespace Web2Project_FoodDelivery.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.Property(x => x.Email).HasMaxLength(30);
            builder.HasKey(x => x.Email);

            builder.HasAlternateKey(x => x.Username);
            builder.Property(x => x.Username).HasMaxLength(30);

            builder.Property(x => x.Password);

            builder.Property(x => x.FirstName).HasMaxLength(30);

            builder.Property(x => x.LastName).HasMaxLength(30);

            builder.Property(x => x.Address).HasMaxLength(30);

            builder.Property(x => x.Type);

            builder.Property(x => x.Birthday);

            builder.Property(x => x.Picture);

            builder.Property(x => x.Veryfied);

            builder.Property(x => x.AccepredRegistration);

            builder.HasMany(x => x.Orders).WithOne(x => x.Creator);
            builder.HasMany(x => x.Deliveris).WithOne(x => x.Deliverer);
        }
    }
}
