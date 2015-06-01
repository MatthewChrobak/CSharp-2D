namespace Data.Models.Maps
{
    public enum MapLayers
    {
        Mask,
        Fringe,
        Length
    }

    public class Layer
    {
        public int X;
        public int Y;
        public int Tileset;
    }
}
