namespace MapEditor.Forms
{
    partial class LayerTreeWindow
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Mask");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Fringe");
            this.cmdNew = new System.Windows.Forms.Button();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.treeLayers = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // cmdNew
            // 
            this.cmdNew.BackColor = System.Drawing.SystemColors.Control;
            this.cmdNew.Location = new System.Drawing.Point(12, 266);
            this.cmdNew.Name = "cmdNew";
            this.cmdNew.Size = new System.Drawing.Size(81, 42);
            this.cmdNew.TabIndex = 8;
            this.cmdNew.Text = "Add";
            this.cmdNew.UseVisualStyleBackColor = false;
            this.cmdNew.Click += new System.EventHandler(this.cmdNew_Click);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(116, 266);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(81, 42);
            this.cmdDelete.TabIndex = 7;
            this.cmdDelete.Text = "Remove";
            this.cmdDelete.UseVisualStyleBackColor = true;
            // 
            // treeLayers
            // 
            this.treeLayers.Location = new System.Drawing.Point(12, 12);
            this.treeLayers.Name = "treeLayers";
            treeNode1.Name = "Mask";
            treeNode1.Text = "Mask";
            treeNode2.Name = "Fringe";
            treeNode2.Text = "Fringe";
            this.treeLayers.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            this.treeLayers.Size = new System.Drawing.Size(186, 296);
            this.treeLayers.TabIndex = 6;
            // 
            // LayerTreeWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(210, 315);
            this.Controls.Add(this.cmdNew);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.treeLayers);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "LayerTreeWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LayerTreeWindow_FormClosing);
            this.Resize += new System.EventHandler(this.LayerTreeWindow_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdNew;
        private System.Windows.Forms.Button cmdDelete;
        public System.Windows.Forms.TreeView treeLayers;
    }
}