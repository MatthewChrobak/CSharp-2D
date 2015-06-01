using Client;

namespace Graphics
{
    public enum SurfaceType
    {
        Sprite,
        Paperdoll,
        Item,
        Tileset,
        Length
    }

    public class GraphicsManager
    {
        // Paths
        public static string SurfacePath = Application.StartupPath + "data\\surfaces\\";
        public static string TilesetPath = SurfacePath + "Tilesets\\";
        public static string ItemPath = SurfacePath + "Items\\";
        public static string GuiPath = SurfacePath + "Gui\\";
        public static string PaperdollPath = SurfacePath + "Paperdoll\\";
        public static string SpritePath = SurfacePath + "Sprites\\";

        private static IGraphics _graphics;

        public static void Initialize() {
            _graphics = new Sfml.Sfml();
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
