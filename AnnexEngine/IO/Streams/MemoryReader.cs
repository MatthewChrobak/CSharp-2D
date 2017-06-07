using System.IO;

namespace AnnexEngine.IO.Streams
{
    /// <summary>
    /// Reads data from an underlying stream.
    /// </summary>
    public class MemoryReader : BinaryReader
    {
        /// <summary>
        /// Initializes a MemoryReader object with the given bytes loaded into the underlying stream.
        /// </summary>
        /// <param name="buffer">The bytes to be loaded into the underlying stream.</param>
        private MemoryReader(byte[] buffer) : base(new MemoryStream(buffer)) { }

        /// <summary>
        /// Creates a MemorYReader object with the given bytes loaded into the underlying stream.
        /// </summary>
        /// <param name="buffer">The bytes to be loaded into the underyling stream.</param>
        /// <returns></returns>
        public static MemoryReader LoadFromBytes(byte[] buffer)
        {
            return new MemoryReader(buffer);
        }

        /// <summary>
        /// Reads a sequence of bytes prefixed by its length from the underlying stream.
        /// </summary>
        /// <returns>The sequence of bytes read from the stream.</returns>
        public byte[] ReadBytes()
        {
            int length = this.ReadInt32();
            return this.ReadBytes(length);
        }
    }
}
