using SFML.Audio;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace Client.Audio.Sfml
{
    public class AudioPlayer : IPlayer
    {
        // A private collection of all the currently playing music and sound.
        private List<PlayingMusic> _music;
        private List<PlayingSound> _sounds;

        // The thread object of the garbage collector for the audio player.
        private Thread _collector;

        public AudioPlayer() {
            // Initialize the collections.
            this._music = new List<PlayingMusic>();
            this._sounds = new List<PlayingSound>();
        }
        
        private void AudioChecker() {
            // A boolean variable to mark the completion of the collector.
            // The collector is only finished when there are no playing sounds
            // or music. Thus, initialize it as false.
            bool done = false;

            do {
                // Loop through every playing music in the collection.
                for (int i = _music.Count - 1; i >= 0; i--) {
                    // Is the playing music marked to be disposed of?
                    if (_music[i].Disposable()) {
                        // Dispose of the playing music and remove it from the collection.
                        _music[i].Dispose();
                        _music.RemoveAt(i);
                    }
                }

                // Loop through every playing sound in the collection.
                for (int i = _sounds.Count - 1; i >= 0; i--) {
                    // Is the playing sound marked to be disposed of?
                    if (_sounds[i].Disposable()) {
                        // Dispose of the playing sound and remove it from the collection.
                        _sounds[i].Dispose();
                        _sounds.RemoveAt(i);
                    }
                }

                // Are there no remaining playing sounds or playing music?
                if (_music.Count == 0 && _sounds.Count == 0) {
                    // The collector's job is done.
                    done = true;
                }
            } while (!done);
        }

        private void TryCreateAudioChecker() {
            // Is the collector null or has it stopped running?
            if (this._collector?.ThreadState != ThreadState.Running) {
                // Create a new thread of the AudioChecker method and start it.
                this._collector = new Thread(AudioChecker);
                this._collector.Start();
            }
        }

        private bool AudioFileExists(string path) {
            // Does the file exist?
            if (File.Exists(path)) {
                // Does it have the proper file extension?
                if (path.EndsWith(".wav") || path.EndsWith(".ogg") || path.EndsWith(".flac")) {
                    // It does.
                    return true;
                } else {
                    // The file has an invalid extension.
                    return false;
                }
            } else {
                throw new FileNotFoundException("AudioPlayer: " + path);
            }
        }

        public void PlayMusic(string name, bool loop = true, float volume = 100.0f) {
            // Does the audio file exist?
            if (AudioFileExists(AudioManager.MusicDir + name)) {
                // Create a new PlayingMusic object and add it to our collection
                // of currently playing music.
                this._music.Add(new PlayingMusic(name, new Music(AudioManager.MusicDir + name), loop, volume));

                // Try and create the garbage collector for the audio player.
                this.TryCreateAudioChecker();
            }
        }

        public void PlaySound(string name, bool loop = true, float volume = 100.0f) {
            // Does the audio file exist?
            if (AudioFileExists(AudioManager.SoundDir + name)) {
                // Create a new PlayingSound object and add it to our collection
                // of currently playing sound.
                this._sounds.Add(new PlayingSound(name, new Sound(new SoundBuffer(AudioManager.SoundDir + name)), loop, volume));

                // Try and create the garbage collector for the audio player.
                this.TryCreateAudioChecker();
            }
        }

        public void StopMusicsByName(string name) {
            // Loop through our collection of currently playing music.
            for (int i = 0; i < this._music.Count; i++) {
                // If the playing music has the tag of the specified name, then
                // flag it to be disposed.
                if (this._music[i].Tag == name) {
                    this._music[i].FlagDisposable();
                }
            }
        }

        public void StopSoundsByName(string name) {
            // Loop through our collection of currently playing sound.
            for (int i = 0; i < this._sounds.Count; i++) {
                // If the playing sound has the tag of the specified name, then
                // flag it to be disposed.
                if (this._sounds[i].Tag == name) {
                    this._sounds[i].FlagDisposable();
                }
            }
        }

        public void StopAllMusics() {
            // Flag every playing music in the collection to be disposed.
            foreach (var music in this._music) {
                music.FlagDisposable();
            }
        }

        public void StopAllSounds() {
            // Flag every playing sound in the collection to be disposed.
            foreach (var sound in this._sounds) {
                sound.FlagDisposable();
            }
        }
    }
}
