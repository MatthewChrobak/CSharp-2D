using System.Collections.Generic;

namespace MapEditor.Data.Models.Maps
{
    public class Tile
    {
        // Every map tile is a square with a width of this value.
        public static int TileSize = 32;

        public List<Layer>[] Layer;
        public Attribute Attribute;

        public Tile() {
            Layer = new List<Layer>[(int)LayerType.Length];
            Attribute = new Attribute();

            Layer[0] = new List<Layer>();
            Layer[1] = new List<Layer>();
        }
    }
}
