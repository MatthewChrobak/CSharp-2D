namespace Client.Graphics
{
    public interface IScenes : ISystem
    {
        void MouseDown(string button, int x, int y);
        void MouseUp(string button, int x, int y);
        void MouseMove(int x, int y);
        void KeyDown(string key);
        void KeyUp(string key);
    }
}
