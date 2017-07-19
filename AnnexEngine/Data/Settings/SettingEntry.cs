using System;
using System.Collections.Generic;

namespace AnnexEngine.Data.Settings
{
    /// <summary>
    /// A serializable key/value pair object.
    /// </summary>
    [Serializable]
    public class SettingEntry
    {
        public string Key { set; get; }
        public string Value { get; set; }

        /// <summary>
        /// A default constructor for serialization support.
        /// </summary>
        public SettingEntry()
        {

        }
        
        /// <summary>
        /// Assigns the given key and value values to the object.
        /// </summary>
        /// <param name="Key">The key of the setting.</param>
        /// <param name="Value">The value of the setting.</param>
        public SettingEntry(string Key, string Value)
        {
            this.Key = Key;
            this.Value = Value;
        }

        /// <summary>
        /// Converts a KeyValuePair object to a SettingEntry.
        /// </summary>
        /// <param name="entry">The KeyValuePair object to be converted.</param>
        public static explicit operator SettingEntry(KeyValuePair<string, string> entry)
        {
            return new SettingEntry(entry.Key, entry.Value);
        }
    }
}
