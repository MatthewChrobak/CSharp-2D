using SFML.Audio;

namespace Game.Audio.Sfml
{
    public class PlayingMusic
    {
        public Music Music { private set; get; }
        public string Tag { private set; get; }
        private AudioFlag Flag;

        public PlayingMusic(string tag, Music music, bool loop, float volume) {
            // Assign the music given.
            this.Music = music;

            // Configure it with the specifications given.
            this.Music.Loop = loop;
            this.Music.Volume = volume;
            this.Tag = tag;

            // Flag the music as NoError to prevent disposing.
            this.Flag = AudioFlag.NoError;

            // Finally, play it.
            this.Music.Play();
        }

        public void FlagDisposable() {
            this.Flag = AudioFlag.Disposable;
        }

        public void Dispose() {
            // Stop the music before disposing.
            this.Music.Stop();
            this.Music.Dispose();
        }

        public bool Disposable() {
            // Return true only if the music has stopped or is flagged as disposable.
            return (Music.Status == SoundStatus.Stopped || this.Flag == AudioFlag.Disposable);
        }
    }
}