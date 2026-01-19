using MarketManagement.Core.DataContext;
using MarketManagement.Core.Models;
using MarketManagement.Core.Repositories.CartRepository;
using MarketManagement.Core.Repositories.DocumentRepository;
using MarketManagement.Core.Repositories.InventoryRepository;
using MarketManagement.Core.Repositories.OrderRepository;
using MarketManagement.Core.Repositories.ProductRepository;
using MarketManagement.Core.Repositories.PurchaseOrderRepository;
using MarketManagement.Core.Repositories.RoleRepository;
using MarketManagement.Core.Repositories.UserRepository;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IRoleRepository RoleRepository { get; }
        IInventoryRepository InventoryRepository { get; }
        IProductRepository ProductRepository { get; }
        IPurchaseOrderRepository PurchaseOrderRepository { get; }
        IOrderRepository OrderRepository { get; }
        IDocumentRepository DocumentRepository { get; }
        ICartRepository CartRepository { get; }
        IRepositoryBase<CategoryEntity> CategoryRepository { get; }
        IRepositoryBase<FunctionEntity> FunctionRepository { get; }
        IRepositoryBase<MovementTypeEntity> MovementTypeRepository { get; }
        IRepositoryBase<NotificationEntity> NotificationRepository { get; }
        IRepositoryBase<SupplierEntity> SupplierRepository { get; }
        IRepositoryBase<WarehouseEntity> WarehouseRepository { get; }

        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}
