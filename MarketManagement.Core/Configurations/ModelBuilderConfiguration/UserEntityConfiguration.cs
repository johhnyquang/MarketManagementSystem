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
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable<UserEntity>("UserManagement");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("UserId");

            builder.HasIndex(e => e.Email).IsUnique();
            builder.Property(e => e.Email).HasMaxLength(250).IsRequired();
            builder.Property(e => e.FullName).HasMaxLength(100).IsRequired();
            builder.Property(e => e.PhoneNumber).HasMaxLength(13).IsRequired();
            builder.Property(e => e.Address).HasMaxLength(250).IsRequired();

            builder.Property(e => e.Latitude).HasColumnType("decimal(10,7)");
            builder.Property(e => e.Longitude).HasColumnType("decimal(10,7)");

            builder.Property(e => e.ExternalIDLogin).HasMaxLength(250);
            builder.Property(e => e.PasswordHash).HasMaxLength(250);
            builder.Property(e => e.ConnnectionID).HasMaxLength(250);

            // FK Relationship
            builder.HasOne(u => u.Role)
                  .WithMany(r => r.UserEntities)
                  .HasForeignKey(u => u.RoleId);

            builder.HasOne(u => u.Warehouse)
                  .WithMany(w => w.UserEntities)
                  .HasForeignKey(u => u.WarehouseId);
        }
    }
}
