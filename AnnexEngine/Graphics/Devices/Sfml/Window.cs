using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace AnnexEngine.Graphics.Devices.Sfml
{
    /// <summary>
    /// A window created using SFML.
    /// </summary>
    public class Window : RenderWindow
    {        
        /// <summary>
        /// The ratio of window-size to draw-size.
        /// </summary>
        private Vector2f _sizeRatio;

        /// <summary>
        /// Creates a render window with the specified width, height, and title.
        /// </summary>
        /// <param name="width">The desired width of the window.</param>
        /// <param name="height">The desired height of the window.</param>
        /// <param name="title">The desired title of the window.</param>
        public Window(uint width, uint height, string title) : base(new VideoMode(), title)
        {
            // Resize the window to the desired size.
            this.Resize(width, height);

            // Initialize the event handlers.
            this.InitializeEventHandlers();
        }

        /// <summary>
        /// Resizes the window's dimentions to a desired size.
        /// </summary>
        /// <param name="size">The desired size of the window.</param>
        public void Resize(Vector2u size)
        {
            // Call the overloaded method.
            this.Resize(size.X, size.Y);
        }

        /// <summary>
        /// Resizes the window's dimentions to a desired size.
        /// </summary>
        /// <param name="width">The desired width of the window.</param>
        /// <param name="height">The desired height of the window.</param>
        public void Resize(uint width, uint height)
        {
            // Resize the actual window.
            this.Size = new Vector2u(width, height);

            // Adjust the size ratio.
            this._sizeRatio.X = (float)this.Size.X / width;
            this._sizeRatio.Y = (float)this.Size.Y / height;
        }

        /// <summary>
        /// Connects IO events to the scene system.
        /// </summary>
        public void InitializeEventHandlers()
        {
            // TODO: Make all this hook up using an interface instead of assuming it'll always go to the scene system.
            this.Resized += (sender, e) => {
                this.Resize(new Vector2u(e.Width, e.Height));
            };

            this.MouseButtonPressed += (sender, e) =>
            {

            };

            this.MouseButtonReleased += (sender, e) =>
            {

            };

            this.MouseMoved += (sender, e) =>
            {

            };

            this.KeyPressed += (sender, e) =>
            {

            };

            this.KeyReleased += (sender, e) =>
            {

            };

            this.Closed += (sender, e) =>
            {

            };
        }
    }
}
