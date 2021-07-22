using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Entities
{

    public class Game
    {
        public GameStatus State { get; private set; }
        public PLayer FirstPlayer { get; set; }
        public PLayer SecondPlayer { get; set; }
        public bool IsFirstPlayerCurrent { get; set; }
        public PLayer GetPlayer => IsFirstPlayerCurrent ? FirstPlayer : SecondPlayer;

    }


    public interface IField
    {

    }
    public class Field : IField
    {
        public Field(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int Width { get; }
        public int Height { get; }
        public List<Ship> Ships { get; set; }
        //public List<Point> Shots { get; set; }
    
        public void AddShip(Ship ship)
        {
            throw new NotImplementedException();
        }

        public IReadOnlyList<Ship> GetShips()
        {
            throw new NotImplementedException();
        }

    }
    

}
