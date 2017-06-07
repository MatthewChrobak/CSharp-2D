using System.IO;

namespace AnnexEngine.IO.Serialization
{
    public interface ISerializationProvider
    {
        object Deserialize(Stream stream);
        void Serialize(Stream stream, object o);
    }
}
