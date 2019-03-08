using System.Threading.Tasks;

namespace HomeBudgetManager.Application.Interfaces.Repositories
{
    public interface IUserRepository : IRepository<Domain.Entities.User, int>
    {
        Task<Domain.Entities.User> GetAsync(string login);
    }
}
