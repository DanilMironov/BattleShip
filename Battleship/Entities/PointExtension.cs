using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Entities
{
    public static class PointExtension
    {
        public static IEnumerable<Point> GetPointsAround(this Point point)
        {
            for (var dx = -1; dx <= 1; dx++)
                for (var dy = -1; dy <= 1; dy++)
                    yield return new Point(point.X + dx, point.Y + dy);
        }
    }
}
