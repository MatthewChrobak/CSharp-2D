using System.IO;
using System.Xml.Serialization;

namespace AnnexEngine.IO.Serialization
{
    public static partial class StreamSerializationExtensions
    {
        public static void SerializeToXML<T>(this Stream stream, T instance)
        {
            new XmlSerializer(typeof(T)).Serialize(stream, instance);
        }

        public static T DeserializeFromXML<T>(this Stream stream)
        {
            return (T)new XmlSerializer(typeof(T)).Deserialize(stream);
        }
    }
}
