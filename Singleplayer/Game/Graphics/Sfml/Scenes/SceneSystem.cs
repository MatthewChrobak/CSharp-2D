using Game.Graphics.Sfml.Scenes.Objects;
using SFML.Graphics;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System;

namespace Game.Graphics.Sfml.Scenes
{
    public class SceneSystem : IScenes
    {
        // The collection of all the scene related surfaces, and objects.
        private List<GraphicalSurface> _surfaces;
#if DEBUG
        // Let the collection be publicly modifiable in debugging mode.
        public List<SceneObject>[] _UIObject { set; get; }

        // Add the scene constructor for debugging purposes only.
        private GuiEditor SceneEditor = new GuiEditor();
#elif !DEBUG 
         // Prevent the collection from being modified in release mode.
        public List<SceneObject>[] _UIObject { private set; get; }
#endif

        // The scene object that has the current focus.
        private SceneObject _curFocus;

        // General bool variable stating whether or not the mouse buttons are down.
        public bool MouseLeftDown { private set; get; }
        public bool MouseMiddleDown { private set; get; }
        public bool MouseRightDown { private set; get; }


        // All these methods pertain to event handling.
        // You shouldn't have to change this.
#region Core Scene System Logic

        public SceneSystem() {
            // Create an array of collections containing scene objects for 
            // every game state.
            this._UIObject = new List<SceneObject>[(int)GameState.Length];
            for (int i = 0; i < this._UIObject.Length; i++) {
                this._UIObject[i] = new List<SceneObject>();
            }

            // Initialize the scene system.
            Initialize();
        }

        private void Initialize() {
            // Load all the graphical surfaces.
            this.LoadSurfaces();

            // Load all the hard-coded scene objects.
            this.LoadSceneObjects();
        }

        public void Reload() {
            // The scene system can be reloaded by first destroying it, and 
            // then initializing it.
            this.Destroy();
            this.Initialize();
        }

        public void Destroy() {
            // Clear every scene in the scene system.
            foreach (var scene in this._UIObject) {
                scene.Clear();
            }

            // Clear the collection of surfaces.
            this._surfaces.Clear();
        }

        private void LoadSurfaces() {
            // Initialize the collection.
            this._surfaces = new List<GraphicalSurface>();

            // Load every png and jpg file we find in the directory specified.
            foreach (string file in Directory.GetFiles(GraphicsManager.GuiPath).Where((x) => {
                return x.EndsWith(".png") || x.EndsWith(".jpg");
            })) {
                this._surfaces.Add(new GraphicalSurface(file));
            }
        }

