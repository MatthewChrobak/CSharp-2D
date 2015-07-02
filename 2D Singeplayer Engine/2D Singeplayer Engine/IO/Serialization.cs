using System.IO;
using System.Xml.Serialization;

namespace _2D_Singeplayer_Engine.IO
{
    public static class Serialization
    {
        public static object Deserialize<T>(string file, System.Type type) {
            // If the file does not exist, return null.
            if (!File.Exists(file)) {
                return null;
            }

            var xml = new XmlSerializer(type);
            var stream = new FileStream(file, FileMode.Open);
            var instance = (T)xml.Deserialize(stream);
            stream.Close();
            return instance;
        }

        public static void Serialize<T>(string file, System.Type type, object instance) {
            var xml = new XmlSerializer(type);
            var stream = new StreamWriter(file);
            xml.Serialize(stream, (T)instance);
            stream.Close();
        }
    }
}
