using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client.Forms
{
    public partial class GameWindow : Form
    {
        // Form constants.
        public int HorizontalFormWeight = 16;
        public int VertivalFormWeight = 38;

        public GameWindow(int width, int height) {
            // Initialize the form.
            InitializeComponent();

            // Resize the form.
            this.Width = width + HorizontalFormWeight;
            this.Height = height + VertivalFormWeight;
        }
    }
}
