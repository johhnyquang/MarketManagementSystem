using MarketManagement.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Repositories.ProductRepository
{
    public interface IProductRepository : IRepositoryBase<ProductEntity>
    {
        Task<IEnumerable<ProductEntity>> SearchAsync(string keyword);
        Task<IEnumerable<ProductEntity>> GetByCategoryAsync(int categoryId);
        Task<ProductEntity?> GetProductDetail(int productId);
        Task<IEnumerable<ProductEntity>> GetAllProducts();
    }
}
