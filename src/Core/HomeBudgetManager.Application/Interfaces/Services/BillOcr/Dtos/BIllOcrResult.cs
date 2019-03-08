using System.Collections.Generic;

namespace HomeBudgetManager.Infrastructure.Services.BillOcr.Dtos
{
    public class BillOcrResult
    {
        public List<Line> Lines { get; set; }
        public List<string> SourceLines { get; set; }

        public BillOcrResult()
        {
            Lines = new List<Line>();
            SourceLines = new List<string>();
        }
    }
}
