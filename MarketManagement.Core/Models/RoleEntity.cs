using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Models
{
    public class RoleEntity : BaseEntity
    {
        public string RoleName { get; set; } = string.Empty;

        // Navigation Properties
        public ICollection<UserEntity> UserEntities { get; set; } = new List<UserEntity>();
        public ICollection<RoleFunctionEntity> RoleFunctionEntities { get; set; } = new List<RoleFunctionEntity>();
    }
}
