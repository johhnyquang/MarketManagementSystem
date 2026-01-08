using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Models
{
    public class InventoryEntity
    {
        public int WarehouseId { get; set; } // Khóa chỉnh
        public int ProductId { get; set; } // Khóa chính
        public int Quantity { get; set; }   
        public int MinQuantity { get; set; }  // Số lượng tối thiểu của sản phẩm trong kho mặc định là 10
        public int MaxQuantity { get; set; } // Số lượng tối đa của sản phẩm trong kho mặc địnhlà 10
        public DateTime LastRestocked { get; set; } = DateTime.UtcNow;

        public ProductEntity? Product { get; set; }
        public WarehouseEntity? Warehouse { get; set; }

    }
}
