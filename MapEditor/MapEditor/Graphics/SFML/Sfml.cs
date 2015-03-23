using System;
using System.IO;
using System.Collections.Generic;

using SFML.Graphics;
using SFML.Window;

using MapEditor.Data.Models;
using MapEditor.Data;

namespace MapEditor.Graphics.SFML
{
    public class Sfml : iGraphics
    {
        private static List<GraphicalSurface>[] _surface;
        private static RenderWindow _backBuffer;
        private static RenderWindow _tilesetBuffer;
        private static Font _gameFont;
        private static iInput _input;
        private Color _backBufferColor;
        private static RectangleShape _hover;

        #region Core SFML
        public void Initialize() {
            // Load the graphics.
            LoadSurfaces();

            // Load the TTF file and set the font.
            LoadFont();

            // Create a new drawing surface and make it 
            // the backbuffer.
            _backBuffer = new RenderWindow(new BackBuffer(Editor.Window,
                Editor.Window.Width - Editor.Window.HorizontalFormWeight,
                Editor.Window.Height - Editor.Window.VerticalFormWeight - Editor.Window.MenuHeight,
                0, Editor.Window.MenuHeight).GetHandle());
            _backBufferColor = new Color(25, 25, 25);

            _tilesetBuffer = new RenderWindow(new BackBuffer(Editor.TilesetWindow,
                1500,
                750,
                0, Editor.Window.MenuHeight).GetHandle());

            // SFML event handlers for input.
            _input = new Input();
            _backBuffer.MouseButtonPressed += _input.MouseDown;
            _backBuffer.MouseButtonReleased += _input.MouseUp;
            _backBuffer.MouseMoved += _input.MouseMove;
            _backBuffer.KeyPressed += _input.KeyPress;
            _backBuffer.KeyReleased += _input.KeyRelease;
            _backBuffer.SetKeyRepeatEnabled(true);

            _tilesetBuffer.MouseButtonPressed += _input.MouseDown;
            _tilesetBuffer.MouseButtonReleased += _input.MouseUp;
            _tilesetBuffer.MouseMoved += _input.MouseMove;
            _tilesetBuffer.KeyPressed += _input.KeyPress;
            _tilesetBuffer.KeyReleased += _input.KeyRelease;
            _tilesetBuffer.SetKeyRepeatEnabled(true);

            _hover = new RectangleShape();
            _hover.OutlineThickness = 1;
            _hover.FillColor = Color.Transparent;
            _hover.OutlineColor = Color.Red;
        }
        public void Reload() {
            Destroy();
            LoadSurfaces();
        }
        public void Destroy() {
            for (int i = 0; i < (int)SurfaceType.Length; i++) {
                _surface[i].Clear();
            }
        }
        public void Draw() {
            _backBuffer.DispatchEvents();
            _backBuffer.Clear(_backBufferColor);
            _tilesetBuffer.DispatchEvents();
            _tilesetBuffer.Clear(_backBufferColor);
            DrawGame();
            _backBuffer.Display();
            _tilesetBuffer.Display();
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
            _surface = new List<GraphicalSurface>[(int)SurfaceType.Length];
            Editor.TilesetWindow.Tilesets.Items.Clear();

            for (int i = 0; i < (int)SurfaceType.Length; i++) {
                _surface[i] = new List<GraphicalSurface>();
            }

            if (Directory.Exists(Editor.Settings.GraphicsFolder + "\\tilesets\\")) {
                foreach (string file in Directory.GetFiles(Editor.Settings.GraphicsFolder + "\\tilesets\\", "*.png")) {
                    _surface[(int)SurfaceType.Tileset].Add(new GraphicalSurface(file));
                    Editor.TilesetWindow.Tilesets.Items.Add(_surface[(int)SurfaceType.Tileset][_surface.Length - 1].tag);
                }
            }
        }
        public static void LoadFont() {
            if (System.IO.File.Exists(Editor.StartupPath + "tahoma.ttf")) {
                _gameFont = new Font(Editor.StartupPath + "tahoma.ttf");
            } else if (System.IO.File.Exists(Editor.StartupPath + "tahoma.otf")) {
                _gameFont = new Font(Editor.StartupPath + "tahoma.otf");
            }
        }
        #endregion

        private static void DrawGame() {

            if (Editor.TilesetWindow.Tilesets.SelectedIndex != -1) {
                var sprite = _surface[(int)SurfaceType.Tileset][Editor.TilesetWindow.Tilesets.SelectedIndex].sprite;
                _tilesetBuffer.Draw(sprite);
            }
            
            _hover.Position = new Vector2f(Input.StartX * 32, Input.StartY * 32);
            _hover.Size = new Vector2f((Input.FinishX - Input.StartX) * 32 + 32, (Input.FinishY - Input.StartY) * 32 + 32);
            _tilesetBuffer.Draw(_hover);
        }
    }
}
