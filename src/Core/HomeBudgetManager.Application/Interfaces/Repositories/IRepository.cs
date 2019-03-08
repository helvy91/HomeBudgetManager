using HomeBudgetManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBudgetManager.Application.Interfaces.Repositories
{
    public interface IRepository<TEntity, TKey>
        where TEntity : Entity<TKey>
    { 
        Task<TEntity> GetAsync(TKey key);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TKey key);
        IQueryable<T> Query<T>(Func<IQueryable<TEntity>, IQueryable<T>> queryExpression);
    }
}
