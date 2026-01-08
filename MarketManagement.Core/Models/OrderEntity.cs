using MarketManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Models
{
    public class OrderEntity : BaseEntity
    {
        public string OrderNumber { get; set; } = string.Empty;
        public OrderStatus OrderStatus { get; set; } = OrderStatus.Pending;
        public string Note { get; set; } = string.Empty;
        public string ShippingAdress { get; set; } = string.Empty; // Địa chỉ ship hàng khác với khai báo
        public string ShippingPhone { get; set; } = string.Empty; // Số điện thoại nhận hàng khác với khai báo

        public DateTime ConfirmedAt { get; set; } // Ngày đặt hàng 
        public DateTime ShippedAt { get; set; } // Ngày shipper nhận hàng và chuẩn bị giao hàng
        public DateTime CompletedAt { get; set; } // Ngày shipper đã giao hàng

        public decimal SubTotal { get; set; } // Tổng tiền hàng chưa tính phí ship và giảm giá
        public decimal ShippingFee { get; set; }  // Tiền ship
        public decimal TotalAmount { get; set; } // Tổng tiền hóa đơn (SubTotal + ShippingFee)
        public int UserId { get; set; } // User ở đây sẽ là Role Khách hàng và Role Shipper

        // Navigation Properties
        public UserEntity? Customer { get; set; }
        public UserEntity? Shipper { get; set; }
        public ICollection<OrderItemsEntity> OrderItemsEntities { get; set; } = new List<OrderItemsEntity>();
    }
}
