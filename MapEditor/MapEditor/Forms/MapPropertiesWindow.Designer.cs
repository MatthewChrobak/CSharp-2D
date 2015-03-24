namespace MapEditor.Forms
{
    partial class MapPropertiesWindow
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
            this.cmdOkay = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdOkay
            // 
            this.cmdOkay.Location = new System.Drawing.Point(12, 219);
            this.cmdOkay.Name = "cmdOkay";
            this.cmdOkay.Size = new System.Drawing.Size(87, 30);
            this.cmdOkay.TabIndex = 0;
            this.cmdOkay.Text = "Okay";
            this.cmdOkay.UseVisualStyleBackColor = true;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(185, 219);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(87, 30);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            // 
            // MapPropertiesWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOkay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MapPropertiesWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdOkay;
        private System.Windows.Forms.Button cmdCancel;
    }
}