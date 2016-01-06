using SFML.Graphics;
using SFML.System;

namespace Game.Graphics.Sfml.Scenes.Objects
{
    public class CheckBox : SceneObject
    {
        // Checkboxes have two states: Checked and unchecked.
        //      - this.Surface is the surface that represents the checked state.
        //      - this.SurfaceUnchecked is the surface that represents the unchecked state.

        public GraphicalSurface SurfaceUnchecked;
        public bool Checked;
        public string Caption;
        public Color TextColor;
        public uint FontSize;

        public override void Draw() {
            // No call will be made to the base Draw method.

            // Make sure that the surface is not null.
            if (this.Surface != null && this.SurfaceUnchecked != null) {

                // Reserve space for a surface.
                Sprite sprite;

                // Set the surface based off of the state of the checkbox.
                if (this.Checked) {
                    sprite = this.Surface.Sprite;
                } else {
                    sprite = this.SurfaceUnchecked.Sprite;
                }

                // Position the sprite and scale it so it as the width, 
                // height, left, and top we want.
                sprite.Position = new Vector2f(this.Left, this.Top);
                sprite.Scale = new Vector2f((float)this.Height / sprite.Texture.Size.X, (float)this.Height / sprite.Texture.Size.Y);

                // Pass off the sprite to the graphics manager to be drawn.
                GraphicsManager.Graphics.DrawObject(sprite);

                // To ensure that the checkbox surface doesn't get drawn under our text, we won't
                // use the base RenderCaption method.
                if (Caption?.Length != 0) {
                    // Create a new SFML text object with the caption.
                    var text = new Text(this.Caption, (Font)GraphicsManager.Graphics.GetFont());

                    // Change according properties.
                    text.Color = this.TextColor;
                    text.CharacterSize = this.FontSize;

                    // Reposition the text sot hat it is vertically aligned, is weighted to 
                    // the left right after the end of the surface.
                    text.Position = new Vector2f(this.Left + this.Width + 7, this.Top + (this.Height / 2) - (this.FontSize / 2));

                    // Pass off the text to the graphics manager to be drawn.
                    GraphicsManager.Graphics.DrawObject(text);
                }
            }
        }

        public override void MouseDown(int x, int y) {
            // When we click on the object, inverse the checked state.
            this.Checked = !this.Checked;
        }

        public override bool GetBoolValue(string key) {
            // Allow users to be able to check as to whether or not
            // CheckBox scene objects are checked or not.
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
