using MarketManagement.Core.DataContext;
using MarketManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Repositories.CartRepository
{
    public class CartRepository(AppDbContext appDbContext) : RepositoryBase<CartEntity>(appDbContext), ICartRepository
    {
        public async Task<CartEntity?> GetCartDetailAsync(int cartId)
        {
           return await GetWithIncludeAsync(cart => cart.Id == cartId, cart1 => cart1.User!, cart2 => cart2.CartItemsEntities);
        }

    }
}
