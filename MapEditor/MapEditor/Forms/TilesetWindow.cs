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
    public partial class TilesetWindow : Form
    {
        public TilesetWindow() {
            InitializeComponent();
        }

        private void Pallete_FormClosing(object sender, FormClosingEventArgs e) {
            this.Visible = false;
            e.Cancel = true;
        }

        private void hiToolStripMenuItem_Click(object sender, EventArgs e) {
            menu.Visible = false;
        }

        private void TilesetWindow_Load(object sender, EventArgs e) {
            Layer.SelectedIndex = 0;
        }
    }
}
