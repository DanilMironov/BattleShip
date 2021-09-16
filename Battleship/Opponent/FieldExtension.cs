using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship.Entities;

namespace Battleship.Opponent
{
    public static class FieldExtension
    {
        private static Random randomizer = new Random();

        public static Point GenerateRandomPointToShoot(this IField field)
        {
            var shots = field.GetShots();

            for (var i = 0; i < 123; i++)
            {
                var randomX = randomizer.Next(0, field.Width);
                var randomY = randomizer.Next(0, field.Height);
                var generatedPoint = new Point(randomX, randomY);
                if (!shots.Contains(generatedPoint))
                    return generatedPoint;
            }

            for (var x = 0; x < field.Width; x++)
            {
                for (var y = 0; y < field.Height; y++)
                {
                    var point = new Point(x, y);
                    if (!shots.Contains(point))
                        return point;
                }
            }
            return new Point(0, 0);
        }

        public static bool RandomShipPlacing(this IField field)
        {
            for (var i = 0; i < 1000; i++)
            {
                field.ClearTheField();
                if (field.TryToPlaceShips(1000))
                    return true;
            }
            return false;
        }

        public static bool TryToPlaceShips(this IField field, int attempts)
        {
            for (var i = 0; i < attempts; i++)
            {
                var ship = field.GetShipToPutOrNull();

                if (ship == null)
                    break;

                var randomX = randomizer.Next(0, field.Width);
                var randomY = randomizer.Next(0, field.Height);

                field.PutShip(ship, new Point(randomX, randomY));

                if (randomizer.Next(0, 2) == 1)
                    field.ChangeDirection(ship);

                if (field.GetConflictPoints().Any())
                    field.PutShip(ship, new Point(-10, -10));
            }

            return field.GetShipToPutOrNull() == null && !field.GetConflictPoints().Any();
        }

        public static void ClearTheField(this IField field)
        {
            foreach (var ship in field.GetShips().Where(s => s.Position != null))
                field.PutShip(ship, new Point(-10, -10));
        }
    }
}
