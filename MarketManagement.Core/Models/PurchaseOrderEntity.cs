using MarketManagement.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Models
{
    public class PurchaseOrderEntity : BaseEntity
    {
        public string PurchaseOrderNumber { get; set; } = string.Empty;
        public int SupplierId { get; set; }

        // Snapshot thông tin Supplier
        public string SupplierName { get; set;} = string.Empty;
        public string Email { get; set;} = string.Empty;

        public PurchaseStatus PurchaseStatus { get; set; } = PurchaseStatus.Created;

        // User nào tạo PO này 
        public int UserId { get; set; }
        public bool IsAssign { get; set; } = false; // PO này có được Văn phòng chấp nhận hay không

        // Điều kiện để tạo PO mới cho user là PO trước phải được assign và các transaction đã hoàn thành hết

        // Navigation Properties
        public SupplierEntity? SupplierEntity { get; set; }
        public UserEntity? UserEntity { get; set; } // 1 PO chỉ thuộc 1 user 
        public ICollection<PurchaseOrderItemsEntity> PurchaseOrderItemsEntities { get; set; } = new List<PurchaseOrderItemsEntity>();
    }
}
