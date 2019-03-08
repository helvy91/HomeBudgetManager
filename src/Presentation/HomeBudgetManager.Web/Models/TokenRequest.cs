using HomeBudgetManager.Application.Interfaces.Services.User.Dtos;
using System.ComponentModel.DataAnnotations;

namespace HomeBudgetManager.Web.Models
{
    public class TokenRequest
    {
        [Required] public CreateUserDto User { get; set; }
        [Required] public TokenRequestType RequestType { get; set; }
    }
}
