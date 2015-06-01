using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class GameWindow : Form
    {
        // Form constants.
        private int HorizontalFormWeight = 16;
        private int VerticalFormWeight = 38;

        public GameWindow(int width, int height) {
            // Initialize the form.
            InitializeComponent();

            // Resize the form.
            this.Width = width + HorizontalFormWeight;
            this.Height = height + VerticalFormWeight;
        }

        public Size GetTrueSize() {
            return new Size(this.Width - HorizontalFormWeight, this.Height - VerticalFormWeight);
        }
    }
}
