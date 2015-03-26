namespace MapEditor.Forms
{
    partial class TilesetWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.menu = new System.Windows.Forms.MenuStrip();
            this.Tilesets = new System.Windows.Forms.ToolStripComboBox();
            this.Layer = new System.Windows.Forms.ToolStripComboBox();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Tilesets,
            this.Layer});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(426, 27);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // Tilesets
            // 
            this.Tilesets.Name = "Tilesets";
            this.Tilesets.Size = new System.Drawing.Size(121, 23);
            // 
            // Layer
            // 
            this.Layer.Items.AddRange(new object[] {
            "Ground",
            "Mask1",
            "Mask2",
            "Fringe1",
            "Fringe2"});
            this.Layer.Name = "Layer";
            this.Layer.Size = new System.Drawing.Size(121, 23);
            // 
            // TilesetWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(426, 387);
            this.Controls.Add(this.menu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MainMenuStrip = this.menu;
            this.MaximumSize = new System.Drawing.Size(1500, 750);
            this.Name = "TilesetWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Pallete_FormClosing);
            this.Load += new System.EventHandler(this.TilesetWindow_Load);
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        public System.Windows.Forms.ToolStripComboBox Tilesets;
        public System.Windows.Forms.ToolStripComboBox Layer;

    }
}