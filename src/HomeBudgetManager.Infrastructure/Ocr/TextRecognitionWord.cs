using System.Collections.Generic;

namespace HomeBudgetManager.Infrastructure
{
    public class TextRecognitionWord
    {
        public string Text { get; set; }
        public BoundingBox BoundingBox { get; set; }
    }
}
