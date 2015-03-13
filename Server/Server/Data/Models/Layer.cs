namespace Server.Data.Models
{
    public enum MapLayers
    {
        Ground,
        Mask1,
        Mask2,
        Fringe1,
        Fringe2,
        Length
    }

    public class Layer
    {
        public int Tileset;
        public int Y;
        public int X;
    }
}
