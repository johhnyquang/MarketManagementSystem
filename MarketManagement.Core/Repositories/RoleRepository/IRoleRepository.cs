using MarketManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Repositories.RoleRepository
{
    public interface IRoleRepository : IRepositoryBase<RoleEntity>
    {
        Task<IEnumerable<RoleEntity>> SearchAsync(string keyword);
        Task<IEnumerable<RoleEntity>> GetAllRolesAsync();
    }
}
