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
    public class SupplierEntityConfiguration : IEntityTypeConfiguration<SupplierEntity>
    {
        public void Configure(EntityTypeBuilder<SupplierEntity> builder)
        {
            builder.ToTable<SupplierEntity>("SupplierManagement");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("SupplierId");

            builder.HasIndex(e => e.Email).IsUnique();
            builder.Property(e => e.Email).HasMaxLength(250).IsRequired();

            builder.Property(e => e.SupplierName).HasMaxLength(100).IsRequired();
        }
    }
}
