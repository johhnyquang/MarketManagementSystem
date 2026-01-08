using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Models
{
    public class MovementTypeEntity : BaseEntity
    {
        public string Code { get; set; } = string.Empty; // 101,102
        public string Name { get; set; } = string.Empty; // GR PO, Return, GI SO

        // Navigation Properties
        public ICollection<DocumentHeaderEntity> DocumentHeaderEntities { get; set; } = new List<DocumentHeaderEntity>();
        public ICollection<DocumentTransactionEntity> DocumentTransactionEntities { get; set; } = new List<DocumentTransactionEntity>();
    }
}
