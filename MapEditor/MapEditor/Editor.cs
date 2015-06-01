using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using MapEditor.IO;
using MapEditor.Forms;
using MapEditor.Data;
using MapEditor.Data.Models.Maps;
using MapEditor.Graphics;

namespace MapEditor
{
    static class Editor
    {
        public static MapTreeWindow MapTreeWindow;
        public static TilesetWindow TilesetWindow;
        public static LayerTreeWindow LayerTreeWindow;
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
            Window = new EditorWindow(30 * Tile.TileSize, 20 * Tile.TileSize);
            TilesetWindow = new TilesetWindow();
            MapTreeWindow = new MapTreeWindow();
            LayerTreeWindow = new LayerTreeWindow();

            MapTreeWindow.Show();
            MapTreeWindow.Hide();

            // Initialize the event-handlers and properties.


            Window.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Window.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Window.MaximizeBox = false;
            Window.Text = "Editing: None";
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

            if (Settings.ExportFolder == "" || !System.IO.File.Exists(Settings.ExportFolder)) {
                Window.SaveFileDialog.ShowDialog();
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
