using System.IO;
using System.Xml.Serialization;

namespace AnnexEngine.IO.Serialization
{
    /// <summary>
    /// Provides extension methods for serializing objects to and from streams.
    /// </summary>
    public static partial class StreamSerializationExtensions
    {
        /// <summary>
        /// Serializes the given object to the given stream using the XmlSerializer.
        /// </summary>
        /// <typeparam name="T">The type of the object given.</typeparam>
        /// <param name="stream">The stream to serialize the object to.</param>
        /// <param name="instance">The object to serialize to the stream.</param>
        public static void SerializeToXML<T>(this Stream stream, T instance)
        {
            new XmlSerializer(typeof(T)).Serialize(stream, instance);
        }

        /// <summary>
        /// Deserializes an object from the given stream using the XmlSerializer.
        /// </summary>
        /// <typeparam name="T">The type of the object to deserialize.</typeparam>
        /// <param name="stream">The stream to deserialize the object from.</param>
        /// <returns>The deserialized object.</returns>
        public static T DeserializeFromXML<T>(this Stream stream)
        {
            return (T)new XmlSerializer(typeof(T)).Deserialize(stream);
        }
    }
}
