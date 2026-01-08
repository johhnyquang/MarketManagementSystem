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
    public class CartItemsEntityConfiguration : IEntityTypeConfiguration<CartItemsEntity>
    {
        public void Configure(EntityTypeBuilder<CartItemsEntity> builder)
        {
            builder.ToTable<CartItemsEntity>("CartItems");
            builder.HasKey(e => new
            {
                e.CartId,
                e.ProductId,
            });

            // FK Relationships
            builder.HasOne(ci => ci.Cart)
                   .WithMany(c => c.CartItemsEntities)
                   .HasForeignKey(ci => ci.CartId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ci => ci.Product)
                   .WithMany(p => p .CartItemsEntities)
                   .HasForeignKey(ci => ci.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
