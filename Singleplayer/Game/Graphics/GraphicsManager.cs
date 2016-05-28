namespace Game.Graphics
{
    public static class GraphicsManager
    {
        // Directories
        public static readonly string SurfacePath = Game.StartupPath + "Data\\Surfaces\\";
        public static readonly string GuiPath = GraphicsManager.SurfacePath + "Gui\\";
        public static readonly string FontPath = Game.DataPath + "Fonts\\";

        // The class object containing the graphics system.
        public static IGraphics Graphics { private set; get; }

        // Window size properties.
        public static uint WindowWidth = 960;
        public static uint WindowHeight = 640;

        // Drawing space size.
        public const uint DrawWidth = 960;
        public const uint DrawHeight = 640;

        // WindowSize to DrawingSpace ratios.
        public static float WidthRatio = 1f;
        public static float HeightRatio = 1f;


        public static void Initialize() {
            // Set and initialize the graphics system.
            GraphicsManager.Graphics = new Sfml.Sfml();
        }
    }
}
