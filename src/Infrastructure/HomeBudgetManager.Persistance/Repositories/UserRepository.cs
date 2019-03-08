using System.Linq;
using System.Threading.Tasks;
using HomeBudgetManager.Application.Interfaces.Repositories;
using HomeBudgetManager.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HomeBudgetManager.Persistance.Repositories
{
    public class UserRepository : EfRepository<User, int>, IUserRepository
    {
        public UserRepository(HomeBudgetManagerDbContext ctx) : base(ctx) { }

        public async Task<User> GetAsync(string login)
        {
            return await Query(x => x.Where(y => y.Login == login))
                .SingleOrDefaultAsync();
        }
    }
}
