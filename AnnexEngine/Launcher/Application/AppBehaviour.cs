using AnnexEngine.Data.Settings;
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
        /// The settings for the application.
        /// </summary>
        public Settings Settings { private set; get; }
        private readonly string _appSettingsFile = "settings.xml";


        /// <summary>
        /// Initializes the systems needed for the application.
        /// </summary>
        internal abstract void Setup();

        /// <summary>
        /// Saves and destroys any components used by the application.
        /// </summary>
        internal virtual void Exit()
        {
            this.Settings.SaveToFile(this._appSettingsFile);
        }


        /// <summary>
        /// Runs the setup process for the application.
        /// </summary>
        public AppBehaviour()
        {
            // Load the settings before running the applications setup, in case
            // we need to refer to any settings.
            this.Settings = new Settings();
            this.Settings.LoadSettingsFromFile(this._appSettingsFile);

            // Run the application specific setup.
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