using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace AnnexEngine.IO.Serialization
{
    public static partial class StreamSerializationExtensions
    {
        public static void SerializeToBinary<T>(this Stream stream, T instance)
        {
            new BinaryFormatter().Serialize(stream, instance);
        }

        public static T DeserializeFromBinary<T>(this Stream stream)
        {
            return (T)new BinaryFormatter().Deserialize(stream);
        }
    }
}
