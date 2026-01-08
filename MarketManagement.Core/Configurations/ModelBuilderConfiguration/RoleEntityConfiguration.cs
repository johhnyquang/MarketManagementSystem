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
    public class RoleEntityConfiguration : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> builder)
        {
            builder.ToTable<RoleEntity>("RoleManagement");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("RoleId");

            builder.Property(e => e.RoleName).HasMaxLength(100).IsRequired();
        }
    }
}
