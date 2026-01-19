using MarketManagement.Core.DataContext;
using MarketManagement.Core.Enums;
using MarketManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Repositories.OrderRepository
{
    public class OrderRepository(AppDbContext appDbContext) : RepositoryBase<OrderEntity>(appDbContext), IOrderRepository
    {
        public async Task<IEnumerable<OrderEntity>> GetOrdersWithStatusAsync(OrderStatus status)
        {
            return await FindAsync(o => o.OrderStatus == status);
        }

        public async Task<int> GetTodayOrderCountAsync()
        {
            DateTime today = DateTime.Now;
            return await CountAsync(o => o.ConfirmedAt == today);
        }

        public Task<int> GetTotalSalesByRangeAsync(DateTime from, DateTime to)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderEntity>> GetUserOrdersAsync(int? userId)
        {
            return await FindAsync(o => o.UserId == userId);
        }

        public async Task<OrderEntity?> GetWithDetailAsync(string orderNumber)
        {
            return await GetWithIncludeAsync(o => o.OrderNumber.Equals(orderNumber), o => o.Customer!, o => o.Shipper!, o => o.OrderItemsEntities);
        }
    }
}
