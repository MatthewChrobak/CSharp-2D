using System.IO;

using SFML.Graphics;

namespace Graphics.Sfml
{
    public class GraphicalSurface
    {
        public string tag { get; private set; }
        public Sprite sprite { get; private set; }

        public GraphicalSurface(string File) {
            var fi = new FileInfo(File);
            if (fi.Extension == ".png") {
                tag = fi.Name.Remove(fi.Name.Length - 4).ToLower();
                sprite = new Sprite(new Texture(File));
                sprite.Texture.Repeated = false;
                sprite.Texture.Smooth = true;
            }
        }
    }
}
