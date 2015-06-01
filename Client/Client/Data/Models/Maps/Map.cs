namespace Data.Models.Maps
{
    public class Map
    {
        public static string CacheRevision;

        public string Name;
        public int Width;
        public int Height;

        public Tile[,] Tile;

        public Map(string name, int width, int height) {
            this.Name = name;
            this.Width = width;
            this.Height = height;

            Tile = new Tile[Width, Height];

            for (int x = 0; x < Width; x++) {
                for (int y = 0; y < Height; y++) {
                    Tile[x, y] = new Tile();
                }
            }
        }
    }
}
