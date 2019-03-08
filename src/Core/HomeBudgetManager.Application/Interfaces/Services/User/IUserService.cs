using HomeBudgetManager.Application.Interfaces.Services.Base;
using HomeBudgetManager.Application.Interfaces.Services.User.Dtos;
using HomeBudgetManager.Application.Services.Base;
using System.Threading.Tasks;

namespace HomeBudgetManager.Application.Interfaces.Services
{
    public interface IUserService : IBaseService<int, UserDto, CreateUserDto, CreateUserDto, GetPagedDto>
    {
        Task<AuthenticateResult> AuthenticateAsync(CreateUserDto dto);
    }
}
