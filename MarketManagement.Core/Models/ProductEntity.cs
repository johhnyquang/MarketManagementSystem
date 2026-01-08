using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Models
{
    public class ProductEntity : BaseEntity
    {
        public string SKU { get; set; } = string.Empty;
        public string ProductName { get; set; } = string.Empty;
        public string ProductDescription { get; set; } = string.Empty;
        public decimal Price { get; set; }  
        public string ImageUrl { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
        public float Rating { get; set; }
        public int CategoryId { get; set; }


        // Navigation Properties
        public CategoryEntity? Category { get; set; }
        public ICollection<InventoryEntity> InventoryEntities { get; set; } = new List<InventoryEntity>();
        public ICollection<PurchaseOrderItemsEntity> PurchaseOrderItemsEntities { get; set; } = new List<PurchaseOrderItemsEntity>();
        public ICollection<DocumentDetailEntity> DocumentDetailEntities { get; set; } = new List<DocumentDetailEntity>();
        public ICollection<OrderItemsEntity> OrderItemsEntities { get; set; } = new List<OrderItemsEntity>();
        public ICollection<CartItemsEntity> CartItemsEntities { get; set; } = new List<CartItemsEntity>();
    }
}
