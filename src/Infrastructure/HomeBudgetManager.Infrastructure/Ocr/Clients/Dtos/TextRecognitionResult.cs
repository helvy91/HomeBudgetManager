using System.Collections.Generic;

namespace HomeBudgetManager.Infrastructure.Clients.Dtos
{
    public class TextRecognitionResult
    {
        public List<Line> Lines { get; set; }

        public TextRecognitionResult()
        {
            Lines = new List<Line>();
        }
    }
}
