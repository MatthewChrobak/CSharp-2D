using System;
using System.Collections.Generic;
using System.Linq;

namespace AnnexEngine.Launcher.Application.Data
{
    [Serializable]
    public class Settings
    {
        private Dictionary<string, string> _settings = new Dictionary<string, string>();

        public KeyValuePair<string, string>[] AllSettings {
            get {
                return _settings.ToArray();
            }
            set {
                foreach (var pair in value) {
                    this.AddSetting(pair.Key, pair.Value);
                }
            }
        }

        public void AddSetting(string settingName, string value)
        {
            if (this._settings.ContainsKey(settingName)) {
                this._settings[settingName] = value;
            } else {
                this._settings.Add(settingName, value);
            }
        }

        public string GetSetting(string settingName)
        {
            if (this._settings.ContainsKey(settingName)) {
                return this._settings[settingName];
            } else {
                return string.Empty;
            }
        }
    }
}
