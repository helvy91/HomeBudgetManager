namespace HomeBudgetManager.Domain.Entities
{
    public class User : Entity<int>
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Salt { get; set; }
    }
}
