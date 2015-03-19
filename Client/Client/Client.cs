using System;

using Client.IO;
using Client.Data;
using Client.Forms;
using Client.Graphics;
using Client.Networking;

namespace Client
{
    public static class Client
    {
        // Public accessors
        public static GameWindow Window;
        public static Settings Settings;

        // Global values
        public static string StartupPath;
        public static bool Running;
        public static bool inGame;

        [STAThread]
        private static void Main(string[] args) {
            // Set the startup path of the application.
            StartupPath = AppDomain.CurrentDomain.BaseDirectory;

            // Check the folders and files in the system.
            FolderSystem.Check();

            // Initialize the game form.
            Window = new GameWindow(30 * 32, 20 * 32);

            // Initialize the event-handlers and properties.
            Window.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Window.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Window.MaximizeBox = false;
            Window.FormClosing += (sender, e) => {
                if (inGame) {
                    PacketManager.SendLeaveGame();
                } else {
                    Client.Running = false;
                }
                e.Cancel = true;
            };

            // Load the game data.
            DataManager.Load();

            // Initialize the game graphics.
            GraphicsManager.Initialize();

            // Start the network.
            NetworkManager.Initialize();

            // Start the gameloop.
            Client.GameLoop();
        }

        private static void Destroy() {
            if (Running) {
                return;
            }

            Environment.Exit(1);
        }

        private static void GameLoop() {
            int tick = 0, tmr16 = 0;

            Running = true;
            inGame = false;
            Window.Show();

            while (Running) {
                tick = Environment.TickCount;

                if (tmr16 < tick) {
                    GraphicsManager.Draw();
                    tmr16 = tick + 16;
                }

                System.Windows.Forms.Application.DoEvents();
            }

            Destroy();
        }
    }
}
