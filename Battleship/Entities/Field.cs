using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Entities
{
    public class Field: IField
    {
        private readonly HashSet<IShip> ships = new HashSet<IShip>();
        private readonly HashSet<Point> shots = new HashSet<Point>();

        public int Width { get; }
        public int Height { get; }

        public Field(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public event Action Updated;

        public void AddShip(IShip ship)
        {
            ships.Add(ship);
            Updated?.Invoke();
        }

        public IReadOnlyList<IShip> GetShips()
        {
            return ships.ToList();
        }

        public IShip GetShipToPutOrNull()
        {
            return ships
                .Where(ship => !ship.Position.HasValue)
                .OrderByDescending(ship => ship.Size)
                .FirstOrDefault();
        }

        public bool PutShip(IShip ship, Point point)
        {
            if (!ships.Contains(ship))
                throw new InvalidOperationException();
            
            var currentShip = (Ship)ship;
            var dx = 1;
            var dy = 1;

            if (ship.Direction == Direction.Horizontal)
                dx = currentShip.Size;
            else
                dy = currentShip.Size;
            
            if (point.X >= 0 && point.X + dx <= Width && 
                point.Y >= 0 && point.Y + dy <= Height)
            {
                currentShip.Position = point;
                Updated?.Invoke();
                return true;
            }
            currentShip.Position = null;
            Updated?.Invoke();
            return false;
        }

        public IReadOnlyList<IShip> GetShipsAtPoint(Point point)
        {
            return ships
                .Where(ship => ship.GetPositionPoints().Contains(point))
                .OrderBy(ship => ship.Size)
                .ToList();
        }
        
        //должно и так работать по идее
        public IShip GetShipAtPoint(Point point)
        {
            return ships
                .Where(ship => ship.GetPositionPoints().Contains(point))
                .FirstOrDefault();
        }

        public bool ChangeDirection(IShip ship)
        {
            if (!ships.Contains(ship))
                throw new InvalidOperationException();

            var currentShip = (Ship)ship;

            if (!currentShip.Position.HasValue)
                return false;

            var initialPosition = currentShip.Position.Value;

            if (currentShip.Direction == Direction.Horizontal)
            {
                var overage = initialPosition.Y + currentShip.Size - Height;
                if (overage > 0)
                {
                    var newPosition = new Point(initialPosition.X, initialPosition.Y - overage);
                    if (newPosition.Y < 0)
                    {
                        currentShip.Position = null;
                        Updated?.Invoke();
                        return false;
                    }
                    currentShip.Position = newPosition;
                }
                currentShip.Direction = Direction.Vertical;
            }
            else
            {
                var overage = initialPosition.X + currentShip.Size - Width;
                if (overage > 0)
                {
                    var newPosition = new Point(initialPosition.X - overage, initialPosition.Y);
                    if (newPosition.X < 0)
                    {
                        currentShip.Position = null;
                        Updated?.Invoke();
                        return false;
                    }
                    currentShip.Position = newPosition;
                }
                currentShip.Direction = Direction.Horizontal;
            }
            Updated?.Invoke();
            return true;
        }

        public HashSet<Point> GetShipAroundPoints(IShip ship)
        {
            return ship
                .GetPositionPoints()
                .SelectMany(point => point.GetPointsAround())
                .Where(p => p.X > 0 && p.X < Width && p.Y > 0 && p.Y < Height)
                .ToHashSet();
        }

        public ISet<Point> GetConflictPoints()
        {
            var ShipToSurroundingsMap = ships
                .ToDictionary(ship => ship, GetShipAroundPoints);

            var res = new HashSet<Point>();
            
            foreach (var ship in ships)
            {
                var shipPositionPoints = ship.GetPositionPoints();
                foreach (var point in shipPositionPoints)
                {
                    var isPointAroundAnotherShip = ShipToSurroundingsMap
                        .Any(pair => !pair.Key.Equals(ship) && pair.Value.Contains(point));
                    if (isPointAroundAnotherShip)
                        res.Add(point);
                }
            }
            return res;
        }

        public ShotResult Shoot(Point point)
        {
            if (shots.Contains(point))
                return ShotResult.Triggered;  // типа если мы уже сюда стреляли

            shots.Add(point);

            var ship = GetShipsAtPoint(point)
                .FirstOrDefault();
            
            if (ship == null)
            {
                Updated?.Invoke();
                return ShotResult.Miss;
            }

            var shipMustExplode = ship.GetPositionPoints()
                .All(point => shots.Contains(point));

            if (shipMustExplode)
                shots.UnionWith(GetShipAroundPoints(ship));

            Updated?.Invoke();
            return ShotResult.Hit;
        }

        public ISet<Point> GetShots()
        {
            return shots;
        }

        public bool IsAlive(IShip ship)
        {
            if (!ships.Contains(ship))
                throw new InvalidCastException();
            return !ship.GetPositionPoints()
                .All(point => shots.Contains(point));
        }

        public bool HasAliveShips()
        {
            return ships
                .Any(ship => IsAlive(ship));
        }
    }
}
