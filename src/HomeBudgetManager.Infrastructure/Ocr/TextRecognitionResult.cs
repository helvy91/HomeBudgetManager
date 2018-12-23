using System.Collections.Generic;

namespace HomeBudgetManager.Infrastructure
{
    public class TextRecognitionResult
    {
        public List<TextRecognitionLine> Lines { get; set; }

        public TextRecognitionResult()
        {
            Lines = new List<TextRecognitionLine>();
        }
    }
}
