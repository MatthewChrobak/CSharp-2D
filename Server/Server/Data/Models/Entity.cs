namespace Server.Data.Models
{
    public enum Dir
    {
        Down,
        Left,
        Right,
        Up,
        Length
    }

    public abstract class Entity : Location
    {
    }
}
