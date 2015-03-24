using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using MapEditor.IO;
using MapEditor.Forms;
using MapEditor.Data;
using MapEditor.Graphics;

namespace MapEditor
{
    static class Editor
    {
        public static MapTreeWindow MapTreeWindow;
        public static TilesetWindow TilesetWindow;
        public static MapPropertiesWindow MapPropertiesWindow;
        public static EditorWindow Window;
        public static Settings Settings;

        public static string StartupPath;
        public static bool Running;

        [STAThread]
        static void Main() {
            // Set the startup path of the application.
            StartupPath = AppDomain.CurrentDomain.BaseDirectory;
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.EnableVisualStyles();

            // Initialize the game form.
            Window = new EditorWindow(30 * 32, 20 * 32);
            TilesetWindow = new TilesetWindow();
            MapTreeWindow = new MapTreeWindow();
            MapPropertiesWindow = new MapPropertiesWindow();

            // Initialize the event-handlers and properties.


            Window.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Window.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Window.MaximizeBox = false;
            Window.Text = "Map Editor";
            Window.FormClosing += (sender, e) => {
                Editor.Running = false;
                e.Cancel = true;
            };

            // Load the game data.
            DataManager.Load();

            // Initialize the game graphics.
            GraphicsManager.Initialize();

            GameLoop();
        }

        private static void Destroy() {
            if (Running) {
                return;
            }

            DataManager.Save();
            Environment.Exit(1);
        }

        private static void GameLoop() {
            int tick = 0, tmr16 = 0;

            Running = true;
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
