using MarketManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Repositories.UserRepository
{
    public interface IUserRepository : IRepositoryBase<UserEntity>
    {
        Task<UserEntity?> GetUserByEmailAsync(string email);
        Task<UserEntity?> GetExternalIdAsync(string externalId);

        Task<bool> IsEmailExistAsync(string email);
        Task<IEnumerable<UserEntity>> GetUsersByRole(int roleId);
        Task<IEnumerable<UserEntity>> GetUserByWarehouseAsync(string warehouseId);
    }
}
