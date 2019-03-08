namespace HomeBudgetManager.Infrastructure.Clients
{
    public interface IComputerVisionConfiguration
    {
        string SubscriptionKey { get; }
        string ApiUrl { get; }
    }
}
