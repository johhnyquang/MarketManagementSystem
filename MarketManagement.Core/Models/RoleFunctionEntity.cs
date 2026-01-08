using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Models
{
    public class RoleFunctionEntity
    {
        public int RoleId { get; set; }
        public int FunctionId { get; set; }
        public bool IsActive { get; set; } = false;

        // Navigation Properties
        public FunctionEntity? Function { get; set; }
        public RoleEntity? Role { get; set; } 
    }
}
