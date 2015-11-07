namespace _2D_Singleplayer_Engine.Audio
{
    public static class AudioManager
    {
        // Sound directories.
        public static string AudioDir = Program.StartupPath + "audio\\";
        public static string MusicDir = AudioDir + "music\\";
        public static string SoundDir = AudioDir + "sounds\\";

        // The class object containing the audio system.
        private static IPlayer _player;

        public static void Initialize() {
            // Set and initialize the audio system inheriting the IPlayer interface.
            _player = new Sfml.AudioPlayer();
            _player.Initialize();
        }

        #region Static IPlayer Methods

        // Ensure that all IPlayer required methods are included in this manager, so that 
        // we may invoke the audio system's declaration of the required methods when we invoke the 
        // manager's methods.

        public static void PlayMusic(string name, bool loop = false, float volume = 100.0f) {
            // Invoke the audio player's method of the same name.
            _player.PlayMusic(name, loop, volume);
        }

        public static void PlaySound(string name, bool loop = false, float volume = 100.0f) {
            // Invoke the audio player's method of the same name.
            _player.PlaySound(name, loop, volume);
        }

        public static void StopMusics(string name) {
            // Invoke the audio player's method of the same name.
            _player.StopMusics(name);
        }

        public static void StopSounds(string name) {
            // Invoke the audio player's method of the same name.
            _player.StopSounds(name);
        }

        public static void StopAllMusics() {
            // Invoke the audio player's method of the same name.
            _player.StopAllMusics();
        }

        public static void StopAllSounds() {
            // Invoke the audio player's method of the same name.
            _player.StopAllSounds();
        }
        #endregion
    }
}
