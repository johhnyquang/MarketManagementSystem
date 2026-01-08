using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Models
{
    public class WarehouseEntity : BaseEntity
    {
        public string WarehouseCode { get; set; } = string.Empty;
        public string WarehouseName { get; set; } = string.Empty;
        public string WarehouseAddress { get; set; } = string.Empty;

        // Dựa vào Vị trí của kho sẽ điều hướng shipper tới lấy và giao cho khách 
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        // Navigation Properties
        public ICollection<UserEntity> UserEntities { get; set; } = new List<UserEntity>();
        public ICollection<InventoryEntity> InventoryEntities { get; set; } = new List<InventoryEntity>();

    }
}
