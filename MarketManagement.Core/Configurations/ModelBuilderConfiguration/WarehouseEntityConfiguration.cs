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
    public class WarehouseEntityConfiguration : IEntityTypeConfiguration<WarehouseEntity>
    {
        public void Configure(EntityTypeBuilder<WarehouseEntity> builder)
        {
            builder.ToTable<WarehouseEntity>("WarehouseManagement");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("WarehouseId");

            builder.HasIndex(e => e.WarehouseCode).IsUnique();
            builder.Property(e => e.WarehouseCode).HasMaxLength(100).IsRequired();

            builder.Property(e => e.WarehouseName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.WarehouseAddress).HasMaxLength(250).IsRequired();

            builder.Property(e => e.Latitude).HasColumnType("decimal(10,7)");
            builder.Property(e => e.Longitude).HasColumnType("decimal(10,7)");
        }
    }
}
