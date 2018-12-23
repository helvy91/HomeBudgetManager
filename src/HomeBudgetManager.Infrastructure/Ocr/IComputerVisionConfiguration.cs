namespace HomeBudgetManager.Infrastructure
{
    public interface IComputerVisionConfiguration
    {
        string SubscriptionKey { get; }
        string ApiUrl { get; }
    }
}
