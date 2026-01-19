using MarketManagement.Core.DataContext;
using MarketManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Repositories.UserRepository
{
    public class UserRepository(AppDbContext appDbContext) : RepositoryBase<UserEntity>(appDbContext), IUserRepository
    {
        public async Task<UserEntity?> GetExternalIdAsync(string externalId)
        {
            return await FirstOrDefaultAsync(u => u.ExternalIDLogin == externalId);
        }

        public async Task<UserEntity?> GetUserByEmailAsync(string email)
        {
            return await FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<IEnumerable<UserEntity>> GetUserByWarehouseAsync(string warehouseId)
        {
            return await GetWithIncludesAsync(u => u.Warehouse!.WarehouseCode.Equals(warehouseId), u => u.Warehouse!);
        }

        public async Task<IEnumerable<UserEntity>> GetUsersByRole(int roleId)
        {
            return await FindAsync(u => u.RoleId == roleId);
        }

        public async Task<bool> IsEmailExistAsync(string email)
        {
            return await AnyAsync(u => u.Email == email);
        }
    }
}
