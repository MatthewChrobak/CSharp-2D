using SFML.Graphics;
using SFML.Window;

using Networking;

namespace Graphics.Sfml.Scenes.Objects
{
    public class Label : SceneObject
    {
        public string Caption;
        public Color TextColor;
        public uint FontSize;

        public override void Draw() {
            if (HasMouse) {
                switch (Name) {
                    case "lblLogin":
                    case "lblOptions":
                    case "lblCreate":
                        var sprite = Surface.sprite;//SceneManager.getSurfaceIndex("blur");
                        sprite.Position = new Vector2f(this.Left, this.Top);
                        sprite.Scale = new Vector2f((this.Width * 3) / sprite.Texture.Size.X, this.Height / sprite.Texture.Size.Y);
                        sprite.Color = Color.Red;
                        Sfml.BackBuffer.Draw(sprite);
                        break;
                }
            }

            if (Caption != null) {
                var text = new Text(Caption, Sfml.GameFont);
                text.Position = new Vector2f(this.Left + (int)(this.Width - (this.Caption.Length * CapsToSize * this.FontSize)) / 2, this.Top + (this.Height / 2) - (this.FontSize / 2));
                text.Color = this.TextColor;
                text.CharacterSize = this.FontSize;
                Sfml.BackBuffer.Draw(text);
            }
        }

        public override void MouseDown(int x, int y) {
            switch (Name) {
                case "lblLogin":
                    PacketManager.SendRequestLogin(
                        Sfml.Scene.getMenuObject("txtUsername").getStringValue("text"),
                        Sfml.Scene.getMenuObject("txtPassword").getStringValue("text")
                        );
                    break;
                case "lblCreate":
                    PacketManager.SendRequestCreate(
                        Sfml.Scene.getMenuObject("txtUsername").getStringValue("text"),
                        Sfml.Scene.getMenuObject("txtPassword").getStringValue("text")
                        );
                    break;
            }
        }
    }
}
