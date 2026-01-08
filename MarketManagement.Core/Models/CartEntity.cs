using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Models
{
    public class CartEntity : BaseEntity
    {
        public int UsertId { get; set; }

        // Navigation Properties
        public UserEntity? User { get; set; } // 1 giỏ hàng thuộc 1 user
        public ICollection<CartItemsEntity> CartItemsEntities { get; set; } = new List<CartItemsEntity>();
    }
}
