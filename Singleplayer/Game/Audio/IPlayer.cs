namespace Game.Audio
{
    public interface IPlayer
    {
        void PlaySound(string name, bool loop, float volume);
        void PlayMusic(string name, bool loop, float volume);

        void StopSoundsByName(string name);
        void StopMusicsByName(string name);

        void StopAllSounds();
        void StopAllMusics();
    }
}
