using AnnexEngine.Graphics.Resources;
using AnnexEngine.Graphics.Resources.Contexts;
using SFML.Graphics;

namespace AnnexEngine.Graphics.Devices.Sfml
{
    /// <summary>
    /// A graphical device implemented using SFML.
    /// </summary>
    public class Device : IGraphicalDevice
    {
        /// <summary>
        /// Resource managers for all the surfaces and fonts.
        /// </summary>
        private ResourceManager<Sprite> _surfaces;
        private ResourceManager<Font> _fonts;

        private Window _window;

        /// <summary>
        /// Creates the SFML device, and loads all the necessary resources.
        /// </summary>
        public Device()
        {
            // Load all the required resources.
            this.LoadResources();

            // Create a new window.
            this._window = new Window("Sfml Demo");
        }

        /// <summary>
        /// Loads all the resources needed to draw surfaces and text.
        /// </summary>
        private void LoadResources()
        {
            // Initialize the managers.
            this._surfaces = new ResourceManager<Sprite>();
            this._fonts = new ResourceManager<Font>();

            // Load all the .png images from the GraphicsPath.
            this._surfaces.LoadFiles(GraphicsManager.GraphicsPath, 
                filepath => new Sprite(new Texture(filepath)), 
                filepath => filepath.EndsWith(".png")
                );

            // Load all the .ttf fonts from the FontPath.
            this._fonts.LoadFiles(GraphicsManager.FontPath,
                filepath => new Font(filepath),
                filepath => filepath.EndsWith(".ttf")
                );
        }

        /// <summary>
        /// Draws the device.
        /// </summary>
        public void Draw()
        {
            // Capture events from the mouse and keyboard.
            this._window.DispatchEvents();

            // Clear the drawing surface.
            this._window.Clear(Color.Black);

            // TODO: Draw the actual game.

            // TODO: Draw the UI.

            // Update the drawing surface with what has been drawn.
            this._window.Display();
        }

        /// <summary>
        /// Applies a context to the specified surface, and draws it onto the device.
        /// </summary>
        /// <param name="surfaceName">The name of the surface to be drawn.</param>
        /// <param name="context">The context to be applied to the surface.</param>
        public void DrawSurface(string surfaceName, SurfaceContext context)
        {
            // Retrieve the surface from its resource manager.
            var surface = this._surfaces.GetResource(surfaceName);

            // Make sure the surface was found.
            if (surface != null) {
                // TODO: Implement this.
            }
        }

        /// <summary>
        /// Applies a context to the specified text, and draws it onto the device.
        /// </summary>
        /// <param name="text">The text to be drawn.</param>
        /// <param name="context">The context to be applied to the text.</param>
        public void DrawText(string text, TextContext context)
        {
            // TODO: Implement this.
        }

        /// <summary>
        /// Destroys the device and unloads the resources it loaded.
        /// </summary>
        public void Destroy()
        {
            // TODO: Implement this.
        }
    }
}
