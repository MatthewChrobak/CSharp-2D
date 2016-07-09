using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace MultiplayerEngine_Client.Graphics.Sfml.Scenes
{
    public partial class GuiEditor : Form
    {
        // The object that has the current focus.
        private SceneObject _obj;

        public GuiEditor() {
            InitializeComponent();
        }

        public void LoadObject(ref SceneObject obj) {
            // Store the argument as the current object.
            this._obj = obj;

            // Non-null string variables to be used later.
            string surface = string.Empty;
            string surface2 = string.Empty;
            string caption = string.Empty;
            string length = string.Empty;
            string color = string.Empty;
            string fontsize = string.Empty;
            string passwordchar = string.Empty;

            // Store relative information based on the type of the object.
            switch (obj.GetObjectType().ToLower()) {
                case "image":
                    var img = (Objects.Image)obj;
                    surface = img.Surface?.Tag;
                    break;
                case "label":
                    var lbl = (Objects.Label)obj;
                    caption = lbl.Caption;
                    color = ColorToString(lbl.TextColor);
                    fontsize = lbl.FontSize.ToString();
                    length = "NA";
                    surface = lbl.Surface?.Tag;
                    break;
                case "textbox":
                    var txt = (Objects.Textbox)obj;
                    caption = txt.Text;
                    color = ColorToString(txt.TextColor);
                    fontsize = txt.FontSize.ToString();
                    passwordchar = txt.PasswordChar.ToString();
                    surface = txt.Surface?.Tag;
                    length = txt.MaxLength.ToString();
                    break;
                case "checkbox":
                    var chk = (Objects.CheckBox)obj;
                    caption = chk.Caption;
                    color = ColorToString(chk.TextColor);
                    fontsize = chk.FontSize.ToString();
                    surface = chk.Surface?.Tag;
                    surface2 = chk.SurfaceUnchecked?.Tag;
                    break;
                case "button":
                    var btn = (Objects.Button)obj;
                    caption = btn.Caption;
                    color = ColorToString(btn.TextColor);
                    fontsize = btn.FontSize.ToString();
                    surface = btn.Surface?.Tag;
                    break;
            }

            // Set the textboxes' content based off of the collected information.
            this.txtSurface.Text = surface;
            this.txtSurface2.Text = surface2;
            this.txtCaption.Text = caption;
            this.txtLength.Text = length;
            this.txtColor.Text = color;
            this.txtFontSize.Text = fontsize;
            this.txtPasswordChar.Text = passwordchar;
            this.txtName.Text = obj.Name;
            this.txtWidth.Text = obj.Width.ToString();
            this.txtHeight.Text = obj.Height.ToString();
            this.txtTop.Text = obj.Top.ToString();
            this.txtLeft.Text = obj.Left.ToString();
            this.chkDragable.Checked = obj.Dragable;
        }

        private void GuiEditor_FormClosing(object sender, FormClosingEventArgs e) {
            // Never allow the form to be closed.
            e.Cancel = true;
        }

        private void txtWidth_TextChanged(object sender, System.EventArgs e) {
            // Only modify the object's property if the text is an integer.
            int.TryParse(txtWidth.Text, out _obj.Width);
        }

        private void txtHeight_TextChanged(object sender, System.EventArgs e) {
            // Only modify the object's property if the text is an integer.
            int.TryParse(txtHeight.Text, out _obj.Height);
        }

        private void chkDragable_CheckedChanged(object sender, System.EventArgs e) {
            // 'Dragable' and 'Checked' are the same data type. We can safely
            // modify the object's property.
            _obj.Dragable = chkDragable.Checked;
        }

        private void txtName_TextChanged(object sender, System.EventArgs e) {
            // 'Name' and 'Text" are the same data type. We can safely
            // modify the object's property.
            _obj.Name = txtName.Text;
        }

        private void txtTop_TextChanged(object sender, System.EventArgs e) {
            // Only modify the object's property if the text is an integer.
            int.TryParse(txtTop.Text, out _obj.Top);
        }

        private void txtLeft_TextChanged(object sender, System.EventArgs e) {
            // Only modify the object's property if the text is an integer.
            int.TryParse(txtLeft.Text, out _obj.Left);
        }

        private void txtCaption_TextChanged(object sender, System.EventArgs e) {
            // The only way we can safely modify the caption property is if the 
            // scene object is of a valid type.
            switch (_obj?.GetObjectType().ToLower()) {
                case "label":
                    var lbl = (Objects.Label)_obj;
                    lbl.Caption = txtCaption.Text;
                    break;
                case "textbox":
                    var txt = (Objects.Textbox)_obj;
                    txt.Text = txtCaption.Text;
                    break;
                case "button":
                    var btn = (Objects.Button)_obj;
                    btn.Caption = txtCaption.Text;
                    break;
                case "checkbox":
                    var chk = (Objects.CheckBox)_obj;
                    chk.Caption = txtCaption.Text;
                    break;
            }
        }

        private void txtLength_TextChanged(object sender, System.EventArgs e) {
            // The only way we can safely modify the MaxLength property is if the 
            // scene object is of a valid type.
            switch (_obj?.GetObjectType().ToLower()) {
                case "textbox":
                    var txt = (Objects.Textbox)_obj;
                    int.TryParse(txtLength.Text, out txt.MaxLength);
                    break;
            }
        }

        private void txtFontSize_TextChanged(object sender, System.EventArgs e) {
            // The only way we can safely modify the font size property is if
            // we know the scene object is of a valid type.
            switch (_obj?.GetObjectType().ToLower()) {
                case "label":
                    var lbl = (Objects.Label)_obj;
                    uint.TryParse(txtFontSize.Text, out lbl.FontSize);
                    break;
                case "textbox":
                    var txt = (Objects.Textbox)_obj;
                    uint.TryParse(txtFontSize.Text, out txt.FontSize);
                    break;
                case "button":
                    var btn = (Objects.Button)_obj;
                    uint.TryParse(txtFontSize.Text, out btn.FontSize);
                    break;
                case "checkbox":
                    var chk = (Objects.CheckBox)_obj;
                    uint.TryParse(txtFontSize.Text, out chk.FontSize);
                    break;
            }
        }

        private void txtPasswordChar_TextChanged(object sender, System.EventArgs e) {
            // The only way we can safely modify the password character property is if we know
            // the scene object is of a valid type.
            switch (_obj?.GetObjectType().ToLower()) {
                case "textbox":
                    var txt = (Objects.Textbox)_obj;

                    // If textbox is empty, set the password char to be an empty char.
                    // Otherwise, assign the first character in the textbox's text.
                    if (txtPasswordChar.Text.Length > 0) {
                        txt.PasswordChar = txtPasswordChar.Text[0];
                    } else {
                        txt.PasswordChar = '\0';
                    }
                    break;
            }
        }

        private void cmdGfxReload_Click(object sender, System.EventArgs e) {
            // We can safely cast the graphics manager to Sfml because this class is only compatible with 
            // the Sfml graphics manager. 
            var scene = ((Sfml)GraphicsManager.Graphics).SceneSystem;

            // Try to reassign the scene object's primary surface.
            _obj.Surface = scene.GetSurface(txtSurface.Text);

            // If the scene object is of the valid type, assign the secondary surface.
            switch (_obj.GetObjectType().ToLower()) {
                case "checkbox":
                    var chk = (Objects.CheckBox)_obj;
                    chk.SurfaceUnchecked = scene.GetSurface(txtSurface2.Text);
                    break;
            }
        }

        private void txtColor_TextChanged(object sender, System.EventArgs e) {
            // The only way we can safely modify the text color property is if we know
            // the scene object is of a valid type.
            switch (_obj?.GetObjectType().ToLower()) {
                case "label":
                    var lbl = (Objects.Label)_obj;
                    lbl.TextColor = StringToColor(txtColor.Text);
                    break;
                case "textbox":
                    var txt = (Objects.Textbox)_obj;
                    txt.TextColor = StringToColor(txtColor.Text);
                    break;
                case "button":
                    var btn = (Objects.Button)_obj;
                    btn.TextColor = StringToColor(txtColor.Text);
                    break;
                case "checkbox":
                    var chk = (Objects.CheckBox)_obj;
                    chk.TextColor = StringToColor(txtColor.Text);
                    break;
            }
        }

        private void lstObjects_SelectedIndexChanged(object sender, System.EventArgs e) {
            // Get the index of the currently selected item in the listbox.
            int index = lstObjects.SelectedIndex;

            // Make sure an item in the listbox is actually selected.
            if (index != -1) {
                // Get the scene object at the same index.
                var obj = GetCurrentScene()[index];

                // Load it in the editor.
                this.LoadObject(ref obj);
            }
        }

        private void GuiEditor_Load(object sender, System.EventArgs e) {
            // Clear the listbox for updated entries.
            lstObjects.Items.Clear();

            // Loop through every scene object, and add their names to the 
            // listbox.
            foreach (var obj in GetCurrentScene()) {
                lstObjects.Items.Add(obj.Name);
            }
        }

        private string GetObjectFormat(SceneObject obj) {
            // This method is rather messy, but serves the purpose of formatting out 
            // proper code that gets coppies to your clipboard, so that
            // you can paste it directly into whatever method you use to add objects
            // to your scene system.

            // Although scene objects share base properties in common, there are other 
            // extra properties that can't be formatted in cleanly.
            string type = string.Empty;
            string extra = string.Empty;

            // Store formatted code regarding properties of the specified scene object type into the 
            // 'extra' variable so it can be added to the end-result.
            switch (obj.GetObjectType().ToLower()) {
                case "label":
                    var lbl = (Objects.Label)obj;
                    type = "Objects.Label";
                    extra += "Caption = \"" + lbl.Caption + "\",\n";
                    extra += "\tTextColor = new SFML.Graphics.Color(" + ColorToString(lbl.TextColor) + "),\n";
                    extra += "\tFontSize = " + lbl.FontSize;
                    break;
                case "button":
                    var btn = (Objects.Button)obj;
                    type = "Objects.Button";
                    extra += "Caption = \"" + btn.Caption + "\",\n";
                    extra += "\tTextColor = new SFML.Graphics.Color(" + ColorToString(btn.TextColor) + "),\n";
                    extra += "\tFontSize = " + btn.FontSize;
                    break;
                case "textbox":
                    var txt = (Objects.Textbox)obj;
                    type = "Objects.Textbox";
                    extra += "Text = \"" + txt.Text + "\",\n";
                    extra += "\tTextColor = new SFML.Graphics.Color(" + ColorToString(txt.TextColor) + "),\n";
                    extra += "\tMaxLength = " + txt.MaxLength + ",\n";
                    extra += (txt.PasswordChar == '\0') ? string.Empty : "\tPasswordChar = \'" + txt.PasswordChar + "\',\n";
                    extra += "\tFontSize = " + txt.FontSize;
                    break;
                case "checkbox":
                    var chk = (Objects.CheckBox)obj;
                    type = "Objects.CheckBox";
                    extra += "SurfaceUnchecked = GetSurface(\"" + chk.SurfaceUnchecked.Tag + "\"),\n";
                    extra += "\tCaption = \"" + chk.Caption + "\",\n";
                    extra += "\tTextColor = new SFML.Graphics.Color(" + ColorToString(chk.TextColor) + "),\n";
                    extra += "\tFontSize = " + chk.FontSize;
                    break;
                case "image":
                    type = "Objects.Image";
                    break;
            }

            // Create the final formatted string.
            return string.Format(@"var {0} = new {1}() {{
    Name = ""{0}"",
    Width = {2},
    Height = {3},
    Top = {4},
    Left = {5},
    Surface = GetSurface(""{6}""),
    {7}{8}
}};",
                // {0}      {1}
                obj.Name, type,

                // {2}      {3}
                obj.Width, obj.Height,

                // {4}      {5}
                obj.Top, obj.Left,

                // {6}
                obj.Surface != null ? obj.Surface.Tag : string.Empty,

                // {7}
                obj.Dragable ? "Dragable = true,\n" : string.Empty,

                // {8}
                extra);
        }

        private void cmdExport_Click(object sender, System.EventArgs e) {
            // Get the formatted string of the current scene object, and
            // copy it to the clipboard.
            StringToClipboard(GetObjectFormat(_obj));
        }

        private void cmdExportAll_Click(object sender, System.EventArgs e) {
            // We can safely cast the graphics manager to Sfml because this
            // GuiEditor only works with Sfml as the graphics manager.
            var scene = ((Sfml)GraphicsManager.Graphics).SceneSystem;

            // Create an empty string to store the entirety of the
            // scene system's objects' formatted code.
            string output = string.Empty;

            // Loop through every scene object in the current scene, and
            // add their formatted code to the output variable.
            foreach (var obj in scene._UIObject[(int)Client.State]) {
                output += GetObjectFormat(obj) + "\n";
            }

            // Finally, copy the formatted string to the clipboard.
            StringToClipboard(output);
        }

        private void StringToClipboard(string value) {
            // Create a thread that will copy the formatted code 
            // to the clipboard.
            Thread thread = new Thread(() => Clipboard.SetText(value));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();

            // Sleep until it's finished.
            thread.Join();

            // Display a message when it's done.
            MessageBox.Show("Coppied to clipboard");
        }

        private string ColorToString(SFML.Graphics.Color color) {
            // Convert the SFML color into either an R,G,B or R,G,B,A
            // formatted string.
            string value = color.R + "," + color.G + "," + color.B;
            value += (color.A != 0) ? "," + color.A : string.Empty;
            return value;
        }

        private SFML.Graphics.Color StringToColor(string color) {
            // Create a byte array meant to store the correctly parsed byte values.
            byte[] colors = new byte[4];

            // Split the given string at the commas to attain individual RGBA values.
            var splitString = color.Split(',');

            // If the string does not contain 3 or 4 values, it can't be a variation of RGBA.
            if (splitString.Length != 3 && splitString.Length != 4) {
                return SFML.Graphics.Color.Transparent;
            } else if (splitString.Length == 3) {
                // If there are only 3 values, it's RGB and the A value is 255.
                colors[3] = 255;
            }

            // Loop through each value, and try to parse it to a byte.
            // If the parse does not work, we have an invalid color and we return transparency. 
            for (int i = 0; i < splitString.Length; i++) {
                if (!byte.TryParse(splitString[i], out colors[i])) {
                    return SFML.Graphics.Color.Transparent;
                }
            }

            // Return a new SFML color based off of the values given.
            return new SFML.Graphics.Color(colors[0], colors[1], colors[2], colors[3]);
        }

        private void RefreshLstObjects() {
            // Clear the listbox to make room for updated items.
            lstObjects.Items.Clear();

            // Loop through every scene object in the scene system, and
            // add their names to the listbox.
            foreach (var obj in GetCurrentScene()) {
                lstObjects.Items.Add(obj.Name);
            }
        }

        private void txtName_Leave(object sender, System.EventArgs e) {
            // Get the index of the currently focused scene object.
            int index = lstObjects.SelectedIndex;

            // Refresh the listbox so that the name updates.
            RefreshLstObjects();

            // If there was a focused scene object, re-load it and re-select it.
            if (index != -1) {
                var obj = GetCurrentScene()[index];
                this.LoadObject(ref obj);
                lstObjects.SelectedIndex = index;
            }
        }

        private List<SceneObject> GetCurrentScene() {
            // We can safely cast the graphics manager to Sfml because this GuiEditor
            // only works with Sfml as the graphics manager.
            return ((Sfml)GraphicsManager.Graphics).SceneSystem._UIObject[(int)Client.State];
        }

        private void txtLabel_Click(object sender, System.EventArgs e) {
            // Add a new label scene object to the current scene system, and
            // refresh the listbox's contents.
            GetCurrentScene().Add(new Objects.Label());
            RefreshLstObjects();
        }

        private void cmdImage_Click(object sender, System.EventArgs e) {
            // Add a new image scene object to the current scene system, and
            // refresh the listbox's contents.
            GetCurrentScene().Add(new Objects.Image());
            RefreshLstObjects();
        }

        private void cmdTextBox_Click(object sender, System.EventArgs e) {
            // Add a new textbox scene object to the current scene system, and
            // refresh the listbox's contents.
            GetCurrentScene().Add(new Objects.Textbox());
            RefreshLstObjects();
        }

        private void cmdButton_Click(object sender, System.EventArgs e) {
            // Add a new button scene object to the current scene system, and
            // refresh the listbox's contents.
            GetCurrentScene().Add(new Objects.Button());
            RefreshLstObjects();
        }

        private void cmdCheckbox_Click(object sender, System.EventArgs e) {
            // Add a new checkbox scene object to the current scene system, and
            // refresh the listbox's contents.
            GetCurrentScene().Add(new Objects.CheckBox());
            RefreshLstObjects();
        }

        private void cmdDelete_Click(object sender, System.EventArgs e) {
            // Delete the focused scene object from the current scene system, and
            // refresh the listbox's contents.
            GetCurrentScene().Remove(this._obj);
            RefreshLstObjects();
        }
    }
}
