using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBudgetManager.Repository
{
    public interface IRepository<TEntity, TPrimaryKey>
    {
        Task<TEntity> Get(TPrimaryKey key);
        Task<IEnumerable<TEntity>> GetAll();
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        IQueryable<TEntity> Query(Func<IQueryable<TEntity>, IQueryable<TEntity>> queryExpression);
    }
}
