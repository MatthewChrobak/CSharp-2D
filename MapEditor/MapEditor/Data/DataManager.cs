using System.Collections.Generic;
using System.IO;

using MapEditor.Data.Models.Maps;
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
                int count = cache.ReadInt();

                for (int i = 0; i < count; i++) {
                    Map.Add(new Map());
                    var map = Map[i];

                    map.Name = cache.ReadString();
                    int width = cache.ReadInt();
                    int height = cache.ReadInt();
                    map.Resize(width, height);

                    width = cache.ReadInt();
                    height = cache.ReadInt();

                    for (int l = 0; l < width; l++) {
                        map.Layers[0].Add(l);
                        Editor.TilesetWindow.Layer.Items.Add("Mask " + l);
                        Editor.LayerTreeWindow.treeLayers.Nodes[0].Nodes.Add("Mask " + l);
                    }

                    for (int l = 0; l < height; l++) {
                        map.Layers[1].Add(l);
                        Editor.TilesetWindow.Layer.Items.Add("Fringe " + l);
                        Editor.LayerTreeWindow.treeLayers.Nodes[1].Nodes.Add("Fringe " + l);
                    }

                    for (int x = 0; x < map.Width; x++) {
                        for (int y = 0; y < map.Height; y++) {
                            var tile = map.Tile[x, y];

                            tile.Attribute.Type = cache.ReadInt();

                            for (int l = 0; l < width; l++){
                                tile.Layer[0].Add(new Layer() { Tileset = -1 });
                            }

                            for (int l = 0; l < height; l++) {
                                tile.Layer[1].Add(new Layer() { Tileset = -1 });
                            }

                            for (int l = 0; l < (int)LayerType.Length; l++) 
                                foreach (var layer in tile.Layer[l]) {
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
            cache.Write(Map.Count);

            for (int i = 0; i < Map.Count; i++) {
                var map = Map[i];

                cache.Write(map.Name);
                cache.Write(map.Width);
                cache.Write(map.Height);
                cache.Write(map.Layers[0].Count);
                cache.Write(map.Layers[1].Count);

                for (int x = 0; x < map.Width; x++) {
                    for (int y = 0; y < map.Height; y++) {
                        var tile = map.Tile[x, y];

                        cache.Write(tile.Attribute.Type);

                        for (int l = 0; l < (int)LayerType.Length; l++) {
                            foreach (var layer in tile.Layer[l]) {
                                cache.Write(layer.Tileset);
                                cache.Write(layer.X);
                                cache.Write(layer.Y);
                            }
                        }
                    }
                }
            }

            cache.Save(Editor.Settings.ExportFolder);
        }
    }
}
