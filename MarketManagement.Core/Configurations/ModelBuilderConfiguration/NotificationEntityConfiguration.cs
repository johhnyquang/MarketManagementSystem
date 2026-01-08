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
    public class NotificationEntityConfiguration : IEntityTypeConfiguration<NotificationEntity>
    {
        public void Configure(EntityTypeBuilder<NotificationEntity> builder)
        {
            builder.ToTable<NotificationEntity>("Notification");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("NotiId");

            builder.Property(e => e.NotificationType).HasConversion<int>().HasColumnName("NotificationType");
            builder.Property(e => e.Title).HasMaxLength(255).IsRequired();
            builder.Property(e => e.Message).HasColumnType("nvarchar(max)");
            builder.Property(e => e.IsRead).HasDefaultValueSql("0");
            builder.Property(e => e.Data).HasColumnType("nvarchar(max)");

            // FK Relationships
            builder.HasOne(n => n.User)
                   .WithMany(u => u.NotificationOrders)
                   .HasForeignKey(n => n.UserId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
