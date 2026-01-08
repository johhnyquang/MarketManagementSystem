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
    public class FunctionEntityConfiguration : IEntityTypeConfiguration<FunctionEntity>
    {
        public void Configure(EntityTypeBuilder<FunctionEntity> builder)
        {
            builder.ToTable<FunctionEntity>("FunctionManagement");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("FunctionId");

            builder.HasIndex(e => e.FunctionCode).IsUnique();
            builder.Property(e => e.FunctionName).HasMaxLength(100).IsRequired();
        }
    }
}
