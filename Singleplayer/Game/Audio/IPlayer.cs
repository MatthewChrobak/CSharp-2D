namespace Game.Audio
{
    public interface IPlayer
    {
        void PlaySound(string name, bool loop = false, float volume = 100.0f);
        void PlayMusic(string name, bool loop = false, float volume = 100.0f);

        void StopSoundsByName(string name);
        void StopMusicsByName(string name);

        void StopAllSounds();
        void StopAllMusics();
    }
}
