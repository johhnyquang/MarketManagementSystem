using MarketManagement.Core.DataContext;
using MarketManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Repositories.InventoryRepository
{
    public class InventoryRepository(AppDbContext appDbContext) : RepositoryBase<InventoryEntity>(appDbContext), IInventoryRepository
    {
        public async Task<bool> CheckStockAvailabilitiesAsync(int productId, int quantity)
        {
            var product = await FirstOrDefaultAsync(inv => inv.ProductId == productId);
            return product!.MinQuantity < quantity && product!.MaxQuantity > quantity;
        }

        public async Task<IEnumerable<InventoryEntity>> GetProductInWarehouseAsync(int warehouseId)
        {
            return await FindAsync(inv => inv.WarehouseId == warehouseId);
        }

        public Task<IEnumerable<InventoryEntity>> GetProductQuantityForecastWithWarehouseAsync(int warehouseId, int productId)
        {
            throw new NotImplementedException();
            // sử dụng SQL để lấy lên dư liệu
        }

        public async Task<IEnumerable<InventoryEntity>> GetWarehouseLowStockProductAsync(int warehouseId)
        {
            var products = await GetWithIncludesAsync(inv => inv.WarehouseId == warehouseId, inv1 => inv1.Product!, inv2 => inv2.Warehouse!);
            return products.Where(inv => inv.MinQuantity >= inv.Quantity);
        }

        public async Task<IEnumerable<InventoryEntity>> GetWarehouseMaxStockProductAsync(int warehouseId)
        {
            var products = await GetWithIncludesAsync(inv => inv.WarehouseId == warehouseId, inv1 => inv1.Product!, inv2 => inv2.Warehouse!);
            return products.Where(inv => inv.MaxQuantity <= inv.Quantity);
        }

        public async Task<int> TotalQuantityStockProductInSystem(int productId)
        {
            return await CountAsync(inv => inv.ProductId == productId);
        }
    }
}
