using Client.Graphics.Sfml.Scenes;
using SFML.Graphics;
using SFML.Window;
using System.Collections.Generic;
using System.IO;

namespace Client.Graphics.Sfml
{
    public class Sfml : IGraphics
    {
        public SceneSystem SceneSystem { private set; get; }
        private RenderWindow DrawingSurface;
        private Font GameFont;
        private Color _backgroundColor;

        // The collection of all the graphics.
        private List<GraphicalSurface>[] _surface;

        #region Core System
        public Sfml() {
            // Load all the surfaces and the font.
            this.LoadSurfaces();
            this.LoadFont();

            // Create a new renderwindow that we can render graphics onto.
            this.DrawingSurface = new RenderWindow(new VideoMode(300, 300), "Title", Styles.Close);

            // Set the default background color for the drawing surface.
            this._backgroundColor = new Color(25, 25, 25);

            // Create event handlers for the drawing surface.
            this.CreateEventHandlers();
        }

        public void Destroy() {
            // Destroy the scene system.
            this.SceneSystem.Destroy();
            this.SceneSystem = null;

            // Loop through every collection that stores surfaces.
            foreach (var collection in this._surface) {
                // Loop through every surface in the collection, and 
                // dispose of the sprite.
                foreach (var surface in collection) {
                    surface.Sprite.Dispose();
                }

                // Then clear the collection.
                collection.Clear();
            }

            // Dispose of the game font.
            this.GameFont.Dispose();

            // Dispose of the drawing surface.
            this.DrawingSurface.Dispose();
        }

        private void CreateEventHandlers() {
            // Create a new scene system to handle the events.
            this.SceneSystem = new SceneSystem();


            // For mouse related events, just pass off the coords to the scene system.
            this.DrawingSurface.MouseButtonPressed += (sender, e) => {
                this.SceneSystem.MouseDown(e.Button.ToString().ToLower(), e.X, e.Y);
            };
            this.DrawingSurface.MouseButtonReleased += (sender, e) => {
                this.SceneSystem.MouseUp(e.Button.ToString().ToLower(), e.X, e.Y);
            };
            this.DrawingSurface.MouseMoved += (sender, e) => {
                this.SceneSystem.MouseMove(e.X, e.Y);
            };

            // For key related events, pass off the filtered keyname to the scene system.
            this.DrawingSurface.KeyPressed += (sender, e) => {
                this.SceneSystem.KeyDown(this.FilterKey(e));
            };

            // When the close button is pressed, set the client flag to 'closing' so 
            // the application can begin to close.
            this.DrawingSurface.Closed += (sender, e) => {
                Client.SetClientFlag(ClientFlag.Closing);
            };
        }

        private void LoadSurfaces() {
            // Initialize the array of collections.
            this._surface = new List<GraphicalSurface>[(int)SurfaceTypes.Length];

            // Initialize each collection in the array.
            for (int i = 0; i < (int)SurfaceTypes.Length; i++) {
                this._surface[i] = new List<GraphicalSurface>();
            }

            // From this point onward, load graphics into their respective collections.
        }

        private void LoadFont() {
            // Return early because a default tff file is not included.
            return;

            string fontFile = GraphicsManager.FontPath + "font.ttf";

            // Make sure that the ttf file exists.
            if (File.Exists(fontFile)) {
                this.GameFont = new Font(fontFile);
            } else {
                throw new FileNotFoundException("Sfml: " + fontFile);
            }
        }

        public void Draw() {
            // Invoke the DoEvents for SFML so we can capture mouse and keyboard events.
            this.DrawingSurface.DispatchEvents();

            // Clear the drawing surface with the background color.
            this.DrawingSurface.Clear(this._backgroundColor);

            // Draw the actual game.
            this.DrawGame();

            // Draw the user interface.
            this.SceneSystem.Draw();

            // Update the drawing surface with that what has been drawn.
            this.DrawingSurface.Display();
        }

        public void DrawObject(object obj) {
            // Convert the given object to an SFML drawable object, and 
            // have the drawing surface render it.
            var surface = (Drawable)obj;
            this.DrawingSurface.Draw(surface);
        }

        public object GetFont() {
            return this.GameFont;
        }

        private string FilterKey(KeyEventArgs e) {
            string key = e.Code.ToString();

            // Make sure it's a single character.
            if (key.Length == 1) {
                // Are we hitting shift?
                if (e.Shift) {
                    key = key.ToUpper();
                } else {
                    key = key.ToLower();
                }
            } else {
                // If it's not a single character, explore other options.
                switch (key.ToLower()) {
                    case "space":
                        key = " ";
                        break;
                    case "backspace":
                        // Just keep it as it is.
                        break;
                    default:
                        // Don't risk it.
                        return string.Empty;
                }
            }

            // Return the filtered key.
            return key.ToLower();
        }

        private Sprite GetSurface(string tagName, SurfaceTypes type) {
            // Loop through the collection of the specified type.
            for (int i = 0; i < this._surface[(int)type].Count; i++) {
                // If the surface tag name is equal to the tag name specified, return the surface.
                if (this._surface[(int)type][i].Tag == tagName.ToLower()) {
                    return this._surface[(int)type][i].Sprite;
                } 
            }

            // Return null if we couldn't find a surface with the tag specified.
            return null;
        }

        private int GetSurfaceIndex(string tagName, SurfaceTypes type) {
            // Loop through the collection of the specified type.
            for (int i = 0; i < this._surface[(int)type].Count; i++) {
                // If the surface tag name is equal to the tag name specified, return the surface.
                if (this._surface[(int)type][i].Tag == tagName.ToLower()) {
                    return i;
                }
            }

            // Return -1 if we couldn't find a surface with the tag specified.
            return -1;
        }
        #endregion

        private void DrawGame() {
            // All logic pertaining to drawing the game goes here.
        }
    }
}
