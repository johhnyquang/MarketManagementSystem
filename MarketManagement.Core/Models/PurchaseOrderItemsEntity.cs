using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Models
{
    public class PurchaseOrderItemsEntity
    {
        public int PurchaseOrderId { get; set; }
        public int ProductId { get; set; }
        public int QuantityOrdered { get; set; } // Số lượng đặt mua
        public int QuantityPhysical { get; set; } // Số lượng thực tế đã giao

        // Navigation Properties
        public PurchaseOrderEntity? PurchaseOrderEntity { get; set; }
        public ProductEntity? ProductEntity { get; set; }
    }
}
