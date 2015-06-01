using SFML.Window;

using Client;
using Graphics.Sfml.Scenes;

namespace Graphics.Sfml
{
    public class Input : IInput
    {
        public void MouseDown(object sender, object obj) {
            // Convert the object into a MouseButtonEventArgs object.
            var e = (MouseButtonEventArgs)obj;

            // Focus on the window if we don't already have the focus.
            if (!Application.Window.ContainsFocus) {
                Application.Window.Focus();
            }

            // Pass off the coords to the scene system.
            Sfml.Scene.MouseDown(e.X, e.Y);
        }

        public void MouseUp(object sender, object obj) {
            // Convert the object into a MouseButtonEventArgs object.
            var e = (MouseButtonEventArgs)obj;
        }

        public void MouseMove(object sender, object obj) {
            // Convert the object into a MouseMoveEventArgs object.
            var e = (MouseMoveEventArgs)obj;

            // Pass off the coords to the scene system.
            Sfml.Scene.MouseMove(e.X, e.Y);
        }

        public void KeyPress(object sender, object obj) {
            // Convert the object to a KeyEventArgs object.
            var e = (KeyEventArgs)obj;
            string key = e.Code.ToString();

            // Check if it's a single character. If so, there's a 99.99% chance 
            // one of the twenty-six alphabetical characters.
            if (key.Length == 1) {
                // Are we hitting shift?
                if (e.Shift) {
                    key = key.ToUpper();
                } else {
                    key = key.ToLower();
                }
            } else {
                // If it's not one of the twenty-six, conduct further research.
                switch (key) {
                    case "Space":
                        key = " ";
                        break;
                    case "Back":
                        // Just keep it as it is.
                        // Chances are, it's a command.
                        break;
                    default:
                        // Don't risk it.
                        return;
                }
            }

            // Pass it off to the scene system.
            Sfml.Scene.KeyDown(key); 
        }

        public void KeyRelease(object sender, object obj) {
            // Convert the object into a KeyEventArgs object.
            var e = (KeyEventArgs)obj;
        }

        public void CheckKeys() {

        }
    }
}
