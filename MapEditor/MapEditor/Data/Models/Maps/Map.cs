using System.Collections.Generic;

namespace MapEditor.Data.Models.Maps
{
    public class Map
    {
        public string Name = "";
        public int Width = 0;
        public int Height = 0 ;

        public Tile[,] Tile;
        public List<int>[] Layers;
        public List<bool>[] LayerVisible;

        public Map() {
            Tile = new Tile[0, 0];
            Layers = new List<int>[(int)LayerType.Length];
            LayerVisible = new List<bool>[(int)LayerType.Length];

            Layers[0] = new List<int>();
            Layers[1] = new List<int>();

            LayerVisible[0] = new List<bool>();
            LayerVisible[1] = new List<bool>();
        }

        public void Resize(int width, int height) {
            
            // Create an array of columns
            Column[] columns = new Column[Width];

            // Create the array in each column.
            for (int x = 0; x < Width; x++) {
                columns[x] = new Column(Height);
            }

            // Transfer all the data.
            for (int x = 0; x < Width; x++) {
                for (int y = 0; y < Height; y++) {
                    columns[x].RowMember[y] = Tile[x, y];
                }
            }

            // Resize the columns.
            for (int x = 0; x < Width; x++) {
                System.Array.Resize(ref columns[x].RowMember, height);
            }

            // Resize the row size.
            System.Array.Resize(ref columns, width);

            Tile[,] newTiles = new Tile[width, height];

            // Transfer all the data.
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {

                    if (columns[x] == null) {
                        newTiles[x, y] = new Tile();
                    } else {
                        if (columns[x].RowMember[y] == null) {
                            newTiles[x, y] = new Tile();
                        } else {
                            newTiles[x, y] = columns[x].RowMember[y];
                        }
                    }
                }
            }

            Tile = newTiles;
            Width = width;
            Height = height;
        }

        private class Column
        {
            public Tile[] RowMember;

            public Column(int height) {
                RowMember = new Tile[height];
            }
        }
    }
}
