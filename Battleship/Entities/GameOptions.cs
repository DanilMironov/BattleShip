using System.Collections.Generic;

namespace Battleship.Entities
{
    public class GameOptions
    {
        //public readonly Dictionary<int, int> Sizes = new Dictionary<int, int>
        //{
        //    { 1, 4 },
        //    { 2, 3 },
        //    { 3, 2 },
        //    { 4, 1 }
        //};
        public readonly int[] Sizes = new[] { 1, 1, 1, 1, 2, 2, 2, 3, 3, 4 };

        public int Width { get; set; } = 10;
        public int Height { get; set; } = 10;


    }
}
