using SFML.Audio;

namespace _2D_Singleplayer_Engine.Audio.Sfml
{
    public class PlayingSound
    {
        public string Tag { get; set; }
        public Sound Sound { get; private set; }
        public AudioFlag Flag { get; set; }

        public PlayingSound(string tag, Sound sound, bool loop, float volume) {
            this.Sound = sound;
            this.Sound.Loop = loop;
            this.Sound.Volume = volume;
            this.Sound.Play();
            this.Tag = tag;
        }

        public void Dispose() {
            // Stop the sound before disposing.
            Sound.Stop();
            Sound.Dispose();
        }

        public bool Finished() {
            // Return true only if the sound has stopped, or is flagged as disposable.
            return (Sound.Status == SoundStatus.Stopped || Flag == AudioFlag.DISPOSABLE) ? true : false;
        }
    }
}
