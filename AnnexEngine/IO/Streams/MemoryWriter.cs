using System;
using System.IO;

namespace AnnexEngine.IO.Streams
{
    /// <summary>
    /// Writes data to an underlying stream.
    /// </summary>
    public class MemoryWriter : BinaryWriter
    {
        /// <summary>
        /// Initializes a MemoryWriter object with an empty underlying stream.
        /// </summary>
        private MemoryWriter() : base(new MemoryStream()) { }

        /// <summary>
        /// Creates a MemoryWriter object with an empty underlying stream.
        /// </summary>
        /// <returns>The created MemoryWriter object.</returns>
        public static MemoryWriter Create()
        {
            return new MemoryWriter();
        }

        /// <summary>
        /// Writes a byte array to the underlying stream prefixed by its length.
        /// </summary>
        /// <param name="buffer">A byte array containing the data to write.</param>
        public override void Write(byte[] buffer)
        {
            this.Write(buffer.Length);
            base.Write(buffer);
        }

        /// <summary>
        /// Returns the data in the underlying stream as a byte array.
        /// </summary>
        /// <returns>The array of bytes in the underlying stream.</returns>
        public byte[] ToArray()
        {
            // This class is designed to work with the System.IO.MemoryStream class.
            // If the MemoryWriter uses a different underlying stream, it is uncertain whether
            // the ToArray() method will exist.
            // If the underlying stream is not a memorystream, throw an exception.
            var stream = this.BaseStream as MemoryStream;

            if (stream == null) {
                throw new NoUnderlyingMemoryStream("The underlying stream is not a MemoryStream.");
            }
            
            // Otherwise, return the contents of the memorystream in a byte array.
            return stream.ToArray();
        }
    }

    /// <summary>
    /// Represents an error that occurs when a System.IO.MemoryStream is required as an underlying stream.
    /// </summary>
    public class NoUnderlyingMemoryStream : Exception
    {
        /// <summary>
        /// Initializes the exception object with the specified message.
        /// </summary>
        /// <param name="message">The error message to be displayed.</param>
        public NoUnderlyingMemoryStream(string message) : base(message) { }

        /// <summary>
        /// Initializes the exception object.
        /// </summary>
        public NoUnderlyingMemoryStream() : base() { }
    }
}
