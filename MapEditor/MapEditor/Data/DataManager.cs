using System.Collections.Generic;
using System.IO;

using MapEditor.Data.Models;
using MapEditor.IO;

namespace MapEditor.Data
{
    public static class DataManager
    {
        public static int curMap = -1;
        public static List<Map> Map;

        public static void Load() {
            // Load the game settings.
            Editor.Settings = new Settings();
            var instance = Serialization.Deserialize<Settings>(Settings.File, Editor.Settings.GetType());
            if (instance != null) {
                Editor.Settings = (Settings)instance;
            }

            Map = new List<Map>();
            LoadCache();
        }

        public static void Save() {
            Serialization.Serialize<Settings>(Settings.File, Editor.Settings.GetType(), Editor.Settings);

            SaveCache();
        }

        public static void LoadCache() {
            if (System.IO.File.Exists(Editor.Settings.ExportFolder)) {
                Map.Clear();

                var cache = new DataBuffer(Editor.Settings.ExportFolder);
                string revision = cache.ReadString();
                int count = cache.ReadInt();

                for (int i = 0; i < count; i++) {
                    Map.Add(new Map());
                    var map = Map[i];

                    map.Name = cache.ReadString();
                    map.Width = cache.ReadInt();
                    map.Height = cache.ReadInt();

                    for (int x = 0; x < map.Width; x++) {
                        for (int y = 0; y < map.Height; y++) {
                            var tile = map.Tile[x, y];

                            tile.Attribute = cache.ReadInt();

                            for (int l = 0; l < (int)MapLayers.Length; l++) {
                                var layer = tile.Layer[l];

                                layer.Tileset = cache.ReadInt();
                                layer.X = cache.ReadInt();
                                layer.Y = cache.ReadInt();
                            }
                        }
                    }
                }

                curMap = -1;

                if (Editor.MapTreeWindow.treeMaps.TopNode != null) {
                    Editor.MapTreeWindow.treeMaps.TopNode.Remove();
                }

                Editor.MapTreeWindow.treeMaps.Nodes.Add("Maps");

                for (int i = 0; i < Map.Count; i++) {
                    Editor.MapTreeWindow.treeMaps.Nodes[0].Nodes.Add(i + ": " + Map[i].Name);
                }
            }
        }

        public static void SaveCache() {

            var cache = new DataBuffer();
            string cacheRevision = "1234567890";
            cache.Write(cacheRevision);
            cache.Write(Map.Count);

            for (int i = 0; i < Map.Count; i++) {
                var map = Map[i];

                cache.Write(map.Name);
                cache.Write(map.Width);
                cache.Write(map.Height);

                for (int x = 0; x < map.Width; x++) {
                    for (int y = 0; y < map.Height; y++) {
                        var tile = map.Tile[x, y];

                        cache.Write(tile.Attribute);

                        for (int l = 0; l < (int)MapLayers.Length; l++) {
                            var layer = tile.Layer[l];

                            cache.Write(layer.Tileset);
                            cache.Write(layer.X);
                            cache.Write(layer.Y);
                        }
                    }
                }
            }

            cache.Save(Editor.Settings.ExportFolder);
        }
    }
}
