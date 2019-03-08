using HomeBudgetManager.Application.Services.Base;
using System.ComponentModel.DataAnnotations;

namespace HomeBudgetManager.Application.Interfaces.Services.User.Dtos
{
    public class CreateUserDto : EntityDto<int>
    {
        [Required] public string Login { get; set; }
        [Required] public string Password { get; set; }
        [Required] public string Email { get; set; }
    }
}
