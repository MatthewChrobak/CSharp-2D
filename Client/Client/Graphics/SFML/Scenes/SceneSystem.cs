using System.Collections.Generic;
using System.IO;

using Client;
using Graphics.Sfml.Scenes.Objects;
using Data;

namespace Graphics.Sfml.Scenes
{
    public class SceneSystem
    {
        public List<GraphicalSurface> Surface { private set; get; }
        private SceneObject[] _gameObjects;
        private SceneObject[] _menuObjects;
        private SceneObject _curFocus;

        // Initialization.
        public SceneSystem() {
            LoadSurfaces();
            LoadGuiObjects();
        }

        public void Draw() {
            if (Application.inGame) {
                foreach (SceneObject obj in _gameObjects) {
                    if (obj.Visible) {
                        obj.Draw();
                    }
                }
            } else {
                foreach (SceneObject obj in _menuObjects) {
                    if (obj.Visible) {
                        obj.Draw();
                    }
                }
            }
        }

        private void LoadSurfaces() {
            Surface = new List<GraphicalSurface>();

            foreach (string file in Directory.GetFiles(GraphicsManager.GuiPath, "*.png")) {
                Surface.Add(new GraphicalSurface(file));
            }
        }

        private void LoadGuiObjects() {
            
            #region Menu
            _menuObjects = new SceneObject[] {
                new Image() {
                        Name = "imgBackground",
                        Width = Application.Window.GetTrueSize().Width,
                        Height = Application.Window.GetTrueSize().Height,
                        Surface = getSurface("background-scenic")
                },
                new Label() {
                    Name = "lblLogin",
                    Left = 75,
                    FontSize = 20,
                    TextColor = new global::SFML.Graphics.Color(255, 255, 255),
                    Top = 250,
                    Width = 100,
                    Height = 45,
                    Caption = "login",
                    Surface = getSurface("blur")
                },
                new Label() {
                    Name = "lblCreate",
                    Left = 75,
                    FontSize = 20,
                    TextColor = new global::SFML.Graphics.Color(255, 255, 255),
                    Top = 300,
                    Width = 100,
                    Height = 45,
                    Caption = "create",
                    Surface = getSurface("blur")
                },
                new Label() {
                    Name = "lblOptions",
                    Left = 75,
                    FontSize = 20,
                    TextColor = new global::SFML.Graphics.Color(255, 255, 255),
                    Top = 350,
                    Width = 100,
                    Height = 45,
                    Caption = "options",
                    Surface = getSurface("blur")
                },
                new Textbox() {
                    Name = "txtUsername",
                    Surface = getSurface("textbox"),
                    Top = 275,
                    Left = 250,
                    Width = 200,
                    Height = 25,
                    TextColor = new global::SFML.Graphics.Color(255, 255, 255),
                    FontSize = 12,
                    MaxLength = 24
                },
                new Textbox() { 
                    Name = "txtPassword",
                    Surface = getSurface("textbox"),
                    Top = 325,
                    Left = 250,
                    Width = 200,
                    Height = 25,
                    TextColor = new global::SFML.Graphics.Color(255, 255, 255),
                    FontSize = 10,
                    MaxLength = 24,
                    PasswordChar = '*'
                },
                new CheckBox() { 
                    Name = "chkTest",
                    Surface = getSurface("checkbox_marked"),
                    Surface2 = getSurface("checkbox_unmarked"),
                    Top = 375,
                    Left = 275,
                    Width = 100,
                    Height = 25,
                    TextColor = new global::SFML.Graphics.Color(255, 255, 255),
                    Caption = "Check something?",
                    FontSize = 12
                }
            };
            #endregion

            #region Game
            _gameObjects = new SceneObject[] {

            };
            #endregion
        }
        
        public GraphicalSurface getSurface(string tagName) {
            foreach (var surface in Surface) {
                if (surface.tag.ToLower() == tagName.ToLower()) {
                    return surface;
                }
            }
            return null;
        }

        public SceneObject getMenuObject(string name) {
            foreach (var obj in _menuObjects) {
                if (obj.Name == name) {
                    return obj;
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
            if (Application.inGame) {
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
            } else {
                for (int z = _menuObjects.Length - 1; z >= 0; z--) {
                    foreach (SceneObject obj in _menuObjects) {
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
        }

        public void MouseMove(int x, int y) {
            if (Application.inGame) {
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

            } else {
                for (int z = _menuObjects.Length - 1; z >= 0; z--) {
                    foreach (SceneObject obj in _menuObjects) {
                        if (obj.Z == z) {
                            if (obj.HasMouse) {
                                obj.HasMouse = false;
                            }
                            if (x >= obj.Left && x <= obj.Left + obj.Width) {
                                if (y >= obj.Top && y <= obj.Top + obj.Height) {
                                    obj.HasMouse = true;
                                    obj.MouseMove(x - obj.Left, y - obj.Top);
                                    return;
                                }
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
    }
}
