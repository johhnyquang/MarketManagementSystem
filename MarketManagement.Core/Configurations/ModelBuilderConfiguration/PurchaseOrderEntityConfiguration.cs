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
    public class PurchaseOrderEntityConfiguration : IEntityTypeConfiguration<PurchaseOrderEntity>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrderEntity> builder)
        {
            builder.ToTable<PurchaseOrderEntity>("PurchaseOrder");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("PurchaseOrderId");

            builder.HasIndex(e => e.PurchaseOrderNumber).IsUnique();
            builder.Property(e => e.PurchaseOrderNumber).HasMaxLength(250).IsRequired();

            builder.Property(e => e.PurchaseStatus).HasConversion<int>().HasColumnName("PurchaseStatus");
            builder.Property(e => e.IsAssign).HasDefaultValueSql("0");

            // FK Relationships
            builder.HasOne(po => po.SupplierEntity)
                   .WithMany(s => s.PurchaseOrderEntities)
                   .HasForeignKey(po => po.SupplierId);

            builder.HasOne(po => po.UserEntity)
                   .WithMany(u => u.PurchaseOrders)
                   .HasForeignKey(po => po.UserId);
        }
    }
}
