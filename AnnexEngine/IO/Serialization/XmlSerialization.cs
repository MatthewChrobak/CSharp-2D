using System;
using System.IO;

namespace AnnexEngine.IO.Serialization
{
    public class XmlSerializer : ISerializationProvider
    {
        private System.Xml.Serialization.XmlSerializer _xml;

        public XmlSerializer(Type type)
        {
            this._xml = new System.Xml.Serialization.XmlSerializer(type);
        }

        public object Deserialize(Stream stream)
        {
            return this._xml.Deserialize(stream);
        }

        public void Serialize(Stream stream, object o)
        {
            this._xml.Serialize(stream, o);
        }
    }

    public static partial class StreamSerializationExtensions
    {
        public static void SerializeToXML<T>(this Stream stream, Type type, T instance)
        {
            new XmlSerializer(type).Serialize(stream, instance);
        }

        public static T DeserializeFromXML<T>(this Stream stream, Type type)
        {
            return (T)new XmlSerializer(type).Deserialize(stream);
        }
    }
}
