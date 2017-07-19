using AnnexEngine.IO.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AnnexEngine.Data.Settings
{
    /// <summary>
    /// A serializable collection of settings contained as key/value pairs.
    /// </summary>
    [Serializable]
    public class Settings
    {
        /// <summary>
        /// The private collection of settings.
        /// </summary>
        private Dictionary<string, string> _settings;

        /// <summary>
        /// Initializes an empty collection of settings.
        /// </summary>
        public Settings()
        {
            this._settings = new Dictionary<string, string>();
        }

        /// <summary>
        /// An interface for the underlying settings collection.
        /// </summary>
        public SettingEntry[] AllSettings {
            get => this._settings.Select(entry => (SettingEntry)entry).ToArray();
            set => value.ToDictionary(entry => entry.Key, entry => entry.Value);
        }

        /// <summary>
        /// Adds or overwrites a setting within the collection.
        /// </summary>
        /// <param name="settingName">The name of the setting.</param>
        /// <param name="value">The value for the setting.</param>
        public void AddSetting(string settingName, string value)
        {
            this._settings[settingName] = value;
        }

        /// <summary>
        /// Adds a setting only if it does not exist within the collection.
        /// </summary>
        /// <param name="settingName">The name of the setting.</param>
        /// <param name="value">The setting's value.</param>
        // TODO: Maybe this should be renamed to something like 'set default setting'.
        public void AddSettingIfNotExists(string settingName, string value)
        {
            if (!this._settings.ContainsKey(settingName)) {
                this.AddSetting(settingName, value);
            }
        }

        /// <summary>
        /// Retrieves a setting's value. Returns an empty string if the setting does not exist.
        /// </summary>
        /// <param name="settingName">The name of the setting.</param>
        /// <returns>The setting's value.</returns>
        public string GetSetting(string settingName)
        {
            if (this._settings.ContainsKey(settingName)) {
                return this._settings[settingName];
            } else {
                return string.Empty;
            }
        }

        /// <summary>
        /// Removes all settings within the collection.
        /// </summary>
        public void Clear()
        {
            this._settings.Clear();
        }

        /// <summary>
        /// Saves the current settings to the specified file.
        /// </summary>
        /// <param name="filepath"></param>
        public void SaveToFile(string filepath)
        {
            using (var fs = new FileStream(filepath, FileMode.Create)) {

                // Apply the correct serialization based on the given file extention.
                string extension = filepath.Split('.').Last();
                switch (extension) {
                    case "xml":
                        fs.SerializeToXML(this);
                        break;
                    case "bin":
                        fs.SerializeToBinary(this);
                        break;
                    default:
                        throw new Exception($"Settings::SaveToFile({filepath}) -> unknown extension '{extension}'");
                }
            }
            
        }


        /// <summary>
        /// Loads a settings file, and adds its settings to the current collection.
        /// </summary>
        /// <param name="filepath">The filepath of the settings file to load settings from.</param>
        public void SetSettingsFromFile(string filepath)
        {
            if (File.Exists(filepath)) {
                using (var fs = new FileStream(filepath, FileMode.OpenOrCreate)) {

                    Settings settings;

                    // Apply the correct serialization based on the given file extention.
                    string extension = filepath.Split('.').Last();
                    switch (extension) {
                        case "xml":
                            settings = fs.DeserializeFromXML<Settings>();
                            break;
                        case "bin":
                            settings = fs.DeserializeFromBinary<Settings>();
                            break;
                        default:
                            throw new Exception($"Settings::LoadFromFile({filepath}) -> unknown extension '{extension}'");
                    }
                    
                    // Retrieve all settings from the object, and add them to the collection.
                    foreach (var setting in settings.AllSettings) {
                        this.AddSetting(setting.Key, setting.Value);
                    }
                }
            }
        }
    }
}
