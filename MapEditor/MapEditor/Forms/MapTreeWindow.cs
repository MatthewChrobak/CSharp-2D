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
    public partial class MapTreeWindow : Form
    {
        public MapTreeWindow() {
            InitializeComponent();

            treeMaps.NodeMouseDoubleClick += treeMaps_NodeMouseDoubleClick;
        }

        void treeMaps_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {
            if (e.Node != treeMaps.TopNode) {
                if (treeMaps.TopNode.Nodes[e.Node.Index].IsSelected) {
                    Data.DataManager.curMap = e.Node.Index;
                    Editor.Window.Text = "Editing: " + Data.DataManager.Map[e.Node.Index].Name;

                    Editor.TilesetWindow.Layer.Items.Clear();
                    Editor.LayerTreeWindow.treeLayers.Nodes[0].Nodes.Clear();
                    Editor.LayerTreeWindow.treeLayers.Nodes[1].Nodes.Clear();

                    for (int i = 0; i < Data.DataManager.Map[Data.DataManager.curMap].Layers[0].Count; i++) {
                        Editor.TilesetWindow.Layer.Items.Add("Mask " + i);
                        Editor.LayerTreeWindow.treeLayers.Nodes[0].Nodes.Add("Mask " + i);
                    }

                    for (int i = 0; i < Data.DataManager.Map[Data.DataManager.curMap].Layers[1].Count; i++) {
                        Editor.TilesetWindow.Layer.Items.Add("Fringe " + i);
                        Editor.LayerTreeWindow.treeLayers.Nodes[1].Nodes.Add("Fringe " + i);
                    }
                }
            }
        }

        private void MapTreeWindow_FormClosing(object sender, FormClosingEventArgs e) {
            this.Visible = false;
            e.Cancel = true;
        }

        private void MapTreeWindow_Resize(object sender, EventArgs e) {
            treeMaps.Width = this.Width - Editor.Window.HorizontalFormWeight - 24;
            treeMaps.Height = this.Height - Editor.Window.VerticalFormWeight - 24;

            cmdNew.Left = 12;
            cmdNew.Width = (this.Width - 24 - 23) / 2;
            cmdDelete.Width = cmdNew.Width;
            cmdDelete.Left = cmdNew.Left + 11 + cmdNew.Width;
        }

        private void cmdNew_Click(object sender, EventArgs e) {
            if (treeMaps.TopNode != null) {
                treeMaps.TopNode.Nodes.Add("New Map");
                treeMaps.TopNode.Expand();
                Data.DataManager.Map.Add(new Data.Models.Maps.Map());
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e) {

        }
    }
}
