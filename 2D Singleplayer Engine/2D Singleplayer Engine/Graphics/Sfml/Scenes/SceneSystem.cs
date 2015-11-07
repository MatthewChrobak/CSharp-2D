using _2D_Singleplayer_Engine.Graphics.Sfml.Scenes.Objects;
using System.Collections.Generic;
using System.IO;

namespace _2D_Singleplayer_Engine.Graphics.Sfml.Scenes
{
    public class SceneSystem
    {
        // The collection of all the scene related surfaces, and objects.
        private List<GraphicalSurface> Surface;
        private SceneObject[][] _UIObject;

        // The scene object that has the current focus.
        private SceneObject _curFocus;
        
        // General bool variable stating whether or not the mouse is down.
        public bool IsMouseDown { private set; get; }

        #region Core Scene System Logic
        //  All these methods pertain to event handling. 
        // You shouldn't have to change this.

        public SceneSystem() {
            // Create a multidimentional array of scene objects for every game state.
            _UIObject = new SceneObject[(int)GameState.Length][];

            // Load all the graphical surfaces.
            LoadSurfaces();

            // Load all the hard-coded scene objects.
            LoadSceneObjects();
        }

        public void Reload() {
            // In order to have a proper scene system reset, it is 
            // important that we reset the ZOrder first.
            ZOrder.ResetZOrder();
            // Overwrite the current scene objects with new ones.
            LoadSceneObjects();
        }

        public void Draw() {
            // Make sure that we've actually loaded the scene system.
            if (_UIObject != null) {
                // Make sure we actually have scene objects in our current state.
                if (_UIObject[(int)Program.State] != null) {
                    // Draw every object in this scene.
                    foreach (var obj in _UIObject[(int)Program.State]) {
                        if (obj.Visible) {
                            obj.Draw();
                        }
                    }
                }
            }
        }

        private void LoadSurfaces() {
            // Initialize the collection.
            Surface = new List<GraphicalSurface>();

            // Load every png file we find in the directory specified.
            foreach (string file in Directory.GetFiles(GraphicsManager.GuiPath, "*.png")) {
                Surface.Add(new GraphicalSurface(file));
            }
        }

        public GraphicalSurface getSurface(string tagName) {
            // Loop through our collection of graphical surfaces.
            foreach (var surface in Surface) {
                // If the surface's tag matches our specified tag, return the surface.
                if (surface.Tag == tagName.ToLower()) {
                    return surface;
                }
            }
            // If the surface does not exist, return null.
            return null;
        }

        public SceneObject getUIObject(string name) {
            // Make sure that we actually initialized the scene system.
            if (_UIObject != null) {
                // Make sure that we actually have scene objects in our current state.
                if (_UIObject[(int)Program.State] != null) {
                    // Loop through all the scene objects in our current state.
                    foreach (var obj in _UIObject[(int)Program.State]) {
                        // If the object has the same name as the one specified, return it.
                        if (obj.Name == name.ToLower()) {
                            return obj;
                        }
                    }
                }
            }
            // If the scene object could not be found, return null.
            return null;
        }

        // GUI Events
        public void MouseUp(int x, int y) {
            // Mark the IsMouseDown variable as false, because our 
            // mousebutton has been lifted.
            IsMouseDown = false;

            // Since we're lifting the mouse button, we can safely assume we 
            // can have a currently focused scene object.
            if (_curFocus != null) {
                // Invoke the EndDrag method for that object.
                _curFocus.EndDrag();
            }
        }

