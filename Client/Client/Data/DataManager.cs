using System.Collections.Generic;

using Client;
using Data.Models.Maps;
using Data.Models.Npcs;
using Data.Models.Players;
using IO;

namespace Data
{
    public static class DataManager
    {
        public static List<Map> Map;
        public static List<Player> Player;
        public static List<Npc> Npc;

        private static string CacheFile = Application.StartupPath + "data//cache.dat";
        
        public static void Load() {
            // Load the game settings.
            Application.Settings = new Settings();
            var instance = Serialization.Deserialize<Settings>(Settings.File, Application.Settings.GetType());
            if (instance != null) {
                Application.Settings = (Settings)instance;
            }

            // Initialize the playerlist.
            Player = new List<Player>();

            // Load the maps.
            Map = new List<Map>();

            // Load the NPCs.
            Npc = new List<Npc>();

            LoadGameCache();
        }

        private static void LoadGameCache() {
            if (System.IO.File.Exists(CacheFile)) {
                var cache = new DataBuffer(CacheFile);
                int count = cache.ReadInt();

                for (int i = 0; i < count; i++) {
                    string name = cache.ReadString();
                    int width = cache.ReadInt();
                    int height = cache.ReadInt();

                    Map.Add(new Map(name, width, height));
                    var map = Map[i];

                    int maskCount = cache.ReadInt();
                    int fringeCount = cache.ReadInt();

                    for (int x = 0; x < map.Width; x++) {
                        for (int y = 0; y < map.Height; y++) {
                            var tile = map.Tile[x, y];

                            tile.Attribute.Type = cache.ReadInt();

                            for (int lt = (int)MapLayers.Mask; lt < (int)MapLayers.Length; lt++) {
                                for (int l = 0; l < width; l++) {
                                    tile.Layer[lt].Add(new Layer());
                                }
                            }

                            for (int l = 0; l < maskCount; l++) {
                                var layer = tile.Layer[0][l];
                                layer.Tileset = cache.ReadInt();
                                layer.X = cache.ReadInt();
                                layer.Y = cache.ReadInt();
                            }

                            for (int l = 0; l < fringeCount; l++) {
                                var layer = tile.Layer[1][l];
                                layer.Tileset = cache.ReadInt();
                                layer.X = cache.ReadInt();
                                layer.Y = cache.ReadInt();
                            }
                        }
                    }
                }
            }


        }   


    }
}
