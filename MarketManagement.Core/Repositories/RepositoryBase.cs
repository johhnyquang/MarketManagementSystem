using MarketManagement.Core.DataContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
            _dbSet = _dbContext.Set<TEntity>(); 
        }

        public virtual async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
           return await _dbSet.AnyAsync(predicate);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.CountAsync(predicate);
        }

        public virtual void DeleteAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual void DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public virtual async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<TEntity?> GetWithIncludeAsync(Expression<Func<TEntity, bool>> whereClause, params Expression<Func<TEntity, object>>[] includeClause)
        {
            IQueryable<TEntity> query = _dbSet;

            // sử dụng vòng lặp cho include (phép join trong sql)
            foreach (var include in includeClause)
            {
                query = query.Include(include);
            }

            return await query.FirstOrDefaultAsync(whereClause);
        }

        public virtual async Task<IEnumerable<TEntity>> GetWithIncludesAsync(Expression<Func<TEntity, bool>>? whereClause = null, params Expression<Func<TEntity, object>>[] includeClause)
        {
            IQueryable<TEntity> query = _dbSet;

            // sử dụng vòng lặp cho include (phép join trong sql)
            foreach (var include in includeClause)
            {
                query = query.Include(include);                
            }

            // Nếu như có where thì where thêm không thì thôi
            if (whereClause != null)
            {
                query = query.Where(whereClause);
            }

            return await query.ToListAsync();
        }

        public virtual void UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);
        }
    }
}
