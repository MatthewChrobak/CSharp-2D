namespace Server.Data
{
    public class Settings
    {
        public static string File = Server.StartupPath + "data\\settings.xml";

        public string GameName = "Eclipse CSharp";
        public int Port = 7001;
        public string GameCache = Server.StartupPath + "data\\gamecache.dat";
    }
}
