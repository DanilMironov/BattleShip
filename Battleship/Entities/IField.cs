using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Entities
{
    public interface IField
    {
        int Height { get; }
        int Width { get; }

        bool ChangeDirection(IShip ship);
        ISet<Point> GetConflictPoints();
        IReadOnlyList<IShip> GetShips();
        IReadOnlyList<IShip> GetShipsAtPoint(Point point);
        IShip GetShipToPutOrNull();
        ISet<Point> GetShots();
        bool HasAliveShips();
        bool IsAlive(IShip ship);
        bool PutShip(IShip ship, Point point);
        ShotResult Shoot(Point point);

        event Action Updated;
    }
}
