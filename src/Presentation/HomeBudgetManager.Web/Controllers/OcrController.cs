using HomeBudgetManager.Application.Interfaces.Services.BillOcr;
using Microsoft.AspNetCore.Mvc;

namespace HomeBudgetManager.Web.Controllers
{
    [Route("/api/[controller]/[action]")]
    public class OcrController : Controller
    {
        private readonly IBillOcrService _ocrService;

        //[HttpPost]
        //public ActionResult ExecuteOcr([FromForm] )
        //{

        //}
    }
}
