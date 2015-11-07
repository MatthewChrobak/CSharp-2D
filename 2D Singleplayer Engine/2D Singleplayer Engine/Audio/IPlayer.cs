namespace _2D_Singleplayer_Engine.Audio
{
    interface IPlayer
    {
        void Initialize();
        void PlaySound(string name, bool loop, float volume);
        void PlayMusic(string name, bool loop, float volume);

        void StopSounds(string name);
        void StopMusics(string name);

        void StopAllSounds();
        void StopAllMusics();
    }
}
