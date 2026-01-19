using MarketManagement.Core.DataContext;
using MarketManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Repositories.ProductRepository
{
    public class ProductRepository : RepositoryBase<ProductEntity>, IProductRepository
    {
        public ProductRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public async Task<IEnumerable<ProductEntity>> GetAllProducts()
        {
            return await FindAsync(p => p.IsActive == true);
        }

        public async Task<IEnumerable<ProductEntity>> GetByCategoryAsync(int categoryId)
        {
            return await GetWithIncludesAsync(p => p.CategoryId == categoryId, p => p.Category!);
        }

        public async Task<ProductEntity?> GetProductDetail(int productId)
        {
            return await GetWithIncludeAsync(p => p.Id == productId, p => p.Category!, p => p.InventoryEntities);
        }

        public async Task<IEnumerable<ProductEntity>> SearchAsync(string keyword)
        {
            return await GetWithIncludesAsync(p => p.ProductName.Contains(keyword) || p.ProductDescription.Contains(keyword), 
                                              p => p.Category!, p => p.InventoryEntities);
        }
    }
}
