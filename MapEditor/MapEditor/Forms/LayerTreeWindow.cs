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
    public partial class LayerTreeWindow : Form
    {
        public LayerTreeWindow() {
            InitializeComponent();

            treeLayers.NodeMouseDoubleClick += treeLayers_NodeMouseDoubleClick;
        }

        void treeLayers_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e) {

            if (e.Node != treeLayers.Nodes[0] && e.Node != treeLayers.Nodes[1]) {
                // Are we in the mask layers?
                if (e.Node.Parent == treeLayers.Nodes[0]) {
                    if (treeLayers.Nodes[0].Nodes[e.Node.Index].IsSelected) {
                        // Make this mask visible.
                    }
                } 
                
                // Are we in the fringe layers?
                if (e.Node.Parent == treeLayers.Nodes[1]) {
                    if (treeLayers.Nodes[1].Nodes[e.Node.Index].IsSelected) {
                        // Make this mask visible.
                    }
                }
            }
        }

        private void LayerTreeWindow_FormClosing(object sender, FormClosingEventArgs e) {
            this.Visible = false;
            e.Cancel = true;
        }

        private void LayerTreeWindow_Resize(object sender, EventArgs e) {
            treeLayers.Width = this.Width - Editor.Window.HorizontalFormWeight - 24;
            treeLayers.Height = this.Height - Editor.Window.VerticalFormWeight - 24;

            cmdNew.Left = 12;
            cmdNew.Width = (this.Width - 24 - 23) / 2;
            cmdDelete.Width = cmdNew.Width;
            cmdDelete.Left = cmdNew.Left + 11 + cmdNew.Width;
        }

        private void cmdNew_Click(object sender, EventArgs e) {

            var map = Data.DataManager.Map[Data.DataManager.curMap];

            if (treeLayers.Nodes[0].IsSelected) {
                treeLayers.Nodes[0].Nodes.Add("Mask " + treeLayers.Nodes[0].Nodes.Count);
                treeLayers.Nodes[0].Expand();
                map.Layers[0].Add(treeLayers.Nodes[0].Nodes.Count - 1);

                for (int x = 0; x < map.Width; x++) {
                    for (int y = 0; y < map.Height; y++) {
                        map.Tile[x, y].Layer[0].Add(new MapEditor.Data.Models.Maps.Layer() { Tileset = -1 } );
                    }
                }
            }

            if (treeLayers.Nodes[1].IsSelected) {
                treeLayers.Nodes[1].Nodes.Add("Fringe " + treeLayers.Nodes[1].Nodes.Count);
                treeLayers.Nodes[1].Expand();
                map.Layers[1].Add(treeLayers.Nodes[1].Nodes.Count - 1);

                for (int x = 0; x < map.Width; x++) {
                    for (int y = 0; y < map.Height; y++) {
                        map.Tile[x, y].Layer[1].Add(new MapEditor.Data.Models.Maps.Layer() { Tileset = -1 });
                    }
                }
            }

            Editor.TilesetWindow.Layer.Items.Clear();

            for (int i = 0; i < Data.DataManager.Map[Data.DataManager.curMap].Layers[0].Count; i++) {
                Editor.TilesetWindow.Layer.Items.Add("Mask " + i);
            }

            for (int i = 0; i < Data.DataManager.Map[Data.DataManager.curMap].Layers[1].Count; i++) {
                Editor.TilesetWindow.Layer.Items.Add("Fringe " + i);
            }
        }
    }
}
