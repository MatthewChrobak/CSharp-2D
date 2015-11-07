using SFML.Audio;

namespace _2D_Singleplayer_Engine.Audio.Sfml
{
    public class PlayingMusic
    {
        public string Tag { get; set; }
        public Music Music { get; private set; }
        public AudioFlag Flag { get; set; }

        public PlayingMusic(string tag, Music music, bool loop, float volume) {
            this.Music = music;
            this.Music.Loop = loop;
            this.Music.Volume = volume;
            this.Music.Play();
            this.Tag = tag;
        }

        public void Dispose() {
            // Stop the music before disposing.
            Music.Stop();
            Music.Dispose();
        }

        public bool Disposable() {
            // Return true only if the music has stopped or is flagged as disposable.
            return (Music.Status == SoundStatus.Stopped || Flag == AudioFlag.DISPOSABLE) ? true : false;
        }
    }
}
