using SFML.Graphics;
using SFML.System;

namespace _2D_Singleplayer_Engine.Graphics.Sfml.Scenes.Objects
{
    public class Label : SceneObject
    {
        public string Caption;
        public Color TextColor;
        public uint FontSize;

        public override void Draw() {
            // Draw the caption for the label.
            base.RenderCaption(this.Caption, this.FontSize, this.TextColor);
        }
    }
}
