using SFML.Graphics;

namespace MultiplayerEngine_Client.Graphics.Sfml.Scenes.Objects
{
    public class Label : SceneObject
    {
        public string Caption = "sample text";
        public Color TextColor = Color.Black;
        public uint FontSize = 12;

        public override void Draw() {
            // Draw the surface if we have one.
            base.Draw();

            // Draw the caption for the label.
            base.RenderCaption(this.Caption, this.FontSize, this.TextColor);
        }

        public override string GetStringValue(string key) {
            // Figure out what property is being requested.
            switch (key.ToLower()) {
                case "text":
                case "caption":
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

        public sealed override string GetObjectType() {
            return "Label";
        }
    }
}
