namespace SingleplayerEngine.Graphics.Sfml.Scenes
{
    partial class GuiEditor
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
            this.txtName = new System.Windows.Forms.TextBox();
            this.cmdGfxReload = new System.Windows.Forms.Button();
            this.txtTop = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.txtLeft = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSurface = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCaption = new System.Windows.Forms.TextBox();
            this.txtFontSize = new System.Windows.Forms.TextBox();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtSurface2 = new System.Windows.Forms.TextBox();
            this.txtPasswordChar = new System.Windows.Forms.TextBox();
            this.cmdTextBox = new System.Windows.Forms.Button();
            this.txtLabel = new System.Windows.Forms.Button();
            this.cmdImage = new System.Windows.Forms.Button();
            this.cmdCheckbox = new System.Windows.Forms.Button();
            this.cmdButton = new System.Windows.Forms.Button();
            this.cmdExport = new System.Windows.Forms.Button();
            this.chkDragable = new System.Windows.Forms.CheckBox();
            this.cmdExportAll = new System.Windows.Forms.Button();
            this.lstObjects = new System.Windows.Forms.ListBox();
            this.cmdDelete = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(191, 25);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(123, 20);
            this.txtName.TabIndex = 0;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            // 
            // cmdGfxReload
            // 
            this.cmdGfxReload.Location = new System.Drawing.Point(206, 385);
            this.cmdGfxReload.Name = "cmdGfxReload";
            this.cmdGfxReload.Size = new System.Drawing.Size(75, 23);
            this.cmdGfxReload.TabIndex = 1;
            this.cmdGfxReload.Text = "GFX Reload";
            this.cmdGfxReload.UseVisualStyleBackColor = true;
            this.cmdGfxReload.Click += new System.EventHandler(this.cmdGfxReload_Click);
            // 
            // txtTop
            // 
            this.txtTop.Location = new System.Drawing.Point(320, 109);
            this.txtTop.Name = "txtTop";
            this.txtTop.Size = new System.Drawing.Size(123, 20);
            this.txtTop.TabIndex = 2;
            this.txtTop.TextChanged += new System.EventHandler(this.txtTop_TextChanged);
            // 
            // txtHeight
            // 
            this.txtHeight.Location = new System.Drawing.Point(191, 135);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(123, 20);
            this.txtHeight.TabIndex = 3;
            this.txtHeight.TextChanged += new System.EventHandler(this.txtHeight_TextChanged);
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(191, 109);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(123, 20);
            this.txtWidth.TabIndex = 4;
            this.txtWidth.TextChanged += new System.EventHandler(this.txtWidth_TextChanged);
            // 
            // txtLeft
            // 
            this.txtLeft.Location = new System.Drawing.Point(320, 135);
            this.txtLeft.Name = "txtLeft";
            this.txtLeft.Size = new System.Drawing.Size(123, 20);
            this.txtLeft.TabIndex = 5;
            this.txtLeft.TextChanged += new System.EventHandler(this.txtLeft_TextChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(188, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Width / Height";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(314, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Top / Left";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(188, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Name";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(188, 184);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Surface";
            // 
            // txtSurface
            // 
            this.txtSurface.Location = new System.Drawing.Point(191, 200);
            this.txtSurface.Name = "txtSurface";
            this.txtSurface.Size = new System.Drawing.Size(123, 20);
            this.txtSurface.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(317, 247);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(126, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "Color / FontSize / P-Char";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(191, 246);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Caption / Length";
            // 
            // txtCaption
            // 
            this.txtCaption.Location = new System.Drawing.Point(194, 263);
            this.txtCaption.Name = "txtCaption";
            this.txtCaption.Size = new System.Drawing.Size(123, 20);
            this.txtCaption.TabIndex = 15;
            this.txtCaption.TextChanged += new System.EventHandler(this.txtCaption_TextChanged);
            // 
            // txtFontSize
            // 
            this.txtFontSize.Location = new System.Drawing.Point(323, 289);
            this.txtFontSize.Name = "txtFontSize";
            this.txtFontSize.Size = new System.Drawing.Size(123, 20);
            this.txtFontSize.TabIndex = 14;
            this.txtFontSize.TextChanged += new System.EventHandler(this.txtFontSize_TextChanged);
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(323, 263);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(123, 20);
            this.txtColor.TabIndex = 13;
            this.txtColor.TextChanged += new System.EventHandler(this.txtColor_TextChanged);
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(194, 289);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(123, 20);
            this.txtLength.TabIndex = 18;
            this.txtLength.TextChanged += new System.EventHandler(this.txtLength_TextChanged);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(320, 184);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Surface 2";
            // 
            // txtSurface2
            // 
            this.txtSurface2.Location = new System.Drawing.Point(323, 200);
            this.txtSurface2.Name = "txtSurface2";
            this.txtSurface2.Size = new System.Drawing.Size(123, 20);
            this.txtSurface2.TabIndex = 19;
            // 
            // txtPasswordChar
            // 
            this.txtPasswordChar.Location = new System.Drawing.Point(323, 315);
            this.txtPasswordChar.Name = "txtPasswordChar";
            this.txtPasswordChar.Size = new System.Drawing.Size(123, 20);
            this.txtPasswordChar.TabIndex = 21;
            this.txtPasswordChar.TextChanged += new System.EventHandler(this.txtPasswordChar_TextChanged);
            // 
            // cmdTextBox
            // 
            this.cmdTextBox.Location = new System.Drawing.Point(17, 414);
            this.cmdTextBox.Name = "cmdTextBox";
            this.cmdTextBox.Size = new System.Drawing.Size(75, 23);
            this.cmdTextBox.TabIndex = 22;
            this.cmdTextBox.Text = "Textbox";
            this.cmdTextBox.UseVisualStyleBackColor = true;
            this.cmdTextBox.Click += new System.EventHandler(this.cmdTextBox_Click);
            // 
            // txtLabel
            // 
            this.txtLabel.Location = new System.Drawing.Point(17, 385);
            this.txtLabel.Name = "txtLabel";
            this.txtLabel.Size = new System.Drawing.Size(75, 23);
            this.txtLabel.TabIndex = 23;
            this.txtLabel.Text = "Label";
            this.txtLabel.UseVisualStyleBackColor = true;
            this.txtLabel.Click += new System.EventHandler(this.txtLabel_Click);
            // 
            // cmdImage
            // 
            this.cmdImage.Location = new System.Drawing.Point(98, 385);
            this.cmdImage.Name = "cmdImage";
            this.cmdImage.Size = new System.Drawing.Size(75, 23);
            this.cmdImage.TabIndex = 25;
            this.cmdImage.Text = "Image";
            this.cmdImage.UseVisualStyleBackColor = true;
            this.cmdImage.Click += new System.EventHandler(this.cmdImage_Click);
            // 
            // cmdCheckbox
            // 
            this.cmdCheckbox.Location = new System.Drawing.Point(98, 414);
            this.cmdCheckbox.Name = "cmdCheckbox";
            this.cmdCheckbox.Size = new System.Drawing.Size(75, 23);
            this.cmdCheckbox.TabIndex = 24;
            this.cmdCheckbox.Text = "Checkbox";
            this.cmdCheckbox.UseVisualStyleBackColor = true;
            this.cmdCheckbox.Click += new System.EventHandler(this.cmdCheckbox_Click);
            // 
            // cmdButton
            // 
            this.cmdButton.Location = new System.Drawing.Point(63, 443);
            this.cmdButton.Name = "cmdButton";
            this.cmdButton.Size = new System.Drawing.Size(75, 23);
            this.cmdButton.TabIndex = 26;
            this.cmdButton.Text = "Button";
            this.cmdButton.UseVisualStyleBackColor = true;
            this.cmdButton.Click += new System.EventHandler(this.cmdButton_Click);
            // 
            // cmdExport
            // 
            this.cmdExport.Location = new System.Drawing.Point(287, 385);
            this.cmdExport.Name = "cmdExport";
            this.cmdExport.Size = new System.Drawing.Size(75, 23);
            this.cmdExport.TabIndex = 27;
            this.cmdExport.Text = "Export";
            this.cmdExport.UseVisualStyleBackColor = true;
            this.cmdExport.Click += new System.EventHandler(this.cmdExport_Click);
            // 
            // chkDragable
            // 
            this.chkDragable.AutoSize = true;
            this.chkDragable.Location = new System.Drawing.Point(191, 51);
            this.chkDragable.Name = "chkDragable";
            this.chkDragable.Size = new System.Drawing.Size(69, 17);
            this.chkDragable.TabIndex = 28;
            this.chkDragable.Text = "Dragable";
            this.chkDragable.UseVisualStyleBackColor = true;
            this.chkDragable.CheckedChanged += new System.EventHandler(this.chkDragable_CheckedChanged);
            // 
            // cmdExportAll
            // 
            this.cmdExportAll.Location = new System.Drawing.Point(368, 385);
            this.cmdExportAll.Name = "cmdExportAll";
            this.cmdExportAll.Size = new System.Drawing.Size(75, 23);
            this.cmdExportAll.TabIndex = 29;
            this.cmdExportAll.Text = "Export All";
            this.cmdExportAll.UseVisualStyleBackColor = true;
            this.cmdExportAll.Click += new System.EventHandler(this.cmdExportAll_Click);
            // 
            // lstObjects
            // 
            this.lstObjects.FormattingEnabled = true;
            this.lstObjects.Location = new System.Drawing.Point(12, 9);
            this.lstObjects.Name = "lstObjects";
            this.lstObjects.Size = new System.Drawing.Size(170, 368);
            this.lstObjects.TabIndex = 30;
            this.lstObjects.SelectedIndexChanged += new System.EventHandler(this.lstObjects_SelectedIndexChanged);
            // 
            // cmdDelete
            // 
            this.cmdDelete.Location = new System.Drawing.Point(278, 435);
            this.cmdDelete.Name = "cmdDelete";
            this.cmdDelete.Size = new System.Drawing.Size(75, 23);
            this.cmdDelete.TabIndex = 31;
            this.cmdDelete.Text = "Delete";
            this.cmdDelete.UseVisualStyleBackColor = true;
            this.cmdDelete.Click += new System.EventHandler(this.cmdDelete_Click);
            // 
            // GuiEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 470);
            this.Controls.Add(this.cmdDelete);
            this.Controls.Add(this.lstObjects);
            this.Controls.Add(this.cmdExportAll);
            this.Controls.Add(this.chkDragable);
            this.Controls.Add(this.cmdExport);
            this.Controls.Add(this.cmdButton);
            this.Controls.Add(this.cmdImage);
            this.Controls.Add(this.cmdCheckbox);
            this.Controls.Add(this.txtLabel);
            this.Controls.Add(this.cmdTextBox);
            this.Controls.Add(this.txtPasswordChar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtSurface2);
            this.Controls.Add(this.txtLength);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtCaption);
            this.Controls.Add(this.txtFontSize);
            this.Controls.Add(this.txtColor);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtSurface);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtLeft);
            this.Controls.Add(this.txtWidth);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.txtTop);
            this.Controls.Add(this.cmdGfxReload);
            this.Controls.Add(this.txtName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GuiEditor";
            this.Text = "GuiEditor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.GuiEditor_FormClosing);
            this.Load += new System.EventHandler(this.GuiEditor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button cmdGfxReload;
        private System.Windows.Forms.TextBox txtTop;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.TextBox txtLeft;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSurface;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCaption;
        private System.Windows.Forms.TextBox txtFontSize;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtSurface2;
        private System.Windows.Forms.TextBox txtPasswordChar;
        private System.Windows.Forms.Button cmdTextBox;
        private System.Windows.Forms.Button txtLabel;
        private System.Windows.Forms.Button cmdImage;
        private System.Windows.Forms.Button cmdCheckbox;
        private System.Windows.Forms.Button cmdButton;
        private System.Windows.Forms.Button cmdExport;
        private System.Windows.Forms.CheckBox chkDragable;
        private System.Windows.Forms.Button cmdExportAll;
        private System.Windows.Forms.ListBox lstObjects;
        private System.Windows.Forms.Button cmdDelete;
    }
}