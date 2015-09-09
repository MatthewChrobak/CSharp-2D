﻿using System.Windows.Forms;

namespace _2D_Singleplayer_Engine.Forms {
    public partial class GameWindow : Form {
        // Form constants.
        public int HorizontalFormWeight = 16;
        public int VerticalFormWeight = 38;

        public GameWindow(int width, int height) {
            InitializeComponent();

            // Resize the form.
            this.Width = width + HorizontalFormWeight;
            this.Height = height + VerticalFormWeight;
        }

        public int getTrueHeight() {
            return this.Height - VerticalFormWeight;
        }

        public int getTrueWidth() {
            return this.Width - HorizontalFormWeight;
        }
    }
}