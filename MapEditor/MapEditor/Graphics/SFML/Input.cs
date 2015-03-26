using System;

using SFML.Window;
using SFML.Graphics;

namespace MapEditor.Graphics.SFML
{
    public class Input : iInput
    {
        public static int StartX = 0;
        public static int StartY = 0;
        public static int FinishX = 0;
        public static int FinishY = 0;
        private static bool _mouseDown;
        private static bool _rightMouse;
        public static bool MainFocus = true;

        public void MouseDown(object sender, object obj) {
            // Convert the object into a MouseButtonEventArgs object.
            var e = (MouseButtonEventArgs)obj;
            var owner = (RenderWindow)sender;
            if (e.Button == Mouse.Button.Right) {
                _rightMouse = true;
            } else {
                _rightMouse = false;
            }

            int x = Convert.ToInt32(Math.Floor((double)e.X / 32));
            int y = Convert.ToInt32(Math.Floor((double)e.Y / 32));

            // Focus on the window if we don't already have the focus.
            if (owner.Size.X == Editor.Window.Size.Width - Editor.Window.HorizontalFormWeight) {
                Editor.Window.Focus();
                MainFocus = true;
            } else {
                Editor.TilesetWindow.Focus();
                MainFocus = false;
            }

            if (!MainFocus) {
                StartX = x;
                StartY = y;
                FinishX = x;
                FinishY = y;
            }

            _mouseDown = true;
        }

        public void MouseUp(object sender, object obj) {
            // Convert the object into a MouseButtonEventArgs object.
            var e = (MouseButtonEventArgs)obj;

            _mouseDown = false;
        }

        public void MouseMove(object sender, object obj) {
            // Convert the object into a MouseMoveEventArgs object.
            var e = (MouseMoveEventArgs)obj;

            int x = Convert.ToInt32(Math.Floor((double)e.X / 32));
            int y = Convert.ToInt32(Math.Floor((double)e.Y / 32));

            if (_mouseDown) {

                if (!MainFocus) {
                    if (x < StartX) {
                        FinishX = StartX;
                        StartX = x;
                    } else {
                        FinishX = x;
                    }

                    if (y < StartY) {
                        FinishY = StartY;
                        StartY = y;
                    } else {
                        FinishY = y;
                    }
                } else {
                    if (Data.DataManager.curMap != -1) {
                        var map = Data.DataManager.Map[Data.DataManager.curMap];

                        for (int tX = StartX; tX <= FinishX; tX++) {
                            for (int tY = StartY; tY <= FinishY; tY++) {
                                if (tX >= 0 && tY >= 0) {
                                    var layer = map.Tile[x + tX, y + tY].Layer[Editor.TilesetWindow.Layer.SelectedIndex];
                                    if (_rightMouse) {
                                        layer.Tileset = 0;
                                    } else {
                                        layer.Tileset = Editor.TilesetWindow.Tilesets.SelectedIndex;
                                    }
                                    layer.X = tX;
                                    layer.Y = tY;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void KeyPress(object sender, object obj) {
            // Convert the object to a KeyEventArgs object.
            var e = (KeyEventArgs)obj;
        }

        public void KeyRelease(object sender, object obj) {
            // Convert the object into a KeyEventArgs object.
            var e = (KeyEventArgs)obj;
        }

        public void CheckKeys() {

        }
    }
}
