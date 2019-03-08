using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HomeBudgetManager.Domain.Entities;
using HomeBudgetManager.Persistance.Configurations;
using Microsoft.EntityFrameworkCore;

namespace HomeBudgetManager.Persistance
{
    public class HomeBudgetManagerDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public HomeBudgetManagerDbContext(DbContextOptions<HomeBudgetManagerDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var now = DateTime.Now;

            var created = ChangeTracker.Entries().Where(x => x.State == EntityState.Added);
            foreach (var entity in created)
            {
                entity.Property("CreatedAt").CurrentValue = now;
                entity.Property("ModifiedAt").CurrentValue = now;
            }

            var modified = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);
            foreach (var entity in modified)
            {
                entity.Property("ModifiedAt").CurrentValue = now;
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
