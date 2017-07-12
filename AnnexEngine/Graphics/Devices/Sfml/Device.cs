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
        /// Resource managers for all the textures and fonts.
        /// </summary>
        private ResourceManager<Texture> _textures;
        private ResourceManager<Font> _fonts;
        
        /// <summary>
        /// The window of the graphical device.
        /// </summary>
        private Window _window;

        /// <summary>
        /// Creates the SFML device, and loads all the necessary resources.
        /// </summary>
        public Device()
        {
            // Load all the required resources.
            this.LoadResources();

            // Create a new window.
            this._window = new Window(960, 640, "Sfml Demo");
        }

        /// <summary>
        /// Loads all the resources needed to draw textures and text.
        /// </summary>
        private void LoadResources()
        {
            // Initialize the managers.
            this._textures = new ResourceManager<Texture>();
            this._fonts = new ResourceManager<Font>();

            // Load all the .png images from the GraphicsPath.
            this._textures.LoadFiles(GraphicsManager.GraphicsPath,
                filepath => new Texture(filepath), 
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

            // Clear the device.
            this._window.Clear(Color.Black);

            // TODO: Draw the actual game.

            // TODO: Draw the UI.

            // Update the device with what has been drawn.
            this._window.Display();
        }

        /// <summary>
        /// Applies a context to the specified texture, and draws it onto the device.
        /// </summary>
        /// <param name="textureName">The name of the texture to be drawn.</param>
        /// <param name="context">The context to be applied to the texture.</param>
        public void DrawTexture(string textureName, TextureContext context)
        {
            // Retrieve the texture from its resource manager.
            var texture = this._textures.GetResource(textureName);

            // Make sure the texture was found.
            if (texture != null) {
                // Create a sprite from the texture, and apply the context to the sprite.
                // TODO: Expand on this.
                var sprite = new Sprite(texture);

                // Render the sprite.
                this._window.Draw(sprite);
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
