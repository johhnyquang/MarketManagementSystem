using MarketManagement.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.DataContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Db Set
        #region Authentication and Authorization
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<FunctionEntity> Functions { get; set; }
        public DbSet<RoleFunctionEntity> RoleFunctions { get; set; }
        #endregion

        #region Master Data
        public DbSet<CategoryEntity> Categories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }
        public DbSet<SupplierEntity> Suppliers { get; set; }
        public DbSet<WarehouseEntity> Warehouses { get; set; }
        public DbSet<MovementTypeEntity> MovementTypes { get; set; }
        #endregion

        #region Transaction
        public DbSet<PurchaseOrderEntity> PurchaseOrders { get; set; }
        public DbSet<PurchaseOrderItemsEntity> PurchaseOrderItems { get; set; }
        public DbSet<InventoryEntity> Inventories { get; set; }
        public DbSet<CartEntity> Carts { get; set; }
        public DbSet<CartItemsEntity> CartItems { get; set; }
        public DbSet<DocumentHeaderEntity> DocumentHeaders { get; set; }
        public DbSet<DocumentDetailEntity> DocumentDetails { get; set; }
        public DbSet<DocumentTransactionEntity> DocumentTransactions { get; set; }
        public DbSet<OrderEntity> Orders { get; set; }
        public DbSet<OrderItemsEntity> OrderItems { get; set; }
        #endregion

        #region Notification
        public DbSet<NotificationEntity> Notifications { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Đọc các configuration trong cùng 1 assembly là IEntityTypeConfiguration 
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
