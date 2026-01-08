using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Models
{
    public class SupplierEntity : BaseEntity
    {
        public string Email { get; set; } = string.Empty;
        public string SupplierName { get; set;} = string.Empty;

        // Navigation Properties
        public ICollection<PurchaseOrderEntity> PurchaseOrderEntities { get; set; } = new List<PurchaseOrderEntity>();
    }
}
