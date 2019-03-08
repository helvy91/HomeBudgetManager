using HomeBudgetManager.Application.Interfaces.Services;
using HomeBudgetManager.Application.Interfaces.Services.User.Dtos;
using HomeBudgetManager.Application.Services.Base;
using Microsoft.Extensions.Logging;

namespace HomeBudgetManager.Web.Controllers
{
    public class UserController : BaseController<IUserService, int, UserDto, CreateUserDto, CreateUserDto, GetPagedDto>
    {
        public UserController(IUserService userService, ILogger<UserController> logger) : base(userService, logger) { }
    }
}
