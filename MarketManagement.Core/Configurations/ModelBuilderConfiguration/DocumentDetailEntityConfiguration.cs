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
    public class DocumentDetailEntityConfiguration : IEntityTypeConfiguration<DocumentDetailEntity>
    {
        public void Configure(EntityTypeBuilder<DocumentDetailEntity> builder)
        {
            builder.ToTable<DocumentDetailEntity>("DocumentDetail", ck => ck.HasCheckConstraint("CK_DocumentDetail_QuantityPhysical_LessThanOrEqual_QuantityOrdered", "QuantityOrdered >= QuantityPhysical"));
            builder.HasKey(e => new
            {
                e.DocumentHeaderId,
                e.ProductId
            });

            // FK Relationships
            builder.HasOne(docDetail => docDetail.DocumentHeaderEntity)
                   .WithMany(doc => doc.DocumentDetailEntities)
                   .HasForeignKey(docDetail => docDetail.DocumentHeaderId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(docDetail => docDetail.ProductEntity)
                   .WithMany(p => p.DocumentDetailEntities)
                   .HasForeignKey(docDetail => docDetail.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
