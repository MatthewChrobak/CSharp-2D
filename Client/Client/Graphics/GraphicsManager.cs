namespace Client.Graphics
{
    public class GraphicsManager
    {
        private static iGraphics _graphics;

        public static void Initialize() {
            _graphics = new SFML.Sfml();
            _graphics.Initialize();
        }

        public static void Destroy() {
            _graphics.Destroy();
        }

        public static void Reload() {
            _graphics.Reload();
        }

        public static void Draw() {
            _graphics.Draw();
        }
    }
}
