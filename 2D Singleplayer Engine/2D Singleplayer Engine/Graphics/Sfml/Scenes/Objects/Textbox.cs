using SFML.Graphics;
using SFML.System;

namespace _2D_Singleplayer_Engine.Graphics.Sfml.Scenes.Objects {
    public class Textbox : SceneObject {
        public string Text = "";
        public Color TextColor;
        public uint FontSize;
        public int MaxLength;
        public char PasswordChar;

        public override string getStringValue(string key) {
            switch (key.ToLower()) {
                case "text":
                    return this.Text;
                default:
                    return "";
            }
        }

        public override void Draw() {
            // Render the object.
            base.Draw();

            if (this.Text != null) {
                string textboxText = this.Text;

                // Do we use a password char?
                if (this.PasswordChar != '\0') {
                    if (textboxText.Length > 0) {
                        string censor = "";
                        for (int i = 0; i < textboxText.Length; i++) {
                            censor += PasswordChar;
                        }
                        textboxText = textboxText.Replace(textboxText, censor);
                    }
                }

                if (this.HasFocus) {
                    textboxText += '_';
                }

                var text = new Text(textboxText, Sfml.GameFont);
                text.Position = new Vector2f(this.Left + 7, this.Top + (this.Height / 2) - (this.FontSize / 2));
                text.CharacterSize = FontSize;
                text.Color = this.TextColor;
                Sfml.BackBuffer.Draw(text);
            }
        }

        public override void KeyDown(string key) {
            switch (key.ToLower()) {
                case "back":
                    if (this.Text.Length != 0) {
                        this.Text = this.Text.Remove(this.Text.Length - 1);
                    }
                    break;
                default:
                    if (this.Text.Length <= this.MaxLength) {
                        this.Text += key;
                    }
                    break;
            }
        }
    }
}
