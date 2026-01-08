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
    public class MovementTypeEntityConfiguration : IEntityTypeConfiguration<MovementTypeEntity>
    {
        public void Configure(EntityTypeBuilder<MovementTypeEntity> builder)
        {
            builder.ToTable<MovementTypeEntity>("MovementType");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("MovementTypeId");

            builder.HasIndex(e => e.Code).IsUnique();
            builder.Property(e => e.Code).HasMaxLength(10).IsRequired();

            builder.Property(e => e.Name).HasMaxLength(150).IsRequired();
        }
    }
}
