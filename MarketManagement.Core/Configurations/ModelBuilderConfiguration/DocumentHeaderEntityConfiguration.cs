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
    public class DocumentHeaderEntityConfiguration : IEntityTypeConfiguration<DocumentHeaderEntity>
    {
        public void Configure(EntityTypeBuilder<DocumentHeaderEntity> builder)
        {
            builder.ToTable<DocumentHeaderEntity>("DocumentHeader");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("DocumentId");

            builder.HasIndex(e => e.DocumentNo).IsUnique();
            builder.Property(e => e.DocumentNo).HasMaxLength(150).IsRequired();

            builder.Property(e => e.DocumentStatus).HasConversion<int>().HasColumnName("DocumentStatus");
            builder.Property(e => e.IsAssign).HasDefaultValueSql("0");

            // FK Relationships
            builder.HasOne(doc => doc.MovementType)
                   .WithMany(m => m.DocumentHeaderEntities)
                   .HasForeignKey(doc => doc.DocumentTypeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
