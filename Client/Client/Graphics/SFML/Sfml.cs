using System.IO;
using System.Collections.Generic;

using SFML.Graphics;
using SFML.Window;

using Client;
using Data.Models;
using Data;
using Graphics.Sfml.Scenes;

namespace Graphics.Sfml
{
    public class Sfml : IGraphics
    {
        public static RenderWindow BackBuffer { private set; get; }
        public static SceneSystem Scene { private set; get; }
        public static Font GameFont { private set; get; }
        private List<GraphicalSurface>[] _surface;
        private Color _backBufferColor;
        private IInput _input;
        
        #region Core SFML
        public void Initialize() {
            // Load the graphics.
            LoadSurfaces();

            // Load the TTF file and set the font.
            LoadFont();

            // Create a new drawing surface and make it 
            // the backbuffer.
            BackBuffer = new RenderWindow(new BackBuffer(Application.Window,
                Application.Window.GetTrueSize().Width,
                Application.Window.GetTrueSize().Height,
                0, 0).GetHandle());
            _backBufferColor = new Color(25, 25, 25);

            // SFML event handlers for input.
            _input = new Input();
            BackBuffer.MouseButtonPressed += _input.MouseDown;
            BackBuffer.MouseButtonReleased += _input.MouseUp;
            BackBuffer.MouseMoved += _input.MouseMove;
            BackBuffer.KeyPressed += _input.KeyPress;
            BackBuffer.KeyReleased += _input.KeyRelease;
            BackBuffer.SetKeyRepeatEnabled(true);

            // Create a new scene system.
            Scene = new SceneSystem();
        }
        public void Reload() {
        }
        public void Destroy() {

        }
        public void Draw() {
            BackBuffer.DispatchEvents();
            BackBuffer.Clear(_backBufferColor);
            DrawGame();
            BackBuffer.Display();
        }

        private void LoadSurfaces() {
            _surface = new List<GraphicalSurface>[(int)SurfaceType.Length];

            for (int i = 0; i < (int)SurfaceType.Length; i++) {
                _surface[i] = new List<GraphicalSurface>();
            }

            foreach (string file in Directory.GetFiles(GraphicsManager.SpritePath, "*.png")) {
                _surface[(int)SurfaceType.Sprite].Add(new GraphicalSurface(file));
            }
        }
        public GraphicalSurface GetSurface(string tagName, SurfaceType type) {
            for (int i = 0; i < _surface[(int)type].Count; i++) {
                if (_surface[(int)type][i].tag.ToLower() == tagName.ToLower()) {
                    return _surface[(int)type][i];
                }
            }
            return null;
        }
        public int GetSurfaceIndex(string tagName, SurfaceType type) {
            for (int i = 0; i < _surface[(int)type].Count; i++) {
                if (_surface[(int)type][i].tag.ToLower() == tagName.ToLower()) {
                    return i;
                }
            }
            return -1;
        }
        public void LoadFont() {
            if (System.IO.File.Exists(Application.StartupPath + "data\\fonts\\" + Application.Settings.Font + ".ttf")) {
                GameFont = new Font(Application.StartupPath + "data\\fonts\\" + Application.Settings.Font + ".ttf");
            } else if (System.IO.File.Exists(Application.StartupPath + "data\\fonts\\" + Application.Settings.Font + ".otf")) {
                GameFont = new Font(Application.StartupPath + "data\\fonts\\" + Application.Settings.Font + ".otf");
            }
        }
        #endregion

        private void DrawGame() {
            
            // Are we in game?
            if (Application.inGame) {

            }
            Scene.Draw();
        }
    }
}
