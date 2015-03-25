namespace MapEditor.Forms
{
    partial class MapTreeWindow
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
            this.treeMaps = new System.Windows.Forms.TreeView();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.cmdNew = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // treeMaps
            // 
            this.treeMaps.Location = new System.Drawing.Point(12, 12);
            this.treeMaps.Name = "treeMaps";
            this.treeMaps.Size = new System.Drawing.Size(185, 296);
            this.treeMaps.TabIndex = 2;
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(116, 266);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(81, 42);
            this.cmdDelete.TabIndex = 4;
            this.cmdDelete.Text = "Delete Map";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // cmdNew
            // 
            this.cmdNew.BackColor = System.Drawing.SystemColors.Control;
            this.cmdNew.Location = new System.Drawing.Point(12, 266);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(81, 42);
            this.cmdNew.TabIndex = 5;
            this.cmdNew.Text = "New Map";
            this.cmdNew.UseVisualStyleBackColor = false;
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // MapTreeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(209, 320);
            this.Controls.Add(this.cmdNew);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.treeMaps);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "MapTreeWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MapTreeWindow_FormClosing);
            this.Resize += new System.EventHandler(this.MapTreeWindow_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdDelete;
        private System.Windows.Forms.Button cmdNew;
        public System.Windows.Forms.TreeView treeMaps;
    }
}