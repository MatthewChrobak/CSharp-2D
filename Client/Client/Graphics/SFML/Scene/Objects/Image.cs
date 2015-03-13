using SFML.Window;

namespace Client.Graphics.SFML.Scene.Objects
{
    public class Image : SceneObject
    {
        public string ImageTag;

        public override void Draw() {
            if (ImageTag != null) {
                Sfml.RenderSurface(Sfml.GetSurface(this.ImageTag), new Vector2f(this.Left, this.Top), new Vector2f(this.Width, this.Height));
            }
        }
    }
}
