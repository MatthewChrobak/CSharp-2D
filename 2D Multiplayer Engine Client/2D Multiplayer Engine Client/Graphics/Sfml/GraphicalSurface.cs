using System.IO;

using SFML.Graphics;

namespace _2D_Multiplayer_Engine_Client.Graphics.Sfml
{
    public class GraphicalSurface
    {
        public string tag { get; private set; }
        public Sprite sprite { get; private set; }

        public GraphicalSurface(string file) {
            if (File.Exists(file)) {
                var fi = new FileInfo(file);
                tag = fi.Name.Remove(fi.Name.Length - fi.Extension.Length).ToLower();
                sprite = new Sprite(new Texture(file));
                sprite.Texture.Repeated = false;
                sprite.Texture.Smooth = true;
            }
        }
    }
}
