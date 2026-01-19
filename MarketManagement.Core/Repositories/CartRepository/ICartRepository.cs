using MarketManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Repositories.CartRepository
{
    public interface ICartRepository : IRepositoryBase<CartEntity>
    {
        Task<CartEntity?> GetCartDetailAsync(int cartId);
    }
}
