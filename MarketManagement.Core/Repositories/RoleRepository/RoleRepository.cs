using MarketManagement.Core.DataContext;
using MarketManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Repositories.RoleRepository
{
    public class RoleRepository(AppDbContext appDbContext) : RepositoryBase<RoleEntity>(appDbContext), IRoleRepository
    {
        public async Task<IEnumerable<RoleEntity>> GetAllRolesAsync()
        {
            return await GetWithIncludesAsync(null, r => r.RoleFunctionEntities);
        }

        public async Task<IEnumerable<RoleEntity>> SearchAsync(string keyword)
        {
            return await GetWithIncludesAsync(r => r.RoleName.Contains(keyword), r => r.RoleFunctionEntities);
        }
    }
}
