using SFML.Graphics;
using SFML.Window;

namespace Graphics.Sfml.Scenes.Objects
{
    public class CheckBox : SceneObject
    {
        public GraphicalSurface Surface2;
        public string Caption;
        public Color TextColor;
        public uint FontSize;
        public bool Checked;

        public override void Draw() {
            if (Surface != null) {
                var sprite = Surface2.sprite;
                if (Checked) {
                    sprite = Surface.sprite;
                }

                sprite.Position = new Vector2f(this.Left, this.Top);
                sprite.Scale = new Vector2f((float)this.Height / sprite.Texture.Size.X, (float)this.Height / sprite.Texture.Size.Y);
                Sfml.BackBuffer.Draw(sprite);

                if (Caption != null) {
                    var text = new Text(this.Caption, Sfml.GameFont);
                    text.Position = new Vector2f(this.Left + this.Height + 7, this.Top + (this.Height / 2) - (this.FontSize / 2));
                    text.Color = this.TextColor;
                    text.CharacterSize = this.FontSize;
                    Sfml.BackBuffer.Draw(text);
                }
            }
        }

        public override void MouseDown(int x, int y) {
            Checked = !Checked;
        }

        public override bool getBoolValue(string key) {
            switch (key.ToLower()) {
                case "value":
                case "checked":
                    return this.Checked;
                default:
                    return false;
            }
        }
    }
}
