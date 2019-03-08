using System.Collections.Generic;

namespace HomeBudgetManager.Infrastructure.Clients.Dtos
{
    public class Line
    {
        public string Text { get; set; }
        public BoundingBox BoundingBox { get; set; }
        public List<Word> Words { get; set; }

        public Line()
        {
            Words = new List<Word>();
        }
    }
}
