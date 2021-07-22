using System.Collections.Generic;

namespace Battleship.Entities
{
    public interface IShip
    {
        Direction Direction { get; }
        Point? Position { get; }
        int Size { get; }
        IReadOnlyList<Point> GetPositionPoints();
    }
    // надо где то хранить выстрелы

}
