namespace MultiplayerEngine_Client.Graphics
{
    public interface IGraphics : ISystem
    {
        void DrawObject(object surface);
        object GetFont();
    }
}
