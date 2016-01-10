using SFML.Graphics;
using SFML.System;

namespace Client.Graphics.Sfml.Scenes
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
        public int Z { private set; get; } = ZOrder.GetNewZ();

        // Every scene object is visible by default.
        public bool Visible = true;

        // Object dragging variables.
        public bool Dragable;
        public int xOffset;
        public int yOffset;
        public int originalX;
        public int originalY;

        public virtual void Draw() {
            // Make sure that the surface is not null.
            if (this.Surface?.Sprite != null) {
                var sprite = this.Surface.Sprite;

                // Reposition the sprite so that it has the same position as
                // the scene object.
                sprite.Position = new Vector2f(this.Left, this.Top);

                // Resize the sprite so it has the same size as
                // the scene object.
                sprite.Scale = new Vector2f((float)this.Width / sprite.Texture.Size.X,
                    (float)this.Height / sprite.Texture.Size.Y);

                // Pass it off to the graphics system to draw.
                GraphicsManager.Graphics.DrawObject(sprite);
            }
        }

        public virtual void BeginDrag(int x, int y) {
            this.xOffset = x;
            this.yOffset = y;
            this.originalX = this.Left;
            this.originalY = this.Top;
        }

        public virtual void Drag(int x, int y) {
            // Make sure we're allowed to drag the object before
            // chaning the position.
            if (this.Dragable) {
                this.Left = x - this.xOffset;
                this.Top = y - this.yOffset;
            }
        }

        public virtual void EndDrag() {
            // Make sure we're allowed to drag the object.
            if (this.Dragable) {
                // Change the position of the scene object to its original
                // position before the drag.
                this.Left = this.originalX;
                this.Top = this.originalY;
            }
        }

        public void RenderCaption(string value, uint fontsize, Color textcolor) {

            // Make sure the text is not null.
            if (value == null) {
                return;
            }

            // Create a new SFML text object.
            var text = new Text(value, (Font)GraphicsManager.Graphics.GetFont());

            // Change according properties.
            text.CharacterSize = fontsize;
            text.Color = textcolor;

            // Figure out the centerpoint of the text.
            float centerpoint = text.FindCharacterPos((uint)value.Length).X / 2;

            // Based off of the font size and centerpoint, change the position so
            // that it's properly centered vertically and horizontally.
            text.Position = new Vector2f(this.Left + (this.Width / 2) - centerpoint,
                this.Top + (this.Height / 2) - (fontsize / 2));

            // Pass the text object off to the graphics system to draw.
            GraphicsManager.Graphics.DrawObject(text);
        }

        public virtual void MouseUp(int x, int y) {

        }

        public virtual void MouseDown(int x, int y) {

        }

        public virtual void MouseMove(int x, int y) {

        }

        public virtual void KeyDown(string key) {

        }

        public virtual void KeyUp(string key) {

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
    }
}
