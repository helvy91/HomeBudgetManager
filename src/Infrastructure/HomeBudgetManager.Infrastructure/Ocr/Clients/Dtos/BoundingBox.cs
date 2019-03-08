using System;
using System.Collections.Generic;

namespace HomeBudgetManager.Infrastructure.Clients.Dtos
{
    public class BoundingBox
    {
        public Point PointA { get; set; }
        public Point PointB { get; set; }
        public Point PointC { get; set; }
        public Point PointD { get; set; }

        public static BoundingBox Create(List<int> coordinates)
        {
            if (coordinates.Count != 8)
            {
                throw new ArgumentException(
                    "There must be eight coordinate points to create bounding box,",
                    nameof(coordinates));
            }

            return new BoundingBox()
            {
                PointA = new Point() { X = coordinates[0], Y = coordinates[1] },
                PointB = new Point() { X = coordinates[2], Y = coordinates[3] },
                PointC = new Point() { X = coordinates[4], Y = coordinates[5] },
                PointD = new Point() { X = coordinates[6], Y = coordinates[7] }
            };
        }
    }
}
