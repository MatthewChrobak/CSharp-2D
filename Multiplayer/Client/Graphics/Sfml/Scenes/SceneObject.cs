using SFML.Graphics;
using SFML.System;

namespace Client.Graphics.Sfml.Scenes
{
    public abstract class SceneObject : ISceneObject
    {
        // Scene object properties.
        public GraphicalSurface Surface;
        public string Name = "null";
        public int Width = 100;
        public int Height = 100;
        public int Top = 0;
        public int Left = 0;
        public bool HasFocus;
        public bool HasMouse;

        // Every scene object is visible by default.
        public bool Visible = true;

        // Object dragging variables.
        public bool Dragable;
        public int xOffset;
        public int yOffset;
        public int originalX;
        public int originalY;

        // Passing off the implementation requirement from the parent interface
        // to the inheriting class.
        public abstract string GetObjectType();

        // User defined event handlers.
        public delegate void MouseButtonEventHandler(string button, int x, int y);
        public delegate void MouseEventHandler(int x, int y);
        public delegate void KeyEventHandler(string key);

        public MouseButtonEventHandler MouseDown;
        public MouseButtonEventHandler MouseUp;
        public MouseEventHandler MouseMove;
        public MouseEventHandler EndDrag;

        public KeyEventHandler KeyDown;
        public KeyEventHandler KeyUp;


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

        public void BeginDrag(int x, int y) {
            // The offset begin set is our position within the scene element itself.
            // Otherwise, we'd seem to be dragging the object on the top left.
            this.xOffset = x;
            this.yOffset = y;

            // The original position is kept in case we wish to reset it when we're
            // done dragging.
            this.originalX = this.Left;
            this.originalY = this.Top;
        }

        public void Drag(int x, int y) {
            // Make sure we're allowed to drag the object before
            // chaning the position.
            if (this.Dragable) {
                this.Left = x - this.xOffset;
                this.Top = y - this.yOffset;
            }
        }

        public void EndObjectDrag() {
            // Make sure we're allowed to drag the object.
            if (this.Dragable) {

                // Store the current position for later use.
                int x = this.Left;
                int y = this.Top;

                // Change the position of the scene object to its original
                // position before the end of the drag.
#if !DEBUG
                this.Left = this.originalX;
                this.Top = this.originalY;
#endif

                // Pass off of the old coords in case the user specified
                // an end-drag handler.
                this.EndDrag?.Invoke(x, y);
            }
        }

        public virtual void ObjectMouseUp(string button, int x, int y) {
            // Check for user-specified event handling.
            this.MouseUp?.Invoke(button, x, y);
        }

        public virtual void ObjectMouseDown(string button, int x, int y) {
            // Check for user-specified event handling.
            this.MouseDown?.Invoke(button, x, y);
        }

        public virtual void ObjectMouseMove(int x, int y) {
            // Check for user-specified event handling.
            this.MouseMove?.Invoke(x, y);
        }

        public virtual void ObjectKeyDown(string key) {
            // Check for user-specified event handling.
            this.KeyDown?.Invoke(key);
        }

        public virtual void ObjectKeyUp(string key) {
            // Check for user-specified event handling.
            this.KeyUp?.Invoke(key);
        }

        public virtual string GetStringValue(string key) {
            // Figure out what property is being requested.
            switch (key.ToLower()) {
                case "name":
                    return this.Name;
                case "type":
                    return this.GetObjectType();
                default:
                    throw new PropertyNotFoundException("[" + this.GetObjectType() + "] Property not found - string:" + key);
            }
        }

        public virtual int GetIntValue(string key) {
            // Figure out what property is being requested.s
            switch (key.ToLower()) {
                case "width":
                    return this.Width;
                case "height":
                    return this.Height;
                case "top":
                    return this.Top;
                case "left":
                    return this.Left;
                case "xoffset":
                    return this.xOffset;
                case "yoffset":
                    return this.yOffset;
                case "originalx":
                    return this.originalX;
                case "originaly":
                    return this.originalY;
                default:
                    throw new PropertyNotFoundException("[" + this.GetObjectType() + "] Property not found - int:" + key);
            }
        }

        public virtual bool GetBoolValue(string key) {
            // Figure out what property is being requested.
            switch (key.ToLower()) {
                case "hasfocus":
                    return this.HasFocus;
                case "hasmouse":
                    return this.HasMouse;
                case "visible":
                    return this.Visible;
                default:
                    throw new PropertyNotFoundException("[" + this.GetObjectType() + "] Property not found - bool:" + key);
            }
        }

        protected SceneSystem GetSystem() {
            // If we're using the scene system that this class supports, we have to
            // be using SFML. So we can safely cast the graphics system to type Sfml,
            // and get the scene system through that.
            return ((Sfml)GraphicsManager.Graphics).SceneSystem;
        }

        protected SceneObject GetUIObject(string name) {
            // An extension of the GetSystem() method in this class.
            return GetSystem().GetUIObject(name);
        }
    }
}
