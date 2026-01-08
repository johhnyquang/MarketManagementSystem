using MarketManagement.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Configurations.ModelBuilderConfiguration
{
    public class DocumentTransactionEntityConfiguration : IEntityTypeConfiguration<DocumentTransactionEntity>
    {
        public void Configure(EntityTypeBuilder<DocumentTransactionEntity> builder)
        {
            builder.ToTable<DocumentTransactionEntity>("DocumentTransaction");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("DocumentId");
        }
    }
}
