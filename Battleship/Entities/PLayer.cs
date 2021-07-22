namespace Battleship.Entities
{
    public class PLayer : IPlayer
    {
        public string Name { get; }
        public Field Field { get; }

        public PLayer(string name, Field field)
        {
            Name = name;
            Field = field;
        }

        IField IPlayer.Field => Field;

    }
    

}
