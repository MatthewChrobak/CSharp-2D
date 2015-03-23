using System.Collections.Generic;

using MapEditor.Data.Models;
using MapEditor.IO;

namespace MapEditor.Data
{
    public static class DataManager
    {
        public static int curMap;
        public static List<Map> Map;

        public static void Load() {
            // Load the game settings.
            Editor.Settings = new Settings();
            var instance = Serialization.Deserialize<Settings>(Settings.File, Editor.Settings.GetType());
            if (instance != null) {
                Editor.Settings = (Settings)instance;
            }

            Map = new List<Map>();
        }

        public static void Save() {
            Serialization.Serialize<Settings>(Settings.File, Editor.Settings.GetType(), Editor.Settings);
        }
    }
}
