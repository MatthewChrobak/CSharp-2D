using System.Collections.Generic;
using System.IO;

using _2D_Singleplayer_Engine.Graphics.Sfml.Scenes.Objects;
using _2D_Singleplayer_Engine.Data;

namespace _2D_Singleplayer_Engine.Graphics.Sfml.Scenes {
    public class SceneSystem {
        public List<GraphicalSurface> Surface { private set; get; }
        private SceneObject[] _gameObjects;
        private SceneObject[] _menuObjects;
        private SceneObject _curFocus;

        // Initialization.
        #region You shouldn't have to touch this.
        public SceneSystem() {
            LoadSurfaces();
            LoadGuiObjects();
        }

        public void Reload() {
            SceneObject.ResetZOrder();
            LoadGuiObjects();
        }

        public void Draw() {
            foreach (SceneObject obj in _gameObjects) {
                if (obj.Visible) {
                    obj.Draw();
                }
            }
        }

        private void LoadSurfaces() {
            Surface = new List<GraphicalSurface>();

            foreach (string file in Directory.GetFiles(GraphicsManager.GuiPath, "*.png")) {
                Surface.Add(new GraphicalSurface(file));
            }
        }

        public GraphicalSurface getSurface(string tagName) {
            foreach (var surface in Surface) {
                if (surface.tag.ToLower() == tagName.ToLower()) {
                    return surface;
                }
            }
            return null;
        }

        public SceneObject getGameObject(string name) {
            foreach (var obj in _gameObjects) {
                if (obj.Name == name) {
                    return obj;
                }
            }
            return null;
        }

        // GUI Events
        public void MouseDown(int x, int y) {
            for (int z = _gameObjects.Length - 1; z >= 0; z--) {
                foreach (SceneObject obj in _gameObjects) {
                    if (obj.Z == z) {
                        if (x >= obj.Left && x <= obj.Left + obj.Width) {
                            if (y >= obj.Top && y <= obj.Top + obj.Height) {
                                if (_curFocus != null) {
                                    _curFocus.HasFocus = false;
                                }
                                _curFocus = obj;
                                _curFocus.HasFocus = true;
                                obj.MouseDown(x - obj.Left, y - obj.Top);
                                return;
                            }
                        }
                    }
                }
            }
        }

        public void MouseMove(int x, int y) {
            for (int z = _gameObjects.Length - 1; z >= 0; z--) {
                foreach (SceneObject obj in _gameObjects) {
                    if (obj.Z == z) {
                        if (x >= obj.Left && x <= obj.Left + obj.Width) {
                            if (y >= obj.Top && y <= obj.Top + obj.Height) {
                                obj.MouseMove(x - obj.Left, y - obj.Top);
                                return;
                            }
                        }
                    }
                }
            }
        }

        public void KeyDown(string key) {
            if (_curFocus != null) {
                _curFocus.KeyDown(key);
            }
        }

        #endregion

        private void LoadGuiObjects() {
            _gameObjects = new SceneObject[] {
                // Example: 

                //new Image() {
                //    Name = "imgBackground",
                //    Visible = true
                //},
                //new Textbox() {
                //    Name = "txtInput",
                //    Width = 300,
                //    Height = 50
                //}
            };
        }
    }
}
