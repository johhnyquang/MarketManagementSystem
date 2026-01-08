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
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<CategoryEntity>
    {
        public void Configure(EntityTypeBuilder<CategoryEntity> builder)
        {
            builder.ToTable<CategoryEntity>("Category");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("CateId");

            builder.Property(e => e.Name).HasMaxLength(100).HasColumnName("CateName").IsRequired();
            builder.Property(e => e.ImageUrl).HasColumnType("nvarchar(max)").HasColumnName("CateImageUrl").IsRequired();
            builder.Property(e => e.Description).HasColumnType("nvarchar(max)");
        }
    }
}
