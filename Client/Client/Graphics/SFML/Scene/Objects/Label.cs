using SFML.Graphics;
using SFML.Window;

using Client.Networking;

namespace Client.Graphics.SFML.Scene.Objects
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
                        Sfml.RenderSurface(Sfml.GetSurface("blur", SurfaceType.Gui), new Vector2f(this.Left, this.Top), new Vector2f(this.Width * 3, this.Height), Color.Red);
                        break;
                }
            }

            if (Caption != null) {
                Sfml.RenderText(this.Caption, new Vector2f(this.Left + (int)(this.Width - (this.Caption.Length * CapsToSize * this.FontSize)) / 2, this.Top + (this.Height / 2) - (this.FontSize / 2)), this.TextColor, this.FontSize, Text.Styles.Regular);
            }
        }

        public override void MouseDown(int x, int y) {
            switch (Name) {
                case "lblLogin":
                    PacketManager.SendRequestLogin(
                        SceneManager.getMenuObject("txtUsername").getStringValue("text"),
                        SceneManager.getMenuObject("txtPassword").getStringValue("text")
                        );
                    break;
                case "lblCreate":
                    PacketManager.SendRequestCreate(
                        SceneManager.getMenuObject("txtUsername").getStringValue("text"),
                        SceneManager.getMenuObject("txtPassword").getStringValue("text")
                        );
                    break;
            }
        }
    }
}
