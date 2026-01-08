using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Models
{
    public class UserEntity : BaseEntity
    {
        public string Email { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string? PasswordHash { get; set; }
        public string? ExternalIDLogin { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int RoleId { get; set; } 
        public int? WarehouseId { get; set; } // 1 user chỉ thuộc 1 warehouse cái này là đối với nhân viên thuộc Store còn nhân viên shipper sẽ không có warehouse và các user thuộc role customer sẽ không có warehouse

        // SignalR ConnectionID for real-time notification
        public string? ConnnectionID { get; set; }

        // Vị trị hiện tại của shipper khi họ login vào hệ thống để hệ thống thực hiện điều hướng đơn hàng tới vị trí shipper gần nhất
        // xử lý dưới mobile trước khi shipper login vào app sẽ bắt vị trí hiện tại của shipper
        public long Latitude { get; set; } // Kinh độ 
        public long Longitude { get; set; } // Vĩ độ

        // Navigation Properties
        public RoleEntity? Role { get; set; }
        public WarehouseEntity? Warehouse { get; set; }
        public ICollection<PurchaseOrderEntity> PurchaseOrders { get; set; } = new List<PurchaseOrderEntity>(); // 1 user sé được tạo nhiều PO
        public ICollection<OrderEntity> Orders { get; set; } = new List<OrderEntity>(); // Role khách hàng
        public ICollection<OrderEntity> ShipperOrders { get; set; } = new List<OrderEntity>(); // Role Shipper
        public ICollection<NotificationEntity> NotificationOrders { get; set; } = new List<NotificationEntity>();

        public ICollection<CartEntity> CartEntities { get; set; } = new List<CartEntity>();
    }
}
