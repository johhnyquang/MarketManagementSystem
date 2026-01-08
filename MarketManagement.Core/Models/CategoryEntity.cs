using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Models
{
    public class CategoryEntity : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int DisplayOrder { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public ICollection<ProductEntity> ProductEntities { get; set; } = new List<ProductEntity>();
    } 
}
