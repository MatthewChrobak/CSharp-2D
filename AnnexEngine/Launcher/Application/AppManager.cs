using AnnexEngine.Launcher.Application;

/// <summary>
/// Manages an instance of an application.
/// </summary>
public static class AppManager
{
    /// <summary>
    /// The current application instance managed by the object.
    /// </summary>
    public static AppBehaviour Instance { private set; get; }

    /// <summary>
    /// Stores and starts the given application unless another application is being processed.
    /// </summary>
    /// <param name="app">The application to be started.</param>
    public static void Start(AppBehaviour app)
    {
        // If there is no other application currently being stored, store the given application.
        if (AppManager.Instance == null) {
            AppManager.Instance = app;

            // There is no guarentee that the app given is non-null.
            // Run the application, and when its main application loop terminates, exit the application.
            AppManager.Instance?.Run();
            AppManager.Instance?.Exit();
        }
    }

    /// <summary>
    /// Terminates the application.
    /// </summary>
    public static void Close()
    {
        // There is no guarentee that the application is non-null. 
        // Flag the application to close if it's non-null.
        AppManager.Instance?.FlagToClose();

        // Set the instance to null, so we can start another application.
        AppManager.Instance = null;
    }
}