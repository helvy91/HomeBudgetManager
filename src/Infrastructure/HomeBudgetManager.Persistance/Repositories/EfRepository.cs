using HomeBudgetManager.Application.Interfaces.Repositories;
using HomeBudgetManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeBudgetManager.Persistance.Repositories
{
    public class EfRepository<TEntity, TKey> : IRepository<TEntity, TKey>
        where TEntity : Entity<TKey>
    {
        protected readonly DbContext _ctx;
        protected readonly DbSet<TEntity> _dbSet;

        public EfRepository(DbContext ctx)
        {
            _ctx = ctx ?? throw new ArgumentNullException(nameof(ctx));
            _dbSet = ctx.Set<TEntity>();
        }

        public Task<TEntity> GetAsync(TKey key)
            => _dbSet.FindAsync(key);

        public async Task<IEnumerable<TEntity>> GetAllAsync()
            => await _dbSet.ToListAsync();


        public async Task AddAsync(TEntity entity)
        {
            _dbSet.Add(entity);
            await _ctx.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _ctx.Set<TEntity>().Update(entity);
            await _ctx.SaveChangesAsync();
        }

        public async Task DeleteAsync(TKey key)
        {
            var entity = await _ctx.Set<TEntity>().FindAsync(key);

            _dbSet.Remove(entity);
            await _ctx.SaveChangesAsync();
        }

        public IQueryable<T> Query<T>(Func<IQueryable<TEntity>, IQueryable<T>> queryExpression)
            => queryExpression(_dbSet.AsQueryable());
    }
}
