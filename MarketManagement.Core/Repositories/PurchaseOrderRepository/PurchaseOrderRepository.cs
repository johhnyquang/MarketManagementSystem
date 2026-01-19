using MarketManagement.Core.DataContext;
using MarketManagement.Core.Enums;
using MarketManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Repositories.PurchaseOrderRepository
{
    public class PurchaseOrderRepository(AppDbContext appDbContext) : RepositoryBase<PurchaseOrderEntity>(appDbContext), IPurchaseOrderRepository
    {
        public async Task<bool> ExistByPurchaseOrderAsync(string purchaseOrderNumber)
        {
            return await AnyAsync(po => po.PurchaseOrderNumber.Equals(purchaseOrderNumber));
        }

        public async Task<PurchaseOrderEntity?> GetPurchaseOrderDetailAsync(string purchaseOrderNumber)
        {
            return await GetWithIncludeAsync(po => po.PurchaseOrderNumber.Equals(purchaseOrderNumber), po1 => po1.SupplierEntity!, po2 => po2.UserEntity!, po3 => po3.PurchaseOrderItemsEntities);
        }

        public async Task<IEnumerable<PurchaseOrderEntity>> GetPurchaseOrdersWithStatusAsync(PurchaseStatus status)
        {
            return await FindAsync(po => po.PurchaseStatus == status);
        }
    }
}