        public void MouseDown(int x, int y) {

            // Mark the IsMouseDown button as true, because our
            // mousebutton has been pressed.
            IsMouseDown = true;

            // Make sure that the scene system has actually been initialized.
            if (_UIObject != null) {
                // Make sure that we actually have scene objects in our current state.
                if (_UIObject[(int)Program.State] != null) {
                    // Loop through every possible ZOrder value.
                    for (int z = ZOrder.GetHighZ(); z >= 0; z--) {
                        // Loop through all the scene objects in our current state.
                        foreach (var obj in _UIObject[(int)Program.State]) {
                            // Does the ZIndex match the ZOrder?
                            if (obj.Z == z) {
                                // Make sure that the object is visible.
                                if (obj.Visible) {
                                    // Did we click within the area of the scene object?
                                    if (x >= obj.Left && x <= obj.Left + obj.Width) {
                                        if (y >= obj.Top && y <= obj.Top + obj.Height) {

                                            // If we had a previous scene object, let that object
                                            // know that it is no longer has the focus.
                                            if (_curFocus != null) {
                                                _curFocus.HasFocus = false;
                                            }

                                            // Assign this scene object as our currently focused scene object and
                                            // let it know that it has our focus.
                                            _curFocus = obj;
                                            _curFocus.HasFocus = true;

                                            // Invoke the appropriate event-handling methods.
                                            obj.MouseDown(x - obj.Left, y - obj.Top);
                                            obj.BeginDrag(x - obj.Left, y - obj.Top);

                                            // We assume we have the object we clicked on.
                                            // Return so that we don't apply similar logic on scene objects that
                                            // should not receive this processing.
                                            return;
                                        }
                                    }
                                }
                                // This break will break out of the current loop through all the scene objects for a respective Z value.
                                // It ensures we don't waste time looking for another object that can't exist.
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void MouseMove(int x, int y) {
            // If our mousebutton is down, we can apply dragging 
            // processing on our supposed focused scene object.
            // Check to see if the specifications qualify.
            if (IsMouseDown && _curFocus != null) {
                _curFocus.Drag(x, y);
            }

            // Make sure that we actually initialized the scene system.
            if (_UIObject != null) {
                // Make sure that we actually have scene objects in our current state.
                if (_UIObject[(int)Program.State] != null) {
                    // Loop through all possible values for the ZOrder.
                    for (int z = ZOrder.GetHighZ(); z >= 0; z--) {
                        // Loop through every scene object we have in our current state.
                        foreach (var obj in _UIObject[(int)Program.State]) {
                            // Does the object's ZIndex match the ZOrder?
                            if (obj.Z == z) {
                                // Is the object visible?
                                if (obj.Visible) {
                                    // Did we move our mouse within the area of the scene object?
                                    if (x >= obj.Left && x <= obj.Left + obj.Width) {
                                        if (y >= obj.Top && y <= obj.Top + obj.Height) {
                                            
                                            // We did. Invoke appropriate event-handling methods.
                                            obj.MouseMove(x - obj.Left, y - obj.Top);

                                            // We assume we have the object we moused over.
                                            // Return so that we don't apply similar logic on scene objects that
                                            // should not receive this processing.
                                            return;
                                        }
                                    }
                                }
                                // This break will break out of the current loop through all the scene objects for a respective Z value.
                                // It ensures we don't waste time looking for another object that can't exist.
                                break;
                            }
                        }
                    }
                }
            }
        }

        public void KeyDown(string key) {
            // Keypress event-handling regarding the scene system requires an 
            // object being focused. Do we have the qualifications?
            if (_curFocus != null) {
                // We do. Invoke appropriate methods.
                _curFocus.KeyDown(key);
            }
        }

        #endregion

        private void LoadSceneObjects() {
            // Initialize your scene system objects here.

            // EXAMPLE USAGE:
            //_UIObject[(int)GameState.MainMenu] = new SceneObject[] {
            //    new Image() {
            //        Name = "imgBackground",
            //        Surface = getSurface("Background"),
            //        Dragable = true
            //    },
            //    new Textbox() {
            //        Name = "txtUsername",
            //        Width = 100,
            //        Height = 100,
            //        FontSize = 12,
            //        TextColor = new SFML.Graphics.Color(0, 0, 0)
            //    }
            //};
        }
    }
}
