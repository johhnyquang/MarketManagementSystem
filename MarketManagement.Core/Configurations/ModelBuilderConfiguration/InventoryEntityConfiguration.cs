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
    public class InventoryEntityConfiguration : IEntityTypeConfiguration<InventoryEntity>
    {
        public void Configure(EntityTypeBuilder<InventoryEntity> builder)
        {
            builder.ToTable<InventoryEntity>("Inventory");
            builder.HasKey(inv => new
            {
                inv.WarehouseId,
                inv.ProductId
            });

            //FK Relationships
            builder.HasOne(inv => inv.Product)
                   .WithMany(p => p.InventoryEntities)
                   .HasForeignKey(p => p.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(inv => inv.Warehouse)
                   .WithMany(w => w.InventoryEntities)
                   .HasForeignKey(inv => inv.WarehouseId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
