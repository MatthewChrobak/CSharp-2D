using System.Collections.Generic;

using Server.Data.Models;
using Server.IO;

namespace Server.Data
{
    public static class DataManager
    {
        public static List<Map> Map;
        public static List<Player> Player;
        public static List<Npc> Npc;

        public static void Load() {
            // Load the game settings.
            Server.Settings = new Settings();
            var instance = Serialization.Deserialize<Settings>(Settings.File, Server.Settings.GetType());
            if (instance != null) {
                Server.Settings = (Settings)instance;
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
