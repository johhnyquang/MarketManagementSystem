using MarketManagement.Core.Enums;
using MarketManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Repositories.PurchaseOrderRepository
{
    public interface IPurchaseOrderRepository : IRepositoryBase<PurchaseOrderEntity>
    {
        Task<bool> ExistByPurchaseOrderAsync(string purchaseOrderNumber);
        //Task<bool> CheckUserCreateNewPO(int userId);
        Task<PurchaseOrderEntity?> GetPurchaseOrderDetailAsync(string purchaseOrderNumber);
        Task<IEnumerable<PurchaseOrderEntity>> GetPurchaseOrdersWithStatusAsync(PurchaseStatus status);
    }
}
