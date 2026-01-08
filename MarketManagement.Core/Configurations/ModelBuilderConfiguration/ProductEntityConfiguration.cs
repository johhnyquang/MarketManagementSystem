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
    public class ProductEntityConfiguration : IEntityTypeConfiguration<ProductEntity>
    {
        public void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.ToTable<ProductEntity>("ProductManagement");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("ProductId");

            builder.HasIndex(e => e.SKU).IsUnique();
            builder.Property(e => e.SKU).HasMaxLength(150).IsRequired();
            builder.Property(e => e.ProductName).HasMaxLength(250).IsRequired();
            builder.Property(e => e.ProductDescription).HasColumnType("nvarchar(max)");
            builder.Property(e => e.ImageUrl).HasColumnType("nvarchar(max)").HasColumnName("ProductImageUrl").IsRequired();
            builder.Property(e => e.IsActive).HasDefaultValueSql("1");

            builder.Property(e => e.Price).HasColumnType("decimal(18,2)");

            // FK Relationships
            builder.HasOne(p => p.Category)
                   .WithMany(c => c.ProductEntities)
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
