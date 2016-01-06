using Game.Audio;
using Game.Data;
using Game.Graphics;
using Game.IO;
using System;

namespace Game
{
    public static class Program
    {
        // Global variables related to the game.
        public static readonly string StartupPath = AppDomain.CurrentDomain.BaseDirectory;
        public static readonly string DataPath = Program.StartupPath + "data\\";
        public static GameState State { private set; get; }
        public static GameFlag Flag { private set; get; }

        // The main point of entry for the application.
        private static void Main(string[] args) {

            // Check the folders and files in the system.
            FolderSystem.Check();

            // Load the game data.
            DataManager.Load();

            // Initialize the audio system.
            AudioManager.Initialize();

            // Initialize the game graphics.
            GraphicsManager.Initialize();

            // Start the game-loop.
            Program.GameLoop();
        }

        private static void GameLoop() {
            int tick = 0, tick16 = 0;

            // Mark the game as running, and show the main window.
            Program.Flag = GameFlag.Running;

            // Continue to run the game-loop as long as our game
            // is not closing.
            while (Program.Flag != GameFlag.Closing) {
                tick = Environment.TickCount;

                // Render graphics up to 60 times a second.
                if (tick16 < tick) {
                    GraphicsManager.Graphics?.Draw();
                    tick16 = tick + 16;
                }
            }

            // The game will only be destroyed when the flag is set to closing.
            Program.Destroy();
        }

        public static void SetGameState(GameState state) {
            switch (state) {
                case GameState.MainMenu:
                    Program.State = state;
                    break;
                default:
                    return;
            }
        }

        public static void SetGameFlag(GameFlag flag) {
            // Make sure we can't change the flag if we're already closing.
            if (Program.Flag == GameFlag.Closing) {
                return;
            }

            Program.Flag = flag;
        }

        private static void Destroy() {
            // Make sure that the game-loop has stopped, and
            // that we didn't call this on accident.
            if (Program.Flag != GameFlag.Closing) {
                return;
            }

            // Before closing the game, save all relevant data.
            DataManager.Save();
            Environment.Exit(0);
        }
    }
}
