using Client.Audio;
using Client.Data;
using Client.Graphics;
using Client.IO;
using Client.Networking;
using System;

namespace Client
{
    public static class Client
    {
        // Global variables related to the client.
        public static readonly string StartupPath = AppDomain.CurrentDomain.BaseDirectory;
        public static readonly string DataPath = Client.StartupPath + "data\\";
        public static ClientState State { private set; get; }
        public static ClientFlag Flag { private set; get; }

        // The main point of entry for the application.
        private static void Main(string[] args) {

            // Check the folders and files in the system.
            FolderSystem.Check();

            // Load the client data.
            DataManager.Load();

            // Initialize the audio system.
            AudioManager.Initialize();

            // Start the network.
            NetworkManager.Initialize();

            // Initialize the game graphics.
            GraphicsManager.Initialize();

            // Start the game-loop.
            Client.GameLoop();
        }

        private static void GameLoop() {
            int tick = 0, tick16 = 0;

            // Mark the client as running, and show the main window.
            Client.Flag = ClientFlag.Running;

            // Continue to run the game-loop as long as our client
            // is not closing.
            while (Client.Flag != ClientFlag.Closing) {
                tick = Environment.TickCount;                

                // Render graphics up to 60 times a second.
                if (tick16 < tick) {
                    GraphicsManager.Graphics?.Draw();
                    tick16 = tick + 16;
                }
            }

            // The client will only be destroyed when the flag is set to closing.
            Client.Destroy();
        }

        public static void Write(string text, bool newline = true) {
            if (newline) {
                Console.WriteLine(text);
            } else {
                Console.Write(text);
            }
        }

        public static void SetGameState(ClientState state) {
            switch (state) {
                case ClientState.MainMenu:
                    Client.State = state;
                    break;
                default:
                    return;
            }
        }

        public static void SetClientFlag(ClientFlag flag) {
            // Make sure we can't change the flag if we're already closing.
            if (Client.Flag == ClientFlag.Closing) {
                return;
            }

            Client.Flag = flag;
        }

        private static void Destroy() {
            // Make sure that the game-loop has stopped, and
            // that we didn't call this on accident.
            if (Client.Flag != ClientFlag.Closing) {
                return;
            }

            // Destroy the network so as to let the server know
            // we disconnected.
            NetworkManager.Destroy();

            // Before closing the client, save all relevant data.
            DataManager.Save();
            Environment.Exit(0);
        }
    }
}