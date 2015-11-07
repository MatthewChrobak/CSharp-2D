using System.Windows.Forms;

namespace _2D_Singleplayer_Engine.Forms
{
    public partial class GameWindow : Form
    {
        // Form constants regarding the extra spacing of the form border.
        public int HorizontalFormWeight = 16;
        public int VerticalFormWeight = 38;

        public GameWindow(int width, int height) {
            // Initialize the form before changing any form-related objects.
            InitializeComponent();

            // Resize the form.
            this.Width = width + HorizontalFormWeight;
            this.Height = height + VerticalFormWeight;
        }

        // Used to return the form container height.
        public int getTrueHeight() {
            return this.Height - VerticalFormWeight;
        }

        // Used to return the form container width.
        public int getTrueWidth() {
            return this.Width - HorizontalFormWeight;
        }
    }
}
