using SFML.Graphics;
using System.IO;

namespace _2D_Singleplayer_Engine.Graphics.Sfml
{
    public class GraphicalSurface
    {
        public string Tag { get; private set; }
        public Sprite Sprite { get; private set; }

        public GraphicalSurface(string file) {
            // Does the file exist?
            if (File.Exists(file)) {
                // Set the tag to equal the file name without the extension, and store the surface.
                var fi = new FileInfo(file);
                Tag = fi.Name.Remove(fi.Name.Length - fi.Extension.Length).ToLower();
                Sprite = new Sprite(new Texture(file));

                // Ensure the texture is not repeated, and that it's smoothed.
                Sprite.Texture.Repeated = false;
                Sprite.Texture.Smooth = true;
            }
        }
    }
}
