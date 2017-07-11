using AnnexEngine.Launcher.Events;

namespace AnnexEngine.Launcher.Application
{
    /// <summary>
    /// Defines the behaviour for an application.
    /// </summary>
    public abstract class AppBehaviour : EventManager
    {
        /// <summary>
        /// The flag that controls the termination of the main application loop.
        /// </summary>
        private bool _closing = false;


        /// <summary>
        /// Initializes the systems needed for the application.
        /// </summary>
        internal abstract void Setup();

        /// <summary>
        /// Saves and destroys any components used by the application.
        /// </summary>
        internal abstract void Exit();


        /// <summary>
        /// Runs the setup process for the application.
        /// </summary>
        public AppBehaviour()
        {
            this.Setup();
        }

        /// <summary>
        /// The main application loop. Continues to process its events until triggered to terminate.
        /// </summary>
        internal void Run()
        {
            while (!this._closing) {
                this.ProcessEvents();
            }
        }

        /// <summary>
        /// Triggers the application to terminate.
        /// </summary>
        internal void FlagToClose()
        {
            this._closing = true;
        }
    }
}