using _2D_Multiplayer_Engine_Server.Data;
using _2D_Multiplayer_Engine_Server.IO;
using _2D_Multiplayer_Engine_Server.Networking;
using System;

namespace _2D_Multiplayer_Engine_Server
{
    public static class Program
    {
        public static string StartupPath;
        public static bool Running;

        static void Main(string[] args) {
            // Set up the startup path of the application.
            StartupPath = System.AppDomain.CurrentDomain.BaseDirectory;

            // Check the folders and files in the system.
            FolderSystem.Check();

            // Load the game data.
            DataManager.Load();

            // Start the network.
            NetworkManager.Initialize();

            // Set up the Destroy Server event handlers.
            Console.WriteLine("[IMPORTANT INFORMATION] : ");
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("Remember to turn off the server by pressing [CTRL + C] or [CTRL + BREAK].");
            Console.WriteLine("If you do not, all online player's data will NOT be saved.");
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.CancelKeyPress += (s, e) => {
                Destroy();
            };

            // Start the gameloop.
            GameLoop();
        }

        private static void GameLoop() {
            int tick = 0, tmr1000 = 0;

            Running = true;

            while (Running) {
                tick = System.Environment.TickCount;

                if (tmr1000 < tick) {
                    tmr1000 = tick + 1000;
                }

                System.Windows.Forms.Application.DoEvents();
            }

            Destroy();
        }

        private static void Destroy() {
            Running = false;
            DataManager.Save();
            System.Environment.Exit(1);
        }

        public static void Write(string message) {
            Console.WriteLine(message);
        }
    }
}
