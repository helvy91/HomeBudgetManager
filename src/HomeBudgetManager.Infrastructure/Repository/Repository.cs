using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HomeBudgetManager.Repository;
using Microsoft.EntityFrameworkCore;

namespace HomeBudgetManager.Infrastructure.Repository
{
    public class Repository<TEntity, TPrimaryKey> : IRepository<TEntity, TPrimaryKey>
        where TEntity : class
    {
        private readonly DbContext _ctx;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext ctx)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
            _dbSet = ctx.Set<TEntity>();
        }


        public Task<TEntity> Get(TPrimaryKey key)
            => _dbSet.FindAsync(key);

        public async Task<IEnumerable<TEntity>> GetAll()
            => await _dbSet.ToListAsync();


        public async Task Add(TEntity entity)
        {
            _dbSet.Add(entity);
            await _ctx.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            _ctx.Entry(entity).State = EntityState.Modified;
            await _ctx.SaveChangesAsync();
        }

        public async Task Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            await _ctx.SaveChangesAsync();
        }

        public IQueryable<TEntity> Query(Func<IQueryable<TEntity>, IQueryable<TEntity>> queryExpression)
            => queryExpression(_dbSet.AsQueryable());
    }
}
