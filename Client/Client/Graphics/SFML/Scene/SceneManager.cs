using System.Collections.Generic;

using Client.Graphics.SFML.Scene.Objects;
using Client.Data;

namespace Client.Graphics.SFML.Scene
{
    public static class SceneManager
    {
        private static List<SceneObject> _gameObjects;
        private static List<SceneObject> _menuObjects;
        private static SceneObject _curFocus;
        private static int z = -1;

        /// <summary>
        /// This method loads all the scene objects to the scene manager.
        /// </summary>
        public static void Load() {
            LoadMenuObjects();
            LoadGameObjects();
        }
        public static void Destroy() {
            _menuObjects.Clear();
            _gameObjects.Clear();
            z = -1;
        }
        public static void Reload() {
            Destroy();
            Load();
        }

        private static void LoadMenuObjects() {

            // Initialize the list.
            _menuObjects = new List<SceneObject>();

            // Background image
            _menuObjects.Add(
                new Image() {
                    Name = "imgBackground",
                    Width = Client.Window.Width,
                    Height = Client.Window.Height,
                    ImageTag = "background-scenic"
                });
            _curFocus = _menuObjects[0];

            _menuObjects.Add(
                new Label() {
                    Name = "lblLogin",
                    Left = 75,
                    FontSize = 20,
                    TextColor = new global::SFML.Graphics.Color(255, 255, 255),
                    Top = 250,
                    Width = 100,
                    Height = 45,
                    Caption = "login"
                });

            _menuObjects.Add(
                new Label() {
                    Name = "lblCreate",
                    Left = 75,
                    FontSize = 20,
                    TextColor = new global::SFML.Graphics.Color(255, 255, 255),
                    Top = 300,
                    Width = 100,
                    Height = 45,
                    Caption = "create"
                });

            _menuObjects.Add(
                new Label() {
                    Name = "lblOptions",
                    Left = 75,
                    FontSize = 20,
                    TextColor = new global::SFML.Graphics.Color(255, 255, 255),
                    Top = 350,
                    Width = 100,
                    Height = 45,
                    Caption = "options"
                });

            // Username
            _menuObjects.Add(
                new Textbox() {
                    Name = "txtUsername",
                    ImageTag = "textbox",
                    Top = 275,
                    Left = 250,
                    Width = 200,
                    Height = 25,
                    TextColor = new global::SFML.Graphics.Color(255, 255, 255),
                    FontSize = 14,
                    MaxLength = 24
                });
            // Passwordbox
            _menuObjects.Add(
                new Textbox() {
                    Name = "txtPassword",
                    ImageTag = "textbox",
                    Top = 325,
                    Left = 250,
                    Width = 200,
                    Height = 25,
                    TextColor = new global::SFML.Graphics.Color(255, 255, 255),
                    FontSize = 14,
                    MaxLength = 24,
                    PasswordChar = '*'
                });
            _menuObjects.Add(
                new CheckBox() {
                    Name = "chkTest",
                    ImageTag = "checkbox",
                    Top = 375,
                    Left = 275,
                    Width = 100,
                    Height = 25,
                    TextColor = new global::SFML.Graphics.Color(255, 255, 255),
                    Caption = "Check something?",
                    FontSize = 14
                });
        }
        private static void LoadGameObjects() {

            // Initialize the list.
            _gameObjects = new List<SceneObject>();
        }

        public static SceneObject getMenuObject(string name) {
            foreach (var obj in _menuObjects) {
                if (obj.Name == name) {
                    return obj;
                }
            }
            return null;
        }
        public static SceneObject getGameObject(string name) {
            foreach (var obj in _gameObjects) {
                if (obj.Name == name) {
                    return obj;
                }
            }
            return null;
        }

        public static int getZ() {
            z++;
            return z;
        }

        public static void Draw() {
            if (Client.inGame) {
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

        public static void MouseDown(int x, int y) {
            if (Client.inGame) {
                for (int z = _gameObjects.Count - 1; z >= 0; z--) {
                    foreach (SceneObject obj in _gameObjects) {
                        if (obj.Z == z) {
                            if (x >= obj.Left && x <= obj.Left + obj.Width) {
                                if (y >= obj.Top && y <= obj.Top + obj.Height) {
                                    _curFocus.HasFocus = false;
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
                for (int z = _menuObjects.Count - 1; z >= 0; z--) {
                    foreach (SceneObject obj in _menuObjects) {
                        if (obj.Z == z) {
                            if (x >= obj.Left && x <= obj.Left + obj.Width) {
                                if (y >= obj.Top && y <= obj.Top + obj.Height) {
                                    _curFocus.HasFocus = false;
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

        public static void MouseMove(int x, int y) {
            if (Client.inGame) {
                for (int z = _gameObjects.Count - 1; z >= 0; z--) {
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
                for (int z = _menuObjects.Count - 1; z >= 0; z--) {
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

        public static void KeyDown(string key) {
            if (_curFocus != null) {
                _curFocus.KeyDown(key);
            }
        }
    }
}
