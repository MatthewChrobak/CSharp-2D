using SFML.Audio;

namespace MultiplayerEngine_Client.Audio.Sfml
{
    public class PlayingSound
    {
        public string Tag { private set; get; }
        private Sound Sound;
        private AudioFlag Flag;

        public PlayingSound(string tag, Sound sound, bool loop, float volume) {
            // Assign the sound given.
            this.Sound = sound;

            // Configure it with the specifications given.
            this.Sound.Loop = loop;
            this.Sound.Volume = volume;
            this.Tag = tag;

            // Flag the sound as NoError to prevent disposing.
            this.Flag = AudioFlag.NoError;

            // Finally, play the sound.
            this.Sound.Play();
        }

        public void FlagDisposable() {
            this.Flag = AudioFlag.Disposable;
        }

        public void Dispose() {
            // Stop the sound before disposing.
            this.Sound.Stop();
            this.Sound.Dispose();
        }

        public bool Disposable() {
            // Return true only if the sound has stopped, or is flagged as disposable.
            return (Sound.Status == SoundStatus.Stopped || this.Flag == AudioFlag.Disposable);
        }

    }
}