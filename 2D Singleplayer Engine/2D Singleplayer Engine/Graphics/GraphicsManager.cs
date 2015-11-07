namespace _2D_Singleplayer_Engine.Graphics
{
    public class GraphicsManager
    {
        // Surface directories.
        public static string SurfacePath = Program.StartupPath + "data\\surfaces\\";
        public static string GuiPath = SurfacePath + "Gui\\";

        // The class object containing the graphics system.
        private static IGraphics _graphics;

        public static void Initialize() {
            // Set and initialize the graphics system inheriting the IGraphics interface.
            _graphics = new Sfml.Sfml();
            _graphics.Initialize();
        }

        #region Static IGraphics Methods
        // Ensure that all IGraphics required methods are included in this manager, so that 
        // we may invoke the graphics system's declaration of the required methods when we invoke the 
        // manager's methods.

        public static void Destroy() {
            // Invoke the graphics system's method of the same name.
            _graphics.Destroy();
        }

        public static void Draw() {
            // Invoke the graphics system's method of the same name.
            _graphics.Draw();
        }
        #endregion
    }
}
