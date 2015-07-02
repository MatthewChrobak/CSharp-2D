using _2D_Singeplayer_Engine.Graphics.Sfml.Scenes;
using SFML.Graphics;
using System.Collections.Generic;

namespace _2D_Singeplayer_Engine.Graphics.Sfml
{
    public class Sfml : IGraphics
    {
        public static RenderWindow BackBuffer { private set; get; }
        public static SceneSystem Scene { private set; get; }
        public static Font GameFont { private set; get; }
        private List<GraphicalSurface>[] _surface;
        private Color _bgColor;
        private IInput _input;

        #region Core SFML
        public void Initialize() {
            LoadSurfaces();

            LoadFont();

            BackBuffer = new RenderWindow(new BackBuffer(Program.Window,
                Program.Window.getTrueWidth(),
                Program.Window.getTrueHeight(),
                0, 0).GetHandle());
            _bgColor = new Color(25, 25, 25);

            _input = new Input();
            BackBuffer.MouseButtonPressed += _input.MouseDown;
            BackBuffer.MouseButtonReleased += _input.MouseUp;
            BackBuffer.MouseMoved += _input.MouseMove;
            BackBuffer.KeyPressed += _input.KeyPress;
            BackBuffer.KeyReleased += _input.KeyRelease;
            BackBuffer.SetKeyRepeatEnabled(true);

            Scene = new SceneSystem();
        }
        public void Destroy() {

        }
        public void Draw() {
            BackBuffer.DispatchEvents();
            BackBuffer.Clear(_bgColor);
            DrawGame();
            Scene.Draw();
            BackBuffer.Display();
        }

        private void LoadSurfaces() {
            _surface = new List<GraphicalSurface>[(int)SurfaceType.Length];

            for (int i = 0; i < (int)SurfaceType.Length; i++) {
                _surface[i] = new List<GraphicalSurface>();
            }

            // Example Usage:

            // foreach (string file in Directory.GetFiles(GraphicsManager.ExamplePath, "*.png")) {
            //     _surface[(int)SurfaceType.Sprite].Add(new GraphicalSurface(file));
            // }
        }
        private void LoadFont() {

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
        #endregion

        private void DrawGame() {

        }
    }
}
