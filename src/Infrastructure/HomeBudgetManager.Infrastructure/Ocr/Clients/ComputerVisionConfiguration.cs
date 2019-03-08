using System.Configuration;

namespace HomeBudgetManager.Infrastructure.Clients
{
    public class ComputerVisionConfiguration : IComputerVisionConfiguration
    {
        public string ApiUrl => ConfigurationManager.AppSettings["CognitiveServices.ApiUrl"];
        public string SubscriptionKey => ConfigurationManager.AppSettings["CognitiveServices.SubscriptionKey"];
    }
}
