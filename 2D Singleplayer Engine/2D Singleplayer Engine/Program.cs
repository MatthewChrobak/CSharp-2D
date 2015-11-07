using _2D_Singleplayer_Engine.Audio;
using _2D_Singleplayer_Engine.Data;
using _2D_Singleplayer_Engine.Forms;
using _2D_Singleplayer_Engine.Graphics;
using _2D_Singleplayer_Engine.IO;

namespace _2D_Singleplayer_Engine 
{
    public static class Program 
    {
        // Public accessors
        public static GameWindow Window;

        // Global variables related to the game.
        public static string StartupPath;
        public static GameState State;
        public static GameFlag Flag;

        // The main point of entry for the application.
        static void Main(string[] args) {
            // Set up the startup path of the application.
            Program.StartupPath = System.AppDomain.CurrentDomain.BaseDirectory;

            // Check the folders and files in the system.
            FolderSystem.Check();

            // Initialize the game form.
            Program.Window = new GameWindow(30 * 32, 20 * 32);

            // Initialize the event-handlers and properties.
            Program.Window.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Program.Window.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Program.Window.MaximizeBox = false;
            Program.Window.FormClosing += (sender, e) => {
                Program.Flag = GameFlag.CLOSING;
                e.Cancel = true;
            };

            // Load the game data.
            DataManager.Load();

            // Initialize the game graphics.
            GraphicsManager.Initialize();

            // Initialize the audio system.
            AudioManager.Initialize();

            // Start the gameloop.
            Program.GameLoop();
        }

        private static void GameLoop() {
            int tick = 0, tmr16 = 0;

            // Mark the game as running, and show the main window.
            Program.Flag = GameFlag.RUNNING;
            Program.Window.Show();

            // Continue to run the game-loop as long as our game
            // is not closing.
            while (Program.Flag != GameFlag.CLOSING) {
                tick = System.Environment.TickCount;

                // Render graphics up to 60 times a second.
                if (tmr16 < tick) {
                    GraphicsManager.Draw();
                    tmr16 = tick + 16;
                }

                // Since Forms are used, call DoEvents so the window
                // doesn't hang.
                System.Windows.Forms.Application.DoEvents();
            }

            // The game will only be destroyed when the flag is set 
            // to closing.
            Program.Destroy();
        }

        private static void Destroy() {
            // Make sure that the game-loop has stopped, and
            // that we didn't call this on accident.
            if (Program.Flag != GameFlag.CLOSING) {
                return;
            }

            // Before closing the game, save all relevant data.
            DataManager.Save();
            System.Environment.Exit(0);
        }
    }
}
