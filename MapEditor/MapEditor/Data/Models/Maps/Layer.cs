namespace MapEditor.Data.Models.Maps
{
    enum LayerType
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
