namespace Client.Graphics
{
    public static class GraphicsManager
    {
        // Directories
        public static readonly string SurfacePath = Client.StartupPath + "data\\surfaces\\";
        public static readonly string GuiPath = GraphicsManager.SurfacePath + "gui\\";
        public static readonly string FontPath = Client.DataPath + "fonts\\";

        // The class object containing the graphics system.
        public static IGraphics Graphics { private set; get; }

        public static void Initialize() {
            // Set and initialize the graphics system.
            GraphicsManager.Graphics = new Sfml.Sfml();
        }
    }
}
