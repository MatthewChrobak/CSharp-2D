namespace Server.Data.Models.Maps
{
    public class Map
    {
        public string Name;
        public int Width;
        public int Height;

        public Tile[,] Tile;

        public Map(string name, int width, int height) {
            
            Tile = new Tile[width, height];
            this.Name = name;

            for (int x = 0; x < Width; x++) {
                for (int y = 0; y < Height; y++) {
                    Tile[x, y] = new Tile();
                }
            }
        }
    }
}
