namespace Client.Data.Models
{
    public enum MapAttributes
    {
        None,
        Length
    }

    public class Tile
    {
        public Layer[] Layer;
        public int Attribute;

        public Tile() {
            Layer = new Layer[(int)MapLayers.Length];

            for (int l = 0; l < (int)MapLayers.Length; l++) {
                Layer[l] = new Layer() { Tileset = 0, X = 0, Y = 0 };
            }
        }
    }


}