        public void MouseMove(int x, int y) {
            // If our left mouse button is down, we can apply dragging
            // processing on our focused scene object.
            if ((this.MouseLeftDown || this.MouseRightDown) && this._curFocus != null) {
                this._curFocus.Drag(x, y);
            }

            // Make sure that we actually initialized the scene system.
            if (this._UIObject != null) {
                // Make sure that we actually have scene objects in our current state.
                if (this._UIObject[(int)Game.State] != null) {
                    // Loop through every object in the scene system.
                    // Treat each array index as the Z value.
                    for (int z = this._UIObject[(int)Game.State].Count - 1; z >= 0; z--) {
                        var obj = this._UIObject[(int)Game.State][z];

                        // Is the object visible?
                        if (obj.Visible) {
                            // Did we move our mouse within the area of the scene object?
                            if (x >= obj.Left && x <= obj.Left + obj.Width) {
                                if (y >= obj.Top && y <= obj.Top + obj.Height) {

                                    // We did. Invoke appropriate event-handling methods.
                                    obj.ObjectMouseMove(x - obj.Left, y - obj.Top);

                                    // We assume we have the object we moused over.
                                    // Return so that we don't apply similar logic on scene objects that 
                                    // should not receive this processing.
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void MouseUp(string button, int x, int y) {
            // Set the states of the appropriate mouse button to not pressed.
            switch (button) {
                case "left":
                    this.MouseLeftDown = false;
                    break;
                case "middle":
                    this.MouseMiddleDown = false;
                    break;
                case "right":
                    this.MouseRightDown = false;
                    break;
            }

            // Since we're lifting a mouse button, do we have a 
            // currently focused scene object?
            if (this._curFocus != null) {
                // Invoke the EndDrag method for that object.
                this._curFocus.EndObjectDrag();
            }
        }

        public void MouseDown(string button, int x, int y) {
            // Set the states of the appropriate mouse button to pressed.
            switch (button) {
                case "left":
                    this.MouseLeftDown = true;
                    break;
                case "middle":
                    this.MouseMiddleDown = true;
                    break;
                case "right":
                    this.MouseRightDown = true;
                    break;
            }

#if DEBUG
            // If the scene editor is not visible, show it.
            if (!this.SceneEditor.Visible) {
                this.SceneEditor.Show();
            }
#endif

            // Make sure that the scene system has actually been initialized.
            if (this._UIObject != null) {
                // Make sure that we actually have scene objects in our current state.
                if (this._UIObject[(int)Game.State] != null) {
                    // Loop through every object in the scene system.
                    // Treat each array index as the Z value.
                    for (int z = this._UIObject[(int)Game.State].Count - 1; z >= 0; z--) {
                        var obj = this._UIObject[(int)Game.State][z];

                        // Make sure that the object is visible.
                        if (obj.Visible) {
                            // Did we click within the area of the scene object?
                            if (x >= obj.Left && x <= obj.Left + obj.Width) {
                                if (y >= obj.Top && y <= obj.Top + obj.Height) {

                                    //If we had a previous scene object, let that object
                                    // know that it no longer has the focus.
                                    if (this._curFocus != null) {
                                        this._curFocus.HasFocus = false;
                                    }

                                    // Assign this scene object as our currently focused scene object and
                                    // let it know that it has our focus.
                                    this._curFocus = obj;
                                    this._curFocus.HasFocus = true;

#if DEBUG
                                    // Load the currently focused object in the scene editor.
                                    this.SceneEditor.LoadObject(ref _curFocus);
#endif


                                    // Invoke the appropriate event handling methods.
                                    this._curFocus.ObjectMouseDown(button, x - obj.Left, y - obj.Top);
                                    this._curFocus.BeginDrag(x - obj.Left, y - obj.Top);

                                    // We assume that we have the object we clicked on.
                                    // Return so that we don't apply similar logic on scene objects that
                                    // should not receive this processing.
                                    return;
                                }
                            }
                        }
                    }
                }
            }
        }

        public void KeyDown(string key) {
            // Keypress event handling regarding the scene system requires an
            // object being focused.
            if (this._curFocus != null) {
                this._curFocus.ObjectKeyDown(key);
            }
        }

        public void KeyUp(string key) {
            // Keyup event handling regarding the scene system requires an
            // object being focused.
            if (this._curFocus != null) {
                this._curFocus.ObjectKeyUp(key);
            }
        }

        public void Draw() {
            // Make sure that we've actually loaded the scene system.
            if (this._UIObject != null) {
                // Make sure we actually have scene objects in our current state.
                if (this._UIObject[(int)Game.State] != null) {
                    // Draw every object in this scene if it's visible.
                    foreach (var obj in this._UIObject[(int)Game.State]) {
                        if (obj.Visible) {
                            obj.Draw();
                        }
                    }
                }
            }
        }

        public GraphicalSurface GetSurface(string tagName) {
            // Loop through our collection of graphical surfaces.
            foreach (var surface in this._surfaces) {
                // If the surface's tag matches our specific tag, return the surface.
                if (surface.Tag == tagName.ToLower()) {
                    return surface;
                }
            }
            // If the surface does not exist, return null.
            return null;
        }

        public SceneObject GetUIObject(string name) {
            // Make sure that we actually initialized the scene system.
            if (this._UIObject != null) {
                // Make sure we actually have scene objects in our current state.
                if (this._UIObject[(int)Game.State] != null) {
                    // Loop through all the scene objects in our current state.
                    foreach (var obj in this._UIObject[(int)Game.State]) {
                        // If the object has the same name as the one specified, return it.
                        if (obj.Name?.ToLower() == name?.ToLower()) {
                            return obj;
                        }
                    }
                }
            }
            // If the scene object could not be found, return null.
            return null;
        }

#endregion

        private void LoadSceneObjects() {

        }
    }
}
