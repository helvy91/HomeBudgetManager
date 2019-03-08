using System.Threading.Tasks;
using HomeBudgetManager.Infrastructure.Services.BillOcr.Dtos;

namespace HomeBudgetManager.Application.Interfaces.Services.BillOcr
{
    public interface IBillOcrService
    {
        Task<BillOcrResult> GetBillOcrResult(byte[] imageBuffer);
    }
}