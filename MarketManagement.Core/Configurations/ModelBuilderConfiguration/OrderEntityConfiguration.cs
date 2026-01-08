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
    public class OrderEntityConfiguration : IEntityTypeConfiguration<OrderEntity>
    {
        public void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            builder.ToTable<OrderEntity>("Orders");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("OrderId");
            
            builder.HasIndex(e => e.OrderNumber).IsUnique();
            builder.Property(e => e.OrderNumber).HasMaxLength(250).IsRequired();

            builder.Property(e => e.OrderStatus).HasConversion<int>().HasColumnName("OrderStatus");
            builder.Property(e => e.Note).HasColumnType("nvarchar(max)");
            builder.Property(e => e.ShippingAdress).HasMaxLength(250).IsRequired();
            builder.Property(e => e.ShippingPhone).HasMaxLength(13).IsRequired();

            builder.Property(e => e.SubTotal).HasColumnType("decimal(18,2)");
            builder.Property(e => e.ShippingFee).HasColumnType("decimal(18,2)");
            builder.Property(e => e.TotalAmount).HasColumnType("decimal(18,2)");

            // FK Relationships
            builder.HasOne(o => o.Customer)
                   .WithMany(u => u.Orders)
                   .HasForeignKey(o => o.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Shipper)
                   .WithMany(u => u.ShipperOrders)
                   .HasForeignKey(o => o.UserId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
