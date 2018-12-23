using System.Collections.Generic;

namespace HomeBudgetManager.Infrastructure
{
    public class TextRecognitionLine
    {
        public string Text { get; set; }
        public BoundingBox BoundingBox { get; set; }
        public List<TextRecognitionWord> Words { get; set; }

        public TextRecognitionLine()
        {
            Words = new List<TextRecognitionWord>();
        }
    }
}
