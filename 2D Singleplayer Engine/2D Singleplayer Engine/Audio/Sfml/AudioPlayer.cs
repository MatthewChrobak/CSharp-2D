using SFML.Audio;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace _2D_Singleplayer_Engine.Audio.Sfml
{
    public class AudioPlayer : IPlayer
    {
        // A private collection of all the currently playing music and sound.
        private List<PlayingMusic> _music;
        private List<PlayingSound> _sounds;

        // The thread object of the garbage collector for the audio player.
        private Thread _collecter;

        public void Initialize() {
            // Initialize the collections.
            _music = new List<PlayingMusic>();
            _sounds = new List<PlayingSound>();
        }

        private void AudioChecker() {
            // Boolean variable to mark the completion of the collecter.
            // The collecter is only finished when there are no playing sounds
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
                    if (_sounds[i].Finished()) {
                        // Dispose of the playing sound and remove it from the collection.
                        _sounds[i].Dispose();
                        _sounds.RemoveAt(i);
                    }
                }

                // Are there no remaining playing sounds or playing music?
                if (_music.Count == 0 && _sounds.Count == 0) {
                    // The collecter's job is done.
                    done = true;
                }
            } while (!done);
        }

        private void TryCreateAudioChecker() {
            // Is the collecter null, or has it stopped running?
            if (_collecter == null || _collecter.ThreadState != ThreadState.Running) {
                // Create a new thread of the AudioChecker method and start it.
                _collecter = new Thread(AudioChecker);
                _collecter.Start();
            }
        }

        private bool AudioFileExists(string path) {
            // Does the file exist?
            if (File.Exists(path)) {
                // Does it have the proper file extension?
                if (path.EndsWith(".wav") || path.EndsWith(".ogg") || path.EndsWith(".flac")) {
                    // It does.
                    return true;
                }
            }
            // The file is either not found, or has an invalid extension.
            return false;
        }


        public void PlayMusic(string name, bool loop = false, float volume = 100.0f) {
            // Does the audio file exist?
            if (AudioFileExists(AudioManager.MusicDir + name)) {

                // Create a new PlayingMusic object, and add it to our collection of 
                // currently playing music.
                _music.Add(new PlayingMusic(name, new Music(AudioManager.MusicDir + name), loop, volume));

                // Try and create the garbage collector for the audio player.
                TryCreateAudioChecker();
            }
        }

        public void PlaySound(string name, bool loop = false, float volume = 100.0f) {
            // Does the audio file exist?
            if (AudioFileExists(AudioManager.SoundDir + name)) {

                // Create a new PlayingSound object, and add it to our collection of
                // currently playing sound.
                _sounds.Add(new PlayingSound(name, new Sound(new SoundBuffer(AudioManager.SoundDir + name)), loop, volume));

                // Try and create the garbage collector for the audio player.
                TryCreateAudioChecker();
            }
        }

        public void StopMusics(string name) {
            // Loop through our collection of currently playing music.
            for (int i = _music.Count - 1; i >= 0; i--) {
                // If the playing music has the tag of the specified name, then 
                // flag it to be disposed.
                if (_music[i].Tag == name) {
                    _music[i].Flag = AudioFlag.DISPOSABLE;
                }
            }
        }

        public void StopSounds(string name) {
            // Loop through our collection of currently playing sound.
            for (int i = _sounds.Count - 1; i >= 0; i--) {
                // If the playing sound has the tag of the specified name, then
                // flag it to be disposed.
                if (_sounds[i].Tag == name) {
                    _sounds[i].Flag = AudioFlag.DISPOSABLE;
                }
            }
        }

        public void StopAllMusics() {
            // Flag every playing music in the collection to be disposed.
            for (int i = _music.Count - 1; i >= 0; i--) {
                _music[i].Flag = AudioFlag.DISPOSABLE;
            }
        }

        public void StopAllSounds() {
            // Flag every playing sound in the collection to be disposed.
            for (int i = _sounds.Count - 1; i >= 0; i--) {
                _sounds[i].Flag = AudioFlag.DISPOSABLE;
            }
        }
    }
}
