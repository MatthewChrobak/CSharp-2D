using Client.Networking;
using SFML.Graphics;
using SFML.Window;

namespace Client.Graphics.SFML.Scene.Objects
{
    public class Button : SceneObject
    {
        public string ImageTag;
        public string Caption;
        public Color TextColor;
        public uint FontSize;

        public override void Draw() {
            if (ImageTag != null) {
                Sfml.RenderSurface(Sfml.GetSurface(this.ImageTag, SurfaceType.Gui), new Vector2f(this.Left, this.Top), new Vector2f(this.Width, this.Height));
                if ((Caption != null)) {
                    Sfml.RenderText(Caption, new Vector2f(this.Left + (int)(this.Width - (this.Caption.Length * CapsToSize * this.FontSize)) / 2, this.Top + (this.Height / 2) - (this.FontSize / 2)), this.TextColor, this.FontSize, Text.Styles.Regular);
                }
            }
        }
    }
}