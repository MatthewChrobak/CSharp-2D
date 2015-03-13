namespace Client.Graphics.SFML.Scene
{
    public abstract class SceneObject
    {
        public static double CapsToLowerRatio = 0.8;
        public static double CapsToSize = 0.6153846153846154; // 16/26
        public static double LowerToSize = 0.5; // 13/26

        public string Name;
        public int Width;
        public int Height;
        public int Top;
        public int Left;
        public bool HasFocus;
        public bool HasMouse;
        public int Z = SceneManager.getZ();

        public bool Visible = true;

        public virtual void Draw() {

        }

        public virtual void MouseDown(int x, int y) {

        }
        public virtual void MouseMove(int x, int y) {

        }
        public virtual void KeyDown(string key) {

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
