using MultiplayerEngine_Server.Data;
using MultiplayerEngine_Server.IO;
using MultiplayerEngine_Server.Networking;
using System;

namespace MultiplayerEngine_Server
{
    public static class Server
    {
        // Global variables related to the game.
        public static readonly string StartupPath = AppDomain.CurrentDomain.BaseDirectory;
        public static readonly string DataPath = Server.StartupPath + "Data\\";

        // The main point of entry for the application.
        private static void Main(string[] args) {
            // Check the folders and files in the system.
            FolderSystem.Check();

            // Load the game data.
            DataManager.Load();

            // Initialize the networking system.
            NetworkManager.Initialize();

            // Set up the server destroy event handler.
            Server.Write("[IMPORTANT INFORMATION]");
            Server.Write("------------------------------------------------------------------------------");
            Server.Write("Remember to turn off the server by pressing [CTRL + C] or [CTRL + BREAK].");
            Server.Write("If you do not, all online player's data will NOT be saved.");
            Server.Write("------------------------------------------------------------------------------");
            Console.CancelKeyPress += (s, e) => {
                Server.Destroy();
            };

            // Start the gameloop.
            Server.GameLoop();
        }

        private static void GameLoop() {
            while (true) {
                // Introduce game logic here.

                // Yield the thread to maximize core performance.
                System.Threading.Thread.Yield();
            }
        }

        private static void Destroy() {
            // Destroy the network so all online players will be
            // disconnected properly.
            NetworkManager.Destroy();

            // Save all game-related data.
            DataManager.Save();

            // Exit the application.
            Environment.Exit(0);
        }

        public static void Write(string message, bool newline = true) {
            if (newline) {
                Console.WriteLine(message);
            } else {
                Console.Write(message);
            }
            
        }
    }
}
