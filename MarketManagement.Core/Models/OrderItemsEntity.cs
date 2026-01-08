using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Models
{
    public class OrderItemsEntity
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        // Snapshot thông tin sản phẩm tại thời điểm đặt hàng
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public string ProductSKU { get; set; } = string.Empty;
        public string ProductImage { get; set; } = string.Empty;

        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; } // Giá tại thời điểm đặt
        public decimal? Discount { get; set; } // Có giảm giá sản phẩm này ở thời điểm hiện tại
        public decimal TotalPrice { get; set; } // (UnitPrice * Quantity) - Discount

        public OrderEntity? Order { get; set; }
        public ProductEntity? Product { get; set; }
    }
}
