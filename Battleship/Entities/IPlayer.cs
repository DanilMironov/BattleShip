namespace Battleship.Entities
{
    public interface IPlayer
    {
        string Name { get; }
        IField Field { get; }
    }
    

}
