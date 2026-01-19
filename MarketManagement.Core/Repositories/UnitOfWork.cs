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
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IDbContextTransaction? _transaction;

        public UnitOfWork(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context)); 
        }

        private IUserRepository? _userRepository;
        public IUserRepository UserRepository => _userRepository ??= new UserRepository.UserRepository(_context);

        private IRoleRepository? _roleRepository;
        public IRoleRepository RoleRepository => _roleRepository ??= new RoleRepository.RoleRepository(_context);

        private IInventoryRepository? _inventoryRepository;
        public IInventoryRepository InventoryRepository => _inventoryRepository ??= new InventoryRepository.InventoryRepository(_context);

        private IProductRepository? _productRepository;
        public IProductRepository ProductRepository => _productRepository ??= new ProductRepository.ProductRepository(_context);

        private IPurchaseOrderRepository? _purchaseOrderRepository;
        public IPurchaseOrderRepository PurchaseOrderRepository => _purchaseOrderRepository ??= new PurchaseOrderRepository.PurchaseOrderRepository(_context);

        private IOrderRepository? _orderRepository;
        public IOrderRepository OrderRepository => _orderRepository ??= new OrderRepository.OrderRepository(_context);

        private IDocumentRepository? _documentRepository;
        public IDocumentRepository DocumentRepository => _documentRepository ??= new DocumentRepository.DocumentRepository(_context);

        private ICartRepository? _cartRepository;
        public ICartRepository CartRepository => _cartRepository ??= new CartRepository.CartRepository(_context);

        private IRepositoryBase<CategoryEntity>? _categoryRepository;
        public IRepositoryBase<CategoryEntity> CategoryRepository => _categoryRepository ??= new Repositories.RepositoryBase<CategoryEntity>(_context);

        private IRepositoryBase<FunctionEntity>? _functionRepository;
        public IRepositoryBase<FunctionEntity> FunctionRepository => _functionRepository ??= new Repositories.RepositoryBase<FunctionEntity>(_context);

        private IRepositoryBase<MovementTypeEntity>? _movementTypeRepository;
        public IRepositoryBase<MovementTypeEntity> MovementTypeRepository => _movementTypeRepository ??= new Repositories.RepositoryBase<MovementTypeEntity>(_context);

        private IRepositoryBase<NotificationEntity>? _notificationRepository;
        public IRepositoryBase<NotificationEntity> NotificationRepository => _notificationRepository ??= new Repositories.RepositoryBase<NotificationEntity>(_context);

        private IRepositoryBase<SupplierEntity>? _supplierRepository;
        public IRepositoryBase<SupplierEntity> SupplierRepository => _supplierRepository ??= new Repositories.RepositoryBase<SupplierEntity>(_context);

        private IRepositoryBase<WarehouseEntity>? _warehouseRepository;
        public IRepositoryBase<WarehouseEntity> WarehouseRepository => _warehouseRepository ??= new Repositories.RepositoryBase<WarehouseEntity>(_context);

        public async Task BeginTransactionAsync()
        {
            if (_transaction != null)
            {
                throw new InvalidOperationException("Transaction đã tồn tại");
            }
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction == null)
            {
                throw new InvalidOperationException("Chưa có transaction nào được khởi tạo");
            }

            try
            {
                await SaveChangesAsync();
                if (_transaction != null)
                {
                    await _transaction.CommitAsync();
                }
            }
            catch 
            {
                await RollbackTransactionAsync();
                throw;
            }
            finally
            {
                if (_transaction != null)
                {
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync(); 
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
