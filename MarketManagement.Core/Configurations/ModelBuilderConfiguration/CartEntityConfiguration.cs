using MarketManagement.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Configurations.ModelBuilderConfiguration
{
    public class CartEntityConfiguration : IEntityTypeConfiguration<CartEntity>
    {
        public void Configure(EntityTypeBuilder<CartEntity> builder)
        {
            builder.ToTable<CartEntity>("Cart");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("CartId");

            builder.HasOne(c => c.User)
                   .WithMany(u => u.CartEntities)
                   .HasForeignKey(c => c.UsertId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
