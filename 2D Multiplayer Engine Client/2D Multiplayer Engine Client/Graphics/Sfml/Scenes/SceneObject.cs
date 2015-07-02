using SFML.System;
using SFML.Graphics;

namespace _2D_Multiplayer_Engine_Client.Graphics.Sfml.Scenes
{
    public abstract class SceneObject
    {
        private static double CapsToLowerRatio = 0.8;
        private static double CapsToSize = 0.6153846153846154; // 16/26
        private static double LowerToSize = 0.5; // 13/26

        private static int _z = -1;
        private static int getZ() {
            _z++;
            return _z;
        }
        public static void ResetZOrder() {
            _z = -1;
        }

        public GraphicalSurface Surface;
        public string Name;
        public int Width;
        public int Height;
        public int Top;
        public int Left;
        public bool HasFocus;
        public bool HasMouse;
        public int Z = getZ();

        public bool Visible = true;

        public virtual void Draw() {
            if (Surface != null) {
                var sprite = Surface.sprite;
                sprite.Position = new Vector2f(this.Left, this.Top);
                sprite.Scale = new Vector2f((float)this.Width / sprite.Texture.Size.X, (float)this.Height / sprite.Texture.Size.Y);
                Sfml.BackBuffer.Draw(sprite);
            }
        }

        public virtual void MouseDown(int x, int y) {

        }
        public virtual void MouseMove(int x, int y) {

        }
        public virtual void KeyDown(string key) {

        }

        private int GetUpperCount(string text) {
            int count = 0;
            for (int i = 0; i < text.Length; i++) {
                if (char.IsUpper(text[i]))
                    count++;
            }

            return count;
        }

        public double GetRatio(string text) {
            int upperCount = GetUpperCount(text);
            double value = ((upperCount * CapsToSize) + ((text.Length - upperCount) * LowerToSize)) / text.Length;
            return value;
        }


        public virtual string getStringValue(string key) {
            return "";
        }
        public virtual int getIntValue(string key) {
            return 0;
        }
        public virtual bool getBoolValue(string key) {
            return false;
        }
    }
}
