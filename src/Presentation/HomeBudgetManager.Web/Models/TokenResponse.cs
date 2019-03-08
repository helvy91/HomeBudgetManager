namespace HomeBudgetManager.Web.Models
{
    public class TokenResponse
    {
        public string Token { get; set; }
        public int Expiration { get; set; }
        public string RefreshToken { get; set; }
    }
}
