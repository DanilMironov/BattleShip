namespace Battleship.Entities
{
    public class Player : IPlayer
    {
        public string Name { get; }
        public Field Field { get; }

        public Player(string name, Field field)
        {
            Name = name;
            Field = field;
        }

        IField IPlayer.Field => Field;

    }
    

}
