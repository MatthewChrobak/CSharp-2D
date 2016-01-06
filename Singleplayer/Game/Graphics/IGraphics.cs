namespace Game.Graphics
{
    public interface IGraphics : ISystem
    {
        void DrawObject(object surface);
        object GetFont();
    }
}
