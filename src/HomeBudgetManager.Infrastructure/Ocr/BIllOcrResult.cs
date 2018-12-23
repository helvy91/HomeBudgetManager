using System.Collections.Generic;

namespace HomeBudgetManager.Infrastructure
{
    public class BillOcrResult
    {
        public List<BillOcrLine> Lines { get; set; }
        public List<string> SourceLines { get; set; }

        public BillOcrResult()
        {
            Lines = new List<BillOcrLine>();
            SourceLines = new List<string>();
        }
    }
}
