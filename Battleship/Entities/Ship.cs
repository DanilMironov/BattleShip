using System.Collections.Generic;
using System.Linq;

namespace Battleship.Entities
{
    public class Ship : IShip
    {
        public int Size { get; }

        public Ship(int size)
        {
            Size = size;
        }

        public Direction Direction { get; set; } = Direction.Horizontal;

        public Point? Position { get; set; } = null;

        public IReadOnlyList<Point> GetPositionPoints()
        {
            if (Position.HasValue)
            {
                var startPoint = Position.Value;
                return Enumerable
                    .Range(0, Size)
                    .Select(d => Direction == Direction.Horizontal ? 
                        new Point(startPoint.X + d, startPoint.Y) : 
                        new Point(startPoint.X, startPoint.Y + d))
                    .ToList();
            }
            return new Point[0].ToList();
        }

    }
    // надо где то хранить выстрелы

}
