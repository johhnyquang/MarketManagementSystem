using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Models
{
    public class FunctionEntity : BaseEntity
    {
        public string FunctionCode { get; set; } = string.Empty;
        public string FunctionName { get; set; } = string.Empty;

        // Navigation Properties
        public ICollection<RoleFunctionEntity> RoleFunctionEntities { get; set; } = new List<RoleFunctionEntity>();
    }
}
