using System.IO;
using System.Xml.Serialization;

namespace _2D_Singleplayer_Engine.IO
{
    public static class Serialization
    {
        public static T Deserialize<T>(string file, System.Type type) {
            // If the XML file does not exist, there's nothing to 
            // deserialize. Return a default instance of the type.
            if (!File.Exists(file)) {
                return default(T);
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

        public static void Serialize<T>(string file, System.Type type, object instance) {
            // We can always assume that the file does not exist.
            // If it does, it will be overwritten.
            var xml = new XmlSerializer(type);
            var stream = new StreamWriter(file);
            xml.Serialize(stream, (T)instance);
            stream.Close();
        }
    }
}
