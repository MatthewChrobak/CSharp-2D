using Networking;
using SFML.Graphics;
using SFML.Window;

namespace Graphics.Sfml.Scenes.Objects
{
    public class Button : SceneObject
    {
        public string Caption;
        public Color TextColor;
        public uint FontSize;

        public override void Draw() {
            // Draw the object.
            base.Draw();

            if ((Caption != null)) {
                var text = new Text(Caption, Sfml.GameFont);
                text.Position = new Vector2f(this.Left + (int)(this.Width - (this.Caption.Length * CapsToSize * this.FontSize)) / 2, this.Top + (this.Height / 2) - (this.FontSize / 2));
                text.Color = TextColor;
            }
        }
    }
}