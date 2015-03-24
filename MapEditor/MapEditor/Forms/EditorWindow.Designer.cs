namespace MapEditor.Forms
{
    partial class EditorWindow
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
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openCacheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exportToToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importGraphicsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.layersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attributesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tilesetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.attributesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.BottomToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.TopToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.RightToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.LeftToolStripPanel = new System.Windows.Forms.ToolStripPanel();
            this.ContentPanel = new System.Windows.Forms.ToolStripContentPanel();
            this.FolderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.mapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.propertiesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menu
            // 
            this.menu.AutoSize = false;
            this.menu.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.mapToolStripMenuItem,
            this.editorToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(523, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newCacheToolStripMenuItem,
            this.openCacheToolStripMenuItem,
            this.toolStripSeparator1,
            this.exportToToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newCacheToolStripMenuItem
            // 
            this.newCacheToolStripMenuItem.Name = "newCacheToolStripMenuItem";
            this.newCacheToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newCacheToolStripMenuItem.Text = "New Cache";
            this.newCacheToolStripMenuItem.Click += new System.EventHandler(this.newCacheToolStripMenuItem_Click);
            // 
            // openCacheToolStripMenuItem
            // 
            this.openCacheToolStripMenuItem.Name = "openCacheToolStripMenuItem";
            this.openCacheToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openCacheToolStripMenuItem.Text = "Open Cache";
            this.openCacheToolStripMenuItem.Click += new System.EventHandler(this.openCacheToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // exportToToolStripMenuItem
            // 
            this.exportToToolStripMenuItem.Name = "exportToToolStripMenuItem";
            this.exportToToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportToToolStripMenuItem.Text = "Export to...";
            this.exportToToolStripMenuItem.Click += new System.EventHandler(this.exportToToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // editorToolStripMenuItem
            // 
            this.editorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importGraphicsToolStripMenuItem,
            this.copyToolStripMenuItem1});
            this.editorToolStripMenuItem.Name = "editorToolStripMenuItem";
            this.editorToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.editorToolStripMenuItem.Text = "Editor";
            // 
            // importGraphicsToolStripMenuItem
            // 
            this.importGraphicsToolStripMenuItem.Name = "importGraphicsToolStripMenuItem";
            this.importGraphicsToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.importGraphicsToolStripMenuItem.Text = "Import Graphics";
            this.importGraphicsToolStripMenuItem.Click += new System.EventHandler(this.importGraphicsToolStripMenuItem_Click);
            // 
            // copyToolStripMenuItem1
            // 
            this.copyToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.layersToolStripMenuItem,
            this.propertiesToolStripMenuItem,
            this.attributesToolStripMenuItem});
            this.copyToolStripMenuItem1.Name = "copyToolStripMenuItem1";
            this.copyToolStripMenuItem1.Size = new System.Drawing.Size(159, 22);
            this.copyToolStripMenuItem1.Text = "Copy...";
            // 
            // layersToolStripMenuItem
            // 
            this.layersToolStripMenuItem.Name = "layersToolStripMenuItem";
            this.layersToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.layersToolStripMenuItem.Text = "Layers";
            // 
            // propertiesToolStripMenuItem
            // 
            this.propertiesToolStripMenuItem.Name = "propertiesToolStripMenuItem";
            this.propertiesToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.propertiesToolStripMenuItem.Text = "Properties";
            // 
            // attributesToolStripMenuItem
            // 
            this.attributesToolStripMenuItem.Name = "attributesToolStripMenuItem";
            this.attributesToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.attributesToolStripMenuItem.Text = "Attributes";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tilesetToolStripMenuItem,
            this.mapListToolStripMenuItem,
            this.attributesToolStripMenuItem1});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // tilesetToolStripMenuItem
            // 
            this.tilesetToolStripMenuItem.Name = "tilesetToolStripMenuItem";
            this.tilesetToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.tilesetToolStripMenuItem.Text = "Tileset Window";
            this.tilesetToolStripMenuItem.Click += new System.EventHandler(this.tilesetToolStripMenuItem_Click);
            // 
            // mapListToolStripMenuItem
            // 
            this.mapListToolStripMenuItem.Name = "mapListToolStripMenuItem";
            this.mapListToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.mapListToolStripMenuItem.Text = "Map List";
            this.mapListToolStripMenuItem.Click += new System.EventHandler(this.mapListToolStripMenuItem_Click);
            // 
            // attributesToolStripMenuItem1
            // 
            this.attributesToolStripMenuItem1.Name = "attributesToolStripMenuItem1";
            this.attributesToolStripMenuItem1.Size = new System.Drawing.Size(155, 22);
            this.attributesToolStripMenuItem1.Text = "Attributes";
            // 
            // BottomToolStripPanel
            // 
            this.BottomToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.BottomToolStripPanel.Name = "BottomToolStripPanel";
            this.BottomToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.BottomToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.BottomToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // TopToolStripPanel
            // 
            this.TopToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.TopToolStripPanel.Name = "TopToolStripPanel";
            this.TopToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.TopToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TopToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // RightToolStripPanel
            // 
            this.RightToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.RightToolStripPanel.Name = "RightToolStripPanel";
            this.RightToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.RightToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.RightToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // LeftToolStripPanel
            // 
            this.LeftToolStripPanel.Location = new System.Drawing.Point(0, 0);
            this.LeftToolStripPanel.Name = "LeftToolStripPanel";
            this.LeftToolStripPanel.Orientation = System.Windows.Forms.Orientation.Horizontal;
            this.LeftToolStripPanel.RowMargin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.LeftToolStripPanel.Size = new System.Drawing.Size(0, 0);
            // 
            // ContentPanel
            // 
            this.ContentPanel.Size = new System.Drawing.Size(100, 125);
            // 
            // FolderDialog
            // 
            this.FolderDialog.RootFolder = System.Environment.SpecialFolder.DesktopDirectory;
            this.FolderDialog.ShowNewFolderButton = false;
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.FileName = "MapCache.dat";
            this.SaveFileDialog.Filter = "Dat File|*.dat";
            this.SaveFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.SaveFileDialog_FileOk);
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.CheckPathExists = false;
            this.OpenFileDialog.Filter = "Dat Files|*.dat";
            this.OpenFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.OpenFileDialog_FileOk);
            // 
            // mapToolStripMenuItem
            // 
            this.mapToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.propertiesToolStripMenuItem1});
            this.mapToolStripMenuItem.Name = "mapToolStripMenuItem";
            this.mapToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.mapToolStripMenuItem.Text = "Map";
            // 
            // propertiesToolStripMenuItem1
            // 
            this.propertiesToolStripMenuItem1.Name = "propertiesToolStripMenuItem1";
            this.propertiesToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.propertiesToolStripMenuItem1.Text = "Properties";
            this.propertiesToolStripMenuItem1.Click += new System.EventHandler(this.propertiesToolStripMenuItem1_Click);
            // 
            // EditorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(523, 324);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "EditorWindow";
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openCacheToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem attributesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripPanel BottomToolStripPanel;
        private System.Windows.Forms.ToolStripPanel TopToolStripPanel;
        private System.Windows.Forms.ToolStripPanel RightToolStripPanel;
        private System.Windows.Forms.ToolStripPanel LeftToolStripPanel;
        private System.Windows.Forms.ToolStripContentPanel ContentPanel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exportToToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importGraphicsToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog FolderDialog;
        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.ToolStripMenuItem tilesetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newCacheToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem layersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem attributesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mapToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem propertiesToolStripMenuItem1;


    }
}