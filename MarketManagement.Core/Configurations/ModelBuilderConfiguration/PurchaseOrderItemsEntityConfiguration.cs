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
    public class PurchaseOrderItemsEntityConfiguration : IEntityTypeConfiguration<PurchaseOrderItemsEntity>
    {
        public void Configure(EntityTypeBuilder<PurchaseOrderItemsEntity> builder)
        {
            builder.ToTable<PurchaseOrderItemsEntity>("PurchaseOrderItems", ck => ck.HasCheckConstraint("CK_PurchaseOrderItems_QuantityPhysical_LessThanOrEqual_QuantityOrdered", "QuantityOrdered >= QuantityPhysical"));
            builder.HasKey(poi => new
            {
                poi.PurchaseOrderId,
                poi.ProductId
            });

            // FK Relationships
            builder.HasOne(poi => poi.PurchaseOrderEntity)
                   .WithMany(po => po.PurchaseOrderItemsEntities)
                   .HasForeignKey(poi => poi.PurchaseOrderId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(poi => poi.ProductEntity)
                   .WithMany(p => p.PurchaseOrderItemsEntities)
                   .HasForeignKey(poi => poi.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
