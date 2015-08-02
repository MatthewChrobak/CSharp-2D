using _2D_Multiplayer_Engine_Client.Data;
using _2D_Multiplayer_Engine_Client.IO;
using _2D_Multiplayer_Engine_Client.Forms;
using _2D_Multiplayer_Engine_Client.Graphics;
using _2D_Multiplayer_Engine_Client.Networking;

namespace _2D_Multiplayer_Engine_Client {
    public static class Program {
        // Public accessors
        public static GameWindow Window;

        public static string StartupPath;
        public static bool Running;

        static void Main(string[] args) {
            // Set up the startup path of the application.
            StartupPath = System.AppDomain.CurrentDomain.BaseDirectory;

            // Check the folders and files in the system.
            FolderSystem.Check();

            // Initialize the game form.
            Window = new GameWindow(30 * 32, 20 * 32);

            // Initialize the event-handlers and properties.
            Window.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Window.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Window.MaximizeBox = false;
            Window.FormClosing += (sender, e) => {
                Running = false;
                e.Cancel = true;
            };

            // Load the game data.
            DataManager.Load();

            // Initialize the game graphics.
            GraphicsManager.Initialize();

            // Start the network.
            NetworkManager.Initialize();

            // Start the gameloop.
            GameLoop();
        }

        private static void GameLoop() {
            int tick = 0, tmr16 = 0;

            Running = true;
            Window.Show();

            while (Running) {
                tick = System.Environment.TickCount;

                if (tmr16 < tick) {
                    GraphicsManager.Draw();
                    tmr16 = tick + 16;
                }

                System.Windows.Forms.Application.DoEvents();
            }

            Destroy();
        }

        private static void Destroy() {
            if (Running) {
                return;
            }
            DataManager.Save();
            System.Environment.Exit(1);
        }
    }
}
