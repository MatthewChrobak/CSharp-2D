namespace _2D_Multiplayer_Engine_Client.Graphics
{
    public enum SurfaceType
    {
        Length
    }

    public class GraphicsManager
    {
        // Surface paths
        public static string SurfacePath = Program.StartupPath + "data\\surfaces\\";
        public static string GuiPath = SurfacePath + "Gui\\";

        private static IGraphics _graphics;

        public static void Initialize() {
            _graphics = new Sfml.Sfml();
            _graphics.Initialize();
        }

        public static void Destroy() {
            _graphics.Destroy();
        }

        public static void Draw() {
            _graphics.Draw();
        }
    }
}
