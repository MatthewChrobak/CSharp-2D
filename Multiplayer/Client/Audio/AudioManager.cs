namespace Client.Audio
{
    public static class AudioManager
    {
        // Sound directories.
        public static readonly string AudioDir = Client.StartupPath + "Audio\\";
        public static readonly string MusicDir = AudioDir + "Music\\";
        public static readonly string SoundDir = AudioDir + "Sounds\\";

        // The class object containing the audio system.
        public static IPlayer Player { private set; get; }

        public static void Initialize() {
            // Set and initialize the audio system.
            AudioManager.Player = new Sfml.AudioPlayer();
        }
    }
}
