using AnnexEngine.Graphics.Resources.Contexts;

namespace AnnexEngine.Graphics.Devices
{
    /// <summary>
    /// A graphical object that is capable of drawing textures and text onto itself.
    /// </summary>
    public interface IGraphicalDevice : IDrawable
    {
        /// <summary>
        /// Draws a texture with the given context onto the graphical device.
        /// </summary>
        /// <param name="textureName">The name of the texture to be drawn.</param>
        /// <param name="context">The context to be applied to the texture.</param>
        void DrawTexture(string textureName, TextureContext context);

        /// <summary>
        /// Draws text with the given context onto the graphical device.
        /// </summary>
        /// <param name="text">The text to be drawn.</param>
        /// <param name="context">The context to be applied to the text.</param>
        void DrawText(string text, TextContext context);

        /// <summary>
        /// Destroys the graphical device and unloads the resources it loaded.
        /// </summary>
        void Destroy();
    }
}
