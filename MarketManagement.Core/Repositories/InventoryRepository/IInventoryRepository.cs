using MarketManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Repositories.InventoryRepository
{
    public interface IInventoryRepository : IRepositoryBase<InventoryEntity>
    {
        Task<IEnumerable<InventoryEntity>> GetWarehouseLowStockProductAsync(int warehouseId);
        Task<IEnumerable<InventoryEntity>> GetWarehouseMaxStockProductAsync(int warehouseId);
        Task<int> TotalQuantityStockProductInSystem(int productId); // hàm này dùng để tính toàn bộ sản phẩm trong hệ thống 
        Task<bool> CheckStockAvailabilitiesAsync(int productId, int quantity);
        Task<IEnumerable<InventoryEntity>> GetProductQuantityForecastWithWarehouseAsync(int warehouseId, int productId); // Hàm này để lấy ra quantity forecast các hàng hóa đã được đặt trước đó hoặc là chưa xuất kho (shipper có thể chưa đến lấy hàng)
        Task<IEnumerable<InventoryEntity>> GetProductInWarehouseAsync(int warehouseId);
    }
}
