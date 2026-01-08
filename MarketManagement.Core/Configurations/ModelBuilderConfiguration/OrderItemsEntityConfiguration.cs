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
    public class OrderItemsEntityConfiguration : IEntityTypeConfiguration<OrderItemsEntity>
    {
        public void Configure(EntityTypeBuilder<OrderItemsEntity> builder)
        {
            builder.ToTable<OrderItemsEntity>("OrderItems");
            builder.HasKey(oi => new
            {
                oi.OrderId,
                oi.ProductId,
            });

            builder.Property(e => e.UnitPrice).HasColumnType("decimal(18,2)");
            builder.Property(e => e.Discount).HasColumnType("decimal(18,2)");
            builder.Property(e => e.TotalPrice).HasColumnType("decimal(18,2)");

            // FK Relationships
            builder.HasOne(oi => oi.Order)
                   .WithMany(o => o.OrderItemsEntities)
                   .HasForeignKey(o => o.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(oi => oi.Product)
                   .WithMany(p => p.OrderItemsEntities)
                   .HasForeignKey(oi => oi.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
