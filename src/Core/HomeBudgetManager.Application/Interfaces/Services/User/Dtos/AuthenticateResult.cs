
namespace HomeBudgetManager.Application.Interfaces.Services.User.Dtos
{
    public class AuthenticateResult
    {
        public bool Success { get; set; }
        public Domain.Entities.User User { get; set; }
    }
}
