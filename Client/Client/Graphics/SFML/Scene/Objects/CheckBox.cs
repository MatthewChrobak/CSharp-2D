using SFML.Graphics;
using SFML.Window;

namespace Client.Graphics.SFML.Scene.Objects
{
    public class CheckBox : SceneObject
    {
        public string ImageTag;
        public string Caption;
        public Color TextColor;
        public uint FontSize;
        public bool Checked;

        public override void Draw() {
            if (ImageTag != null) {
                if (Checked) {
                    Sfml.RenderSurface(Sfml.GetSurface(this.ImageTag + "_marked", SurfaceType.Gui), new Vector2f(this.Left, this.Top), new Vector2f(this.Height, this.Height));
                } else {
                    Sfml.RenderSurface(Sfml.GetSurface(this.ImageTag + "_unmarked", SurfaceType.Gui), new Vector2f(this.Left, this.Top), new Vector2f(this.Height, this.Height));
                }

                if (Caption != null) {
                    Sfml.RenderText(this.Caption, new Vector2f(this.Left + this.Height + 7, this.Top + (this.Height / 2) - (this.FontSize / 2)), this.TextColor, this.FontSize, Text.Styles.Regular);
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
