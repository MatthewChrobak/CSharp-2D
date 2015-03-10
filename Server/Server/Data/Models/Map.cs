namespace Server.Data.Models
{
    public class Map
    {
        public int Width;
        public int Height;

        public Tile[,] Tile;

        public Map() {
            Tile = new Tile[Width, Height];

            for (int x = 0; x < Width; x++) {
                for (int y = 0; y < Height; y++) {
                    Tile[x, y] = new Tile() { Attribute = 0 };
                }
            }
        }
    }
}
