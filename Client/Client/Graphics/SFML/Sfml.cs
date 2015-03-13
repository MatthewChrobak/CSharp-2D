using System.IO;
using System.Collections.Generic;

using SFML.Graphics;
using SFML.Window;

using Client.Data.Models;
using Client.Data;
using Client.Graphics.SFML.Scene;

namespace Client.Graphics.SFML
{
    public class Sfml : iGraphics
    {
        private static List<GraphicalSurface> _surface;
        private static RenderWindow _backBuffer;
        private static Font _gameFont;
        private static iInput _input;
        private Color _backBufferColor;

        #region Core SFML
        public void Initialize() {
            // Load the graphics.
            LoadSurfaces();

            // Load the TTF file and set the font.
            LoadFont();

            // Create a new drawing surface and make it 
            // the backbuffer.
            _backBuffer = new RenderWindow(new BackBuffer(Client.Window,
                Client.Window.Width - Client.Window.HorizontalFormWeight,
                Client.Window.Height - Client.Window.VertivalFormWeight,
                0, 0).GetHandle());
            _backBufferColor = new Color(25, 25, 25);

            // SFML event handlers for input.
            _input = new Input();
            _backBuffer.MouseButtonPressed += _input.MouseDown;
            _backBuffer.MouseButtonReleased += _input.MouseUp;
            _backBuffer.MouseMoved += _input.MouseMove;
            _backBuffer.KeyPressed += _input.KeyPress;
            _backBuffer.KeyReleased += _input.KeyRelease;
            _backBuffer.SetKeyRepeatEnabled(true);

            // Load the scene manager.
            SceneManager.Load();
        }
        public void Reload() {
        }
        public void Destroy() {

        }
        public void Draw() {
            _backBuffer.DispatchEvents();
            _backBuffer.Clear(_backBufferColor);
            DrawGame();
            _backBuffer.Display();
        }

        public static void RenderSurface(GraphicalSurface Surface, Vector2f Location, Vector2f Size, IntRect SurfaceRect, Color Color) {
            if (Surface == null) {
                return;
            }
            var sprite = Surface.sprite;
            sprite.Position = Location;
            sprite.TextureRect = SurfaceRect;
            sprite.Scale = new Vector2f(Size.X / sprite.Texture.Size.X, Size.Y / sprite.Texture.Size.Y);
            sprite.Color = Color;
            _backBuffer.Draw(sprite);
        }
        public static void RenderSurface(GraphicalSurface Surface, Vector2f Location, Vector2f Size, IntRect SurfaceRect) {
            if (Surface == null) {
                return;
            }
            var sprite = Surface.sprite;
            sprite.Position = Location;
            sprite.TextureRect = SurfaceRect;
            sprite.Scale = new Vector2f(Size.X / sprite.Texture.Size.X, Size.Y / sprite.Texture.Size.Y);
            _backBuffer.Draw(sprite);
        }
        public static void RenderSurface(GraphicalSurface Surface, Vector2f Location, Vector2f Size, Color Color) {
            if (Surface == null) {
                return;
            }
            var sprite = Surface.sprite;
            sprite.Position = Location;
            sprite.Scale = new Vector2f(Size.X / sprite.Texture.Size.X, Size.Y / sprite.Texture.Size.Y);
            sprite.Color = Color;
            _backBuffer.Draw(sprite);
        }
        public static void RenderSurface(GraphicalSurface Surface, Vector2f Location, Vector2f Size) {
            if (Surface == null) {
                return;
            }
            var sprite = Surface.sprite;
            sprite.Position = Location;
            sprite.Scale = new Vector2f(Size.X / sprite.Texture.Size.X, Size.Y / sprite.Texture.Size.Y);
            _backBuffer.Draw(sprite);
        }
        public static void RenderSurface(GraphicalSurface Surface, Vector2f Location, IntRect SurfaceRect) {
            if (Surface == null) {
                return;
            }
            var sprite = Surface.sprite;
            sprite.Position = Location;
            sprite.TextureRect = SurfaceRect;
            _backBuffer.Draw(sprite);
        }
        public static void RenderSurface(GraphicalSurface Surface, Vector2f Location) {
            if (Surface == null) {
                return;
            }
            var sprite = Surface.sprite;
            sprite.Position = Location;
            _backBuffer.Draw(sprite);
        }
        public static void RenderText(string Str, Vector2f Location, Color Color, uint Size, Text.Styles FontStyle) {
            var text = new Text(Str, _gameFont, Size);
            text.Font = _gameFont;
            text.Color = Color;
            text.Style = FontStyle;
            text.Position = Location;
            _backBuffer.Draw(text);
            text.Dispose();
        }

        private static void LoadSurfaces() {
            _surface = new List<GraphicalSurface>();

            foreach (string File in Directory.GetFiles(Client.StartupPath + "\\data\\surfaces\\", "*.png")) {
                _surface.Add(new GraphicalSurface(File));
            }
        }
        public static GraphicalSurface GetSurface(string tagName) {
            for (int i = 0; i < _surface.Count; i++) {
                if (_surface[i].tag.ToLower() == tagName.ToLower()) {
                    return _surface[i];
                }
            }
            return null;
        }
        public static void LoadFont() {
            if (System.IO.File.Exists(Client.StartupPath + "data\\fonts\\" + Client.Settings.Font + ".ttf")) {
                _gameFont = new Font(Client.StartupPath + "data\\fonts\\" + Client.Settings.Font + ".ttf");
            } else if (System.IO.File.Exists(Client.StartupPath + "data\\fonts\\" + Client.Settings.Font + ".otf")) {
                _gameFont = new Font(Client.StartupPath + "data\\fonts\\" + Client.Settings.Font + ".otf");
            }
        }
        #endregion

        private static void DrawGame() {
            
            // Are we in game?
            if (Client.inGame) {
                
            }

            SceneManager.Draw();
        }
    }
}
