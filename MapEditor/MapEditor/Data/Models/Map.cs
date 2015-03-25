namespace MapEditor.Data.Models
{
    public class Map
    {
        public string Name = "";
        public int Width = 0;
        public int Height = 0;

        public Tile[,] Tile;

        public Map() {
            Tile = new Tile[255, 255];

            for (int x = 0; x < 255; x++) {
                for (int y = 0; y < 255; y++) {
                    Tile[x, y] = new Tile() { Attribute = 0 };
                }
            }
        }
    }
}
