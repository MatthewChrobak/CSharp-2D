using SFML.Graphics;
using System.IO;

namespace Client.Graphics.Sfml
{
    public class GraphicalSurface
    {
        public string Tag { private set; get; }
        public Sprite Sprite { private set; get; }

        public GraphicalSurface(string file) {
            // Does the file exist?
            if (File.Exists(file)) {
                // Set the tag to equal the file name without extension, and store the surface.
                var fi = new FileInfo(file);
                this.Tag = fi.Name.Remove(fi.Name.Length - fi.Extension.Length).ToLower();
                this.Sprite = new Sprite(new Texture(file));
            } else {
                throw new FileNotFoundException("GraphicalSurface: " + file);
            }
        }
    }
}
