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
                    Data.DataManager.curMap = treeMaps.TopNode.GetNodeCount(false) - 1;
                    Data.DataManager.Map.Add(new Data.Models.Map());
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
            }
        }
    }
}
