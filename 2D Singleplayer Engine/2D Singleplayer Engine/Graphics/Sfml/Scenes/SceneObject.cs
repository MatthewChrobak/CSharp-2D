using SFML.System;
using SFML.Graphics;

namespace _2D_Singleplayer_Engine.Graphics.Sfml.Scenes
{
    public abstract class SceneObject
    {
        public GraphicalSurface Surface;
        public string Name;
        public int Width;
        public int Height;
        public int Top;
        public int Left;
        public bool HasFocus;
        public bool HasMouse;

        // Automatically get a ZOrder value for every scene object.
        public int Z = ZOrder.GetNewZ();

        // Every scene object is visible by default.
        public bool Visible = true;

        // Object dragging variables.
        public bool Dragable;
        public int xOffset;
        public int yOffset;
        public int originalX;
        public int originalY;

        /// <summary>
        /// A generic method that draws the object's surface in the same position as the object, and having the same size as the object.
        /// </summary>
        public virtual void Draw() {
            // Make sure that the surface is not null.
            if (Surface != null && Surface.Sprite != null) {
                var sprite = Surface.Sprite;

                // Reposition the sprite so that it has the same position as 
                // the scene object.
                sprite.Position = new Vector2f(this.Left, this.Top);

                // Resize the sprite so that it has the same size as 
                // the scene object.
                sprite.Scale = new Vector2f((float)this.Width / sprite.Texture.Size.X, (float)this.Height / sprite.Texture.Size.Y);

                // Pass it off to the backbuffer to draw.
                Sfml.BackBuffer.Draw(sprite);
            }
        }

        /// <summary>
        /// A generic method that handles the beginning of the object being dragged.
        /// </summary>
        /// <param name="x">The location of the mouse on the screen minus the scene object's left value.</param>
        /// <param name="y">The location of the mouse on the screen minus the scene object's top value.</param>
        public virtual void BeginDrag(int x, int y) {
            this.xOffset = x;
            this.yOffset = y;
            this.originalX = this.Left;
            this.originalY = this.Top;
        }

        /// <summary>
        /// A generic method that handles the dragging of the object. Enabling dragging is required.
        /// </summary>
        /// <param name="x">The location of the mouse on the screen minus the scene object's left value.</param>
        /// <param name="y">The location of the mouse on the screen minus the scene object's top value.</param>
        public virtual void Drag(int x, int y) {
            // Make sure we're allowed to drag the object.
            if (this.Dragable) {
                this.Left = x - xOffset;
                this.Top = y - yOffset;
            }
        }

        /// <summary>
        /// A generic method that handles the ending of the dragging of the object.
        /// By default, the object is always reset to its original position. This method is intended to be overriden.
        /// </summary>
        public virtual void EndDrag() {
            // Make sure we're allowed to drag the object.
            if (this.Dragable) {
                // Change the location of the scene object to its original 
                // position before the drag.
                this.Left = originalX;
                this.Top = originalY;
            }
        }

        public void RenderCaption(string value, uint fontsize, Color textcolor) {
            // Create a new SFML text object.
            var text = new Text(value, Sfml.GameFont);

            // Change according properties.
            text.CharacterSize = fontsize;
            text.Color = textcolor;

            // Figure out the centerpoint of the text.
            float centerpoint = text.FindCharacterPos((uint)value.Length).X / 2;

            // Based off of the font size and centerpoint, change the position so 
            // that it's properly centered vertically and horizontally.
            text.Position = new Vector2f(this.Left + (this.Width / 2) - centerpoint, this.Top + (this.Height / 2) - (fontsize / 2));

            // Pass off the text object to the backbuffer to be drawn.
            Sfml.BackBuffer.Draw(text);
        }

        #region Empty virtual methods
        public virtual void MouseUp(int x, int y) {

        }
        public virtual void MouseDown(int x, int y) {

        }
        public virtual void MouseMove(int x, int y) {

        }
        public virtual void KeyDown(string key) {

        }

        public virtual string GetStringValue(string key) {
            return "";
        }
        public virtual int GetIntValue(string key) {
            return 0;
        }
        public virtual bool GetBoolValue(string key) {
            return false;
        }
        #endregion
    }
}
