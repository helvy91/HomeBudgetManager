using System.Threading.Tasks;

namespace HomeBudgetManager.Infrastructure
{
    public interface IComputerVisionClient
    {
        Task<TextRecognitionResult> RecognizeTextAsync(byte[] imageBuffer);
    }
}