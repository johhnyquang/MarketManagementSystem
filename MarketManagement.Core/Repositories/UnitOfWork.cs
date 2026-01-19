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

        public UnitOfWork(AppDbContext _context)
        {
            this._context = _context;

            UserRepository = new UserRepository.UserRepository(_context);
            RoleRepository = new RoleRepository.RoleRepository(_context);
            InventoryRepository = new InventoryRepository.InventoryRepository(_context);
            ProductRepository = new ProductRepository.ProductRepository(_context);
            PurchaseOrderRepository = new PurchaseOrderRepository.PurchaseOrderRepository(_context);
            OrderRepository = new OrderRepository.OrderRepository(_context);
            DocumentRepository = new DocumentRepository.DocumentRepository(_context);
            CartRepository = new CartRepository.CartRepository(_context);
            CategoryRepository = new Repositories.RepositoryBase<CategoryEntity>(_context);
            FunctionRepository = new Repositories.RepositoryBase<FunctionEntity>(_context);
            MovementTypeRepository = new Repositories.RepositoryBase<MovementTypeEntity>(_context);
            NotificationRepository = new Repositories.RepositoryBase<NotificationEntity> (_context);
            SupplierRepository = new Repositories.RepositoryBase<SupplierEntity>(_context);
            WarehouseRepository = new Repositories.RepositoryBase<WarehouseEntity>(_context);
        }
        public IUserRepository UserRepository { get; }

        public IRoleRepository RoleRepository { get; }

        public IInventoryRepository InventoryRepository { get; }

        public IProductRepository ProductRepository { get; }

        public IPurchaseOrderRepository PurchaseOrderRepository { get; }

        public IOrderRepository OrderRepository { get; }

        public IDocumentRepository DocumentRepository { get; }

        public ICartRepository CartRepository { get; }

        public IRepositoryBase<CategoryEntity> CategoryRepository { get; }

        public IRepositoryBase<FunctionEntity> FunctionRepository { get; }

        public IRepositoryBase<MovementTypeEntity> MovementTypeRepository { get; }

        public IRepositoryBase<NotificationEntity> NotificationRepository { get; }

        public IRepositoryBase<SupplierEntity> SupplierRepository { get; }

        public IRepositoryBase<WarehouseEntity> WarehouseRepository { get; }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
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
