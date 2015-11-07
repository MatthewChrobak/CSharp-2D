using SFML.Graphics;
using SFML.System;

namespace _2D_Singleplayer_Engine.Graphics.Sfml.Scenes.Objects
{
    public class Textbox : SceneObject
    {
        public string Text = "";
        public Color TextColor;
        public uint FontSize;
        public int MaxLength;
        public char PasswordChar;

        public override void Draw() {
            // Render the object's surface.
            base.Draw();


            // Store the textbox's text as a variable.
            string textboxText = this.Text;

            // Do we use a password char?
            if (this.PasswordChar != '\0') {
                // Does the textbox actually have text in it?
                if (textboxText.Length > 0) {

                    // Replace every character in the textbox's text 
                    // with the password character.
                    string censor = "";
                    for (int i = 0; i < textboxText.Length; i++) {
                        censor += PasswordChar;
                    }
                    textboxText = censor;
                }
            }

            // If the textbox has our focus, add an underscore to signify focus.
            if (this.HasFocus) {
                textboxText += '_';
            }

            // Create a new SFML text object with the textbox's text.
            var text = new Text(textboxText, Sfml.GameFont);

            // Change according properties.
            text.CharacterSize = FontSize;
            text.Color = this.TextColor;

            // Position the text so that it is weighted to the left of the textbox, and is vertically aligned.
            text.Position = new Vector2f(this.Left + 7, this.Top + (this.Height / 2) - (this.FontSize / 2));

            // Pass the text off to the backbuffer to be drawn.
            Sfml.BackBuffer.Draw(text);
        }

        public override void KeyDown(string key) {
            switch (key.ToLower()) {
                case "back":
                    // If the backspace button is pressed when this object has the focus then
                    // remove the last character from the textbox's text.
                    if (this.Text.Length != 0) {
                        this.Text = this.Text.Remove(this.Text.Length - 1);
                    }
                    break;
                default:
                    // Add the character for the key pressed to the textbox's text.
                    if (this.Text.Length <= this.MaxLength) {
                        this.Text += key;
                    }
                    break;
            }
        }

        public override string GetStringValue(string key) {
            // Allow users to be able to get the text from this object.
            switch (key.ToLower()) {
                case "caption":
                case "text":
                    return this.Text;
                default:
                    return "";
            }
        }
    }
}
