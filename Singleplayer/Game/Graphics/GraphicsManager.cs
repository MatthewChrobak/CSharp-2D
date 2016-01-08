namespace Game.Graphics
{
    public static class GraphicsManager
    {
        // Directories
        public static readonly string SurfacePath = Program.StartupPath + "data\\surfaces\\";
        public static readonly string GuiPath = GraphicsManager.SurfacePath + "gui\\";
        public static readonly string FontPath = Program.DataPath + "fonts\\";

        // The class object containing the graphics system.
        public static IGraphics Graphics { private set; get; }

        public static void Initialize() {
            // Set and initialize the graphics system.
            GraphicsManager.Graphics = new Sfml.Sfml();
        }
    }
}
