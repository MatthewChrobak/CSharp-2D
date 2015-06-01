using System.Collections.Generic;

namespace Data.Models.Maps
{
    public class Tile
    {
        // Every map tile is a square with a width of this value.
        public static int TileSize = 32;

        public List<Layer>[] Layer;
        public Attribute Attribute;

        public Tile() {
            Layer = new List<Layer>[(int)MapLayers.Length];
            Attribute = new Attribute();

            Layer[(int)MapLayers.Mask] = new List<Layer>();
            Layer[(int)MapLayers.Fringe] = new List<Layer>();
        }
    }
}
