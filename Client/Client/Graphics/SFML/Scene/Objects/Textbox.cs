using SFML.Graphics;
using SFML.Window;

namespace Client.Graphics.SFML.Scene.Objects
{
    public class Textbox : SceneObject
    {
        public string ImageTag;
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
            if (ImageTag != null) {
                Sfml.RenderSurface(Sfml.GetSurface(this.ImageTag, SurfaceType.Gui), new Vector2f(this.Left, this.Top), new Vector2f(this.Width, this.Height));

                if (this.Text != null) {
                    string text = this.Text;

                    // Do we use a password char?
                    if (this.PasswordChar != '\0') {
                        if (text.Length > 0) {
                            string censor = "";
                            for (int i = 0; i < text.Length; i++) {
                                censor += PasswordChar;
                            }
                            text = text.Replace(text, censor);
                        }
                    }

                    if (this.HasFocus) {
                        text += '_';
                    }

                    Sfml.RenderText(text, new Vector2f(this.Left + 7, this.Top + (this.Height / 2) - (this.FontSize / 2)), this.TextColor, this.FontSize, global::SFML.Graphics.Text.Styles.Regular);
                }
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
