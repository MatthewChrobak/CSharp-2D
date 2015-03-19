namespace Client.Graphics
{
    public enum SurfaceType
    {
        Sprite,
        Paperdoll,
        Item,
        Tileset,
        Gui,
        Length
    }

    public class GraphicsManager
    {
        // Paths
        public static string SurfacePath = Client.StartupPath + "data\\surfaces\\";
        public static string TilesetPath = SurfacePath + "Tilesets\\";
        public static string ItemPath = SurfacePath + "Items\\";
        public static string GuiPath = SurfacePath + "Gui\\";
        public static string PaperdollPath = SurfacePath + "Paperdoll\\";
        public static string SpritePath = SurfacePath + "Sprites\\";

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
