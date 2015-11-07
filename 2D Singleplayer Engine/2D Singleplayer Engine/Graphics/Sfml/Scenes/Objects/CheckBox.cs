using SFML.Graphics;
using SFML.System;

namespace _2D_Singleplayer_Engine.Graphics.Sfml.Scenes.Objects
{
    public class CheckBox : SceneObject
    {
        // Checkboxes have two states: Checked and Unchecked.
        //      -   To store whether or not the object is checked, a boolean
        //          variable is made. 
        //      -   Surface is the surface that represents the checked state.
        //      -   Surface2 is the surface that represents the unchecked state.

        public GraphicalSurface Surface2;
        public bool Checked;
        public string Caption;
        public Color TextColor;
        public uint FontSize;

        public override void Draw() {

            // For this more dynamic scene object, we won't use the
            // base scene object Draw method.

            // Make sure that the surface is not null.
            if (Surface != null && Surface2 != null) {

                // Assume that the checkbox is unchecked.
                var sprite = Surface2.Sprite;
                
                // If the checkbox is checked, overwrite the sprite to be
                // drawn with the checked sprite.
                if (Checked) {
                    sprite = Surface.Sprite;
                }

                // Position the sprite and scale it so that it has the width, height, left and top we want.
                sprite.Position = new Vector2f(this.Left, this.Top);
                sprite.Scale = new Vector2f((float)this.Height / sprite.Texture.Size.X, (float)this.Height / sprite.Texture.Size.Y);
                
                // Pass off the sprite to the backbuffer to be drawn.
                Sfml.BackBuffer.Draw(sprite);
            }

            // To ensure that the checkbox surface doesn't get drawn under our text, we can't
            // use the base RenderCaption method. 
            if (Caption != null) {
                // Create a new SFML text object with the caption.
                var text = new Text(this.Caption, Sfml.GameFont);

                // Change according properties.
                text.Color = this.TextColor;
                text.CharacterSize = this.FontSize;

                // Resposition the text so that it is vertically aligned, is weighted to 
                // the left right after the end of the surface.
                text.Position = new Vector2f(this.Left + this.Width + 7, this.Top + (this.Height / 2) - (this.FontSize / 2));

                // Pass off the text to the backbuffer to be drawn.
                Sfml.BackBuffer.Draw(text);
            }

        }

        public override void MouseDown(int x, int y) {
            // When we click on the object, inverse the checked state.
            Checked = !Checked;
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
