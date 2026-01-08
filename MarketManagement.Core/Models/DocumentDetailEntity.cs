using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Models
{
    public class DocumentDetailEntity
    {
        public int DocumentHeaderId { get; set; }
        public int ProductId { get; set; }  
        public int QuantityOrdered { get; set; }
        public int QuantityPhysical { get; set; }

        // Navigation Properties
        public DocumentHeaderEntity? DocumentHeaderEntity { get; set; }
        public ProductEntity? ProductEntity { get; set; }
    }
}
