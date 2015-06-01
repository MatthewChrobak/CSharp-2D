using System;

using SFML.Window;
using SFML.Graphics;

using MapEditor.Data.Models.Maps;

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

            int x = Convert.ToInt32(Math.Floor((double)e.X / Tile.TileSize));
            int y = Convert.ToInt32(Math.Floor((double)e.Y / Tile.TileSize));

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

            int x = Convert.ToInt32(Math.Floor((double)e.X / Tile.TileSize));
            int y = Convert.ToInt32(Math.Floor((double)e.Y / Tile.TileSize));

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

                        if (x < map.Width && y < map.Height) {
                            for (int tX = StartX; tX <= FinishX; tX++) {
                                for (int tY = StartY; tY <= FinishY; tY++) {
                                    if (tX >= 0 && tY >= 0) {
                                        int layerID = Editor.TilesetWindow.Layer.SelectedIndex;

                                        if (layerID > -1) {
                                            int layerType = (int)LayerType.Mask;
                                            int MaskCount = map.Layers[(int)LayerType.Mask].Count;
                                            int FringeCount = map.Layers[(int)LayerType.Fringe].Count;

                                            if (layerID >= MaskCount) {
                                                layerType = (int)LayerType.Fringe;
                                            }

                                            if (x + tX - StartX < map.Width && y + tY - StartY < map.Height) {
                                                var layer = map.Tile[x + tX - StartX, y + tY - StartY].Layer[layerType];
                                                if (_rightMouse) {
                                                    layer[layerID].Tileset = -1;
                                                } else {
                                                    layer[layerID].Tileset = Editor.TilesetWindow.Tilesets.SelectedIndex;
                                                }
                                                layer[layerID].X = tX;
                                                layer[layerID].Y = tY;
                                            }
                                        }
                                    }
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
