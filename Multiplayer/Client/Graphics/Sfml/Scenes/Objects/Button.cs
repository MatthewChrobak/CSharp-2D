using SFML.Graphics;

namespace MultiplayerEngine_Client.Graphics.Sfml.Scenes.Objects
{
    public class Button : SceneObject
    {
        public string Caption = "sample text";
        public Color TextColor = Color.Black;
        public uint FontSize = 12;

        public override void Draw() {
            // Draw the surface if we have one.
            base.Draw();

            // Draw the button's caption.
            base.RenderCaption(this.Caption, this.FontSize, this.TextColor);
        }

        public sealed override string GetObjectType() {
            return "Button";
        }

        public override string GetStringValue(string key) {
            // Figure out what property is being requested.
            switch (key.ToLower()) {
                case "caption":
                case "text":
                    return this.Caption;
                default:
                    return base.GetStringValue(key);
            }
        }

        public override int GetIntValue(string key) {
            // Figure out what property is being requested.
            switch (key.ToLower()) {
                case "fontsize":
                    return (int)this.FontSize;
                default:
                    return base.GetIntValue(key);
            }
        }
    }
}
