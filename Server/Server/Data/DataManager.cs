using System.Collections.Generic;

using Server.Data.Models;
using Server.Data.Models.Players;
using Server.Data.Models.Maps;
using Server.Data.Models.Npcs;
using Server.IO;

namespace Server.Data
{
    public static class DataManager
    {
        public static string DataPath = Server.StartupPath + "Data\\";
        public static string PlayerPath = DataPath + "Players\\";
        public static string NpcPath = DataPath + "Npcs\\";

        public static Map[] Map;
        public static List<Player> Player;
        public static Npc[] Npc;

        public static void Load() {
            // Load the game settings.
            Server.Settings = new Settings();
            var instance = Serialization.Deserialize<Settings>(Settings.File, Server.Settings.GetType());
            if (instance != null) {
                Server.Settings = (Settings)instance;
            }

            Player = new List<Player>();

            // Load the game cache.
            LoadGameCache();
        }

        private static void LoadGameCache() {
            if (FolderSystem.FileExists(Server.Settings.GameCache)) {
                
                // Load the cache file.
                var cache = new DataBuffer(Server.Settings.GameCache);

                #region Map
                int mapCount = cache.ReadInt();
                Map = new Map[mapCount];

                for (int i = 0; i < mapCount; i++) {
                    var map = Map[i];
                    map = new Map(cache.ReadString(), cache.ReadInt(), cache.ReadInt());
                    
                    // Layer related data that doesn't involve the server.
                    // We still have to make sure we don't leave anything though.
                    int maskCount = cache.ReadInt();
                    int fringeCount = cache.ReadInt();

                    for (int x = 0; x < map.Width; x++) {
                        for (int y = 0; y < map.Height; y++) {
                            var tile = map.Tile[x, y];

                            tile.Attribute = new Attribute(cache.ReadInt(), 0);

                            for (int l = 0; l < maskCount; l++) {
                                for (int c = 0; c < 3; c++) {
                                    cache.ReadInt();
                                }
                            }

                            for (int l = 0; l < fringeCount; l++) {
                                for (int c = 0; c < 3; c++) {
                                    cache.ReadInt();
                                }
                            }
                        }
                    }
                }

                cache.ReadInt();

                #endregion

            } else {
                Server.Write("Could not find " + Server.Settings.GameCache);
            }
        }
    }
}
