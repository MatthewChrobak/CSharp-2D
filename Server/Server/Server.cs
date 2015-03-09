using System;
using System.Threading;

namespace Server
{
    public static class Server
    {
        // Public accessors

        // Global values
        public static string StartupPath;

        private static void Main(string[] args) {
            // Set the startup path of the application.
            StartupPath = AppDomain.CurrentDomain.BaseDirectory;

            // Check the folders and files in the system.

            // Load the game data.

            // Start the network.

            // Set up the Destroy Server event handlers.
            Console.WriteLine("[IMPORTANT INFORMATION] : ");
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.WriteLine("Remember to turn off the server by pressing [CTRL + C] or [CTRL + BREAK].");
            Console.WriteLine("If you do not, all online player's data will NOT be saved.");
            Console.WriteLine("------------------------------------------------------------------------------");
            Console.CancelKeyPress += (s, e) => {
                Server.Destroy();
            };

            // Start the gameloop.
            Server.GameLoop();
        }

        private static void Destroy() {
            Environment.Exit(1);
        }

        private static void GameLoop() {
            int tick = 0, tmr10000 = 0;

            while (true) {
                tick = Environment.TickCount;

                if (tmr10000 < tick) {
                    tmr10000 = tick + 10000;
                }
            }
        }
    }
}
