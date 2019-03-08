using HomeBudgetManager.Infrastructure.Clients.Dtos;
using System.Threading.Tasks;

namespace HomeBudgetManager.Infrastructure.Clients
{
    public interface IComputerVisionClient
    {
        Task<TextRecognitionResult> RecognizeTextAsync(byte[] imageBuffer);
    }
}