using _2D_Singleplayer_Engine.Graphics.Sfml.Scenes;
using SFML.Graphics;
using System.Collections.Generic;

namespace _2D_Singleplayer_Engine.Graphics.Sfml
{
    public class Sfml : IGraphics
    {
        // Objects relating to this class.
        public static RenderWindow BackBuffer { private set; get; }
        public static Font GameFont { private set; get; }
        private Color _backgroundColor;

        // Collection of the graphics.
        private List<GraphicalSurface>[] _surface;

        // Reference objects.
        public static SceneSystem Scene { private set; get; }
        private IInput _input;

        #region Core SFML
        public void Initialize() {
            // Load all the surfaces.
            LoadSurfaces();

            // Load the font.
            LoadFont();

            // Create a form object based off of the size of the game 
            // window, and set it to be the backbuffer.
            BackBuffer = new RenderWindow(new BackBuffer(Program.Window,
                Program.Window.getTrueWidth(),
                Program.Window.getTrueHeight(),
                0, 0).GetHandle());
            // Set the default background color for the backbuffer.
            _backgroundColor = new Color(25, 25, 25);

            // Create a new input system, and link the events to event handlers.
            _input = new Input();
            BackBuffer.MouseButtonPressed += _input.MouseDown;
            BackBuffer.MouseButtonReleased += _input.MouseUp;
            BackBuffer.MouseMoved += _input.MouseMove;
            BackBuffer.KeyPressed += _input.KeyPress;
            BackBuffer.KeyReleased += _input.KeyRelease;

            // Create new User Inferace system.
            Scene = new SceneSystem();
        }

        public void Destroy() {

        }

        public void Draw() {
            // Invoke the DoEvents for SFML so we can capture mouse and keyboard events.
            BackBuffer.DispatchEvents();

            // Clear the backbuffer with the background color.
            BackBuffer.Clear(_backgroundColor);
            
            // Draw the actual game.
            DrawGame();

            // Draw the user interface.
            Scene.Draw();
            
            // Update the backbuffer with what has been drawn.
            BackBuffer.Display();
        }


        private void LoadSurfaces() {
            // Initialize the array of collections.
            _surface = new List<GraphicalSurface>[(int)SurfaceType.Length];

            // Initialize each collection in the array.
            for (int i = 0; i < (int)SurfaceType.Length; i++) {
                _surface[i] = new List<GraphicalSurface>();
            }


            // From this point onward, load graphics into their respective collections.

            // Example Usage:
            // foreach (string file in Directory.GetFiles(GraphicsManager.ExamplePath, "*.png")) {
            //     _surface[(int)SurfaceType.Sprite].Add(new GraphicalSurface(file));
            // }
        }

        private void LoadFont() {

        }


        public GraphicalSurface GetSurface(string tagName, SurfaceType type) {
            // Loop through the collection of the specific type.
            for (int i = 0; i < _surface[(int)type].Count; i++) {
                // If the surface tag name is equal to the tag name specified, return the surface.
                if (_surface[(int)type][i].Tag == tagName.ToLower()) {
                    return _surface[(int)type][i];
                }
            }
            // Return null if we couldn't find a surface with the tag specified.
            return null;
        }

        public int GetSurfaceIndex(string tagName, SurfaceType type) {
            // Loop through the collection of the specified type.
            for (int i = 0; i < _surface[(int)type].Count; i++) {
                // If the surface tag name is equal to the tag name specified, return the index.
                if (_surface[(int)type][i].Tag == tagName.ToLower()) {
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
