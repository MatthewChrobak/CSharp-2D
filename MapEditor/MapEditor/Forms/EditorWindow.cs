using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MapEditor.Forms
{
    public partial class EditorWindow : Form
    {
        // Form constants.
        public int HorizontalFormWeight = 16;
        public int VerticalFormWeight = 38;
        public int MenuHeight = 27;

        public EditorWindow(int width, int height) {
            // Initialize the form.
            InitializeComponent();

            // Resize the form.
            this.Width = width + HorizontalFormWeight;
            this.Height = height + VerticalFormWeight + MenuHeight;
        }

        private void openCacheToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog.ShowDialog();
        }

        private void OpenFileDialog_FileOk(object sender, CancelEventArgs e) {
            Editor.Settings.ExportFolder = OpenFileDialog.FileName;
            Data.DataManager.LoadCache();
        }

        private void exportToToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveFileDialog.ShowDialog();
        }

        private void importGraphicsToolStripMenuItem_Click(object sender, EventArgs e) {

            if (System.IO.Directory.Exists(Editor.Settings.GraphicsFolder)) {
                FolderDialog.SelectedPath = Editor.Settings.GraphicsFolder;
            }

            FolderDialog.ShowDialog();
            if (FolderDialog.SelectedPath != "") {
                Editor.Settings.GraphicsFolder = FolderDialog.SelectedPath;
                Graphics.GraphicsManager.Reload();
            }
        }

        private void SaveFileDialog_FileOk(object sender, CancelEventArgs e) {
            Editor.Settings.ExportFolder = SaveFileDialog.FileName;
            Data.DataManager.SaveCache();
        }

        private void tilesetToolStripMenuItem_Click(object sender, EventArgs e) {
            Editor.TilesetWindow.Show();
            Graphics.SFML.Input.MainFocus = false;
        }

        private void mapListToolStripMenuItem_Click(object sender, EventArgs e) {
            Editor.MapTreeWindow.Show();
        }

        private void newCacheToolStripMenuItem_Click(object sender, EventArgs e) {
            Data.DataManager.Map = new List<Data.Models.Map>();
            Data.DataManager.curMap = -1;

            if (Editor.MapTreeWindow.treeMaps.TopNode != null) {
                Editor.MapTreeWindow.treeMaps.TopNode.Remove();
            }

            Editor.MapTreeWindow.treeMaps.Nodes.Add("Maps");
        }

        private void propertiesToolStripMenuItem1_Click(object sender, EventArgs e) {
            if (Data.DataManager.curMap == -1) {
                return;
            }
            new MapPropertiesWindow().ShowDialog();
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e) {
            Data.DataManager.SaveCache();
        }
    }
}
