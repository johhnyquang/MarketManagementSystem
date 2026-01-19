using MarketManagement.Core.Enums;
using MarketManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Repositories.OrderRepository
{
    public interface IOrderRepository : IRepositoryBase<OrderEntity>
    {
        Task<IEnumerable<OrderEntity>> GetOrdersWithStatusAsync(OrderStatus status);
        Task<int> GetTodayOrderCountAsync();
        Task<IEnumerable<OrderEntity>> GetUserOrdersAsync(int? userId);
        Task<OrderEntity?> GetWithDetailAsync(string orderNumber);
        Task<int> GetTotalSalesByRangeAsync(DateTime from, DateTime to); // tính tổng doanh thu trong khoảng
    }
}
