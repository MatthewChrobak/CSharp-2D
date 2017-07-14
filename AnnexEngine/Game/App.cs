using AnnexEngine.Launcher.Application.Frameworks;

namespace AnnexGame
{
    public class App : SingleplayerClient
    {
        public static void Main(string[] args)
        {
            // Start a new instance of this application.
            AppManager.Start(new App());
        }
    }
}
