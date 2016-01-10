using SFML.Graphics;

namespace Client.Graphics.Sfml.Scenes.Objects
{
    public class Button : SceneObject
    {
        public string Caption;
        public Color TextColor;
        public uint FontSize;

        public override void Draw() {
            // Draw the surface if we have one.
            base.Draw();

            // Draw the button's caption.
            base.RenderCaption(this.Caption, this.FontSize, this.TextColor);
        }
    }
}
