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
    public partial class MapPropertiesWindow : Form
    {
        private Data.Models.Maps.Map _map;

        public MapPropertiesWindow() {
            InitializeComponent();
        }

        private void MapPropertiesWindow_Load(object sender, EventArgs e) {
            _map = Data.DataManager.Map[Data.DataManager.curMap];
            txtWidth.Text = _map.Width.ToString();
            txtHeight.Text = _map.Height.ToString();
            txtMapName.Text = _map.Name;
        }

        private void cmdOkay_Click(object sender, EventArgs e) {
            int height;
            int width;

            Int32.TryParse(txtWidth.Text, out height);
            Int32.TryParse(txtWidth.Text, out width);

            if (height > 255) {
                height = 255;
            } else if (height < 30) {
                height = 30;
            }

            if (width > 255) {
                width = 255;
            } else if (width < 30) {
                width = 30;
            }

            _map.Resize(width, height);
            _map.Name = txtMapName.Text;

            Editor.MapTreeWindow.treeMaps.TopNode.Nodes[Data.DataManager.curMap].Text = Data.DataManager.curMap + ": " + txtMapName.Text;
            Editor.Window.Text = "Editing: " + _map.Name;
            this.Close();
        }
    }
}
