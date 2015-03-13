using System.Collections.Generic;

using Client.Data.Models;
using Client.IO;

namespace Client.Data
{
    public static class DataManager
    {
        public static List<Map> Map;
        public static List<Player> Player;
        public static List<Npc> Npc;

        public static void Load() {
            // Load the game settings.
            Client.Settings = new Settings();
            var instance = Serialization.Deserialize<Settings>(Settings.File, Client.Settings.GetType());
            if (instance != null) {
                Client.Settings = (Settings)instance;
            }

            // Initialize the playerlist.
            Player = new List<Player>();

            // Load the maps.
            Map = new List<Map>();

            // Load the NPCs.
            Npc = new List<Npc>();
        }
    }
}
