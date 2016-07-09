using System;
using System.IO;
using System.Xml.Serialization;

namespace SingleplayerEngine.IO
{
    public class Serialization
    {
        public static T Deserialize<T>(string file, Type type) {
            // If the XML file does not exist, throw an exception.
            if (!File.Exists(file)) {
                throw new FileNotFoundException("Serialization: " + file + " of type " + type.ToString());
            }

            // The file exists, so deserialize the data and store it
            // in a new object of the type T.
            var xml = new XmlSerializer(type);
            var stream = new FileStream(file, FileMode.Open);
            var instance = (T)xml.Deserialize(stream);
            stream.Close();

            // Return the instance.
            return instance;
        }

        public static void Serialize<T>(string file, Type type, object instance) {
            // We can assume that the file does not exist.
            // If it does, it will be overwritten.
            var xml = new XmlSerializer(type);
            var stream = new StreamWriter(file);
            xml.Serialize(stream, (T)instance);
            stream.Close();
        }
    }
}
