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
    public class RoleFunctionEntityConfiguration : IEntityTypeConfiguration<RoleFunctionEntity>
    {
        public void Configure(EntityTypeBuilder<RoleFunctionEntity> builder)
        {
            builder.ToTable<RoleFunctionEntity>("RoleFunctions");
            builder.HasKey(rf => new
            {
                rf.RoleId,
                rf.FunctionId
            });

            builder.Property(e => e.IsActive).HasDefaultValueSql("0");

            // FK Relationships
            builder.HasOne(rf => rf.Role)
                  .WithMany(r => r.RoleFunctionEntities)
                  .HasForeignKey(rf => rf.RoleId);

            builder.HasOne(rf => rf.Function)
                  .WithMany(f => f.RoleFunctionEntities)
                  .HasForeignKey(rf => rf.FunctionId);
        }
    }
}
