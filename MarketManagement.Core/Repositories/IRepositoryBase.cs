using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MarketManagement.Core.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<TEntity?> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity?> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetWithIncludesAsync(Expression<Func<TEntity, bool>>? whereClause = null, params Expression<Func<TEntity, object>>[] includeClause);
        Task<TEntity?> GetWithIncludeAsync(Expression<Func<TEntity, bool>> whereClause, params Expression<Func<TEntity, object>>[] includeClause);

        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void DeleteAsync(TEntity entity);
        void DeleteRangeAsync(IEnumerable<TEntity> entities);
        void UpdateAsync(TEntity entity);
    }
}
