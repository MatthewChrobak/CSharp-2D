using System.IO;

namespace _2D_Singleplayer_Engine.IO
{
    public class DataBuffer
    {
        // Class objects used to read and write data.
        private MemoryStream _buffer;
        private BinaryReader _reader;
        private BinaryWriter _writer;

        // Constructors that, depending on the arguments,
        // initialize the memorystream and either the binarywriter or binaryreader.
        public DataBuffer() {
            // Initialize a clean memorystream and initialize the
            // writer to write to that memorystream.
            this._buffer = new MemoryStream();
            this._writer = new BinaryWriter(this._buffer);
        }
        public DataBuffer(string file) {
            // Make sure that the file actually exists.
            if (!File.Exists(file)) {
                return;
            }
            // Load the memorystream with the bytes from the file, and set
            // the reader to read from that memorystream.
            this._buffer = new MemoryStream(File.ReadAllBytes(file));
            this._reader = new BinaryReader(this._buffer);
        }
        public DataBuffer(byte[] array) {
            // Load the memorystream with the given bytes, and set
            // the reader to read from that memorystream.
            this._buffer = new MemoryStream(array);
            this._reader = new BinaryReader(this._buffer);
        }

        // A deconstructor to ensure that the class objects are
        // properly disposed of.
        ~DataBuffer() {
            this.Dispose();
        }

        // Methods used to write to memory.
        public void Write(int value) {
            // Make sure that we can actually write to memory.
            if (this._writer != null && this._writer.BaseStream.CanWrite) {
                this._writer.Write(value);
            }
        }
        public void Write(string value) {
            // Make sure that we can actually write to memory.
            if (this._writer != null && this._writer.BaseStream.CanWrite) {
                this._writer.Write(value);
            }
        }
        public void Write(bool value) {
            // Make sure that we can actually write to memory.
            if (this._writer != null && this._writer.BaseStream.CanWrite) {
                this._writer.Write(value);
            }
        }
        public void Write(byte value) {
            // Make sure that we can actually write to memory.
            if (this._writer != null && this._writer.BaseStream.CanWrite) {
                this._writer.Write(value);
            }
        }
        public void Write(byte[] value) {
            // Make sure that we can actually write to memory.
            if (this._writer != null && this._writer.BaseStream.CanWrite) {
                // Write the length to memory before the actual array
                // so when we read the data, we know how big the array is.
                this._writer.Write(value.Length);
                this._writer.Write(value);
            }
        }

        // Methods used to read from memory.
        public int ReadInt() {
            // Make sure that we can actually read from the stream.
            // If not, return a default value.
            if (this._reader == null || this._reader.BaseStream.CanRead) {
                return 0;
            }

            // Read and store the value.
            int value = this._reader.ReadInt32();

            // Check to see if we read to the end of the stream.
            // If so, dispose.
            if (this._reader.BaseStream.Position == this._reader.BaseStream.Length) {
                this.Dispose();
            }

            // Return what we stored.
            return value;
        }
        public string ReadString() {
            // Make sure that we can actually read from the stream.
            // If not, return a default value.
            if (this._reader == null || this._reader.BaseStream.CanRead) {
                return "";
            }

            // Read and store the value.
            string value = this._reader.ReadString();

            // Check to see if we read to the end of the stream.
            // If so, dispose.
            if (this._reader.BaseStream.Position == this._reader.BaseStream.Length) {
                this.Dispose();
            }

            // Return what we stored.
            return value;
        }
        public bool ReadBool() {
            // Make sure that we can actually read from the stream.
            // If not, return a default value.
            if (this._reader == null || this._reader.BaseStream.CanRead) {
                return false;
            }

            // Read and store the value.
            bool value = this._reader.ReadBoolean();

            // Check to see if we read to the end of the stream.
            // If so, dispose.
            if (this._reader.BaseStream.Position == this._reader.BaseStream.Length) {
                this.Dispose();
            }

            // Return what we stored.
            return value;
        }
        public byte ReadByte() {
            // Make sure that we can actually read from the stream.
            // If not, return a default value.
            if (this._reader == null || this._reader.BaseStream.CanRead) {
                return 0;
            }

            // Read and store the value.
            byte value = this._reader.ReadByte();

            // Check to see if we read to the end of the stream.
            // If so, dispose.
            if (this._reader.BaseStream.Position == this._reader.BaseStream.Length) {
                this.Dispose();
            }

            // Return what we stored.
            return value;
        }
        public byte[] ReadBytes() {
            // Make sure that we can actually read from the stream.
            // If not, return a default value.
            if (this._reader == null || this._reader.BaseStream.CanRead) {
                return new byte[0];
            }

            // Read the length of the upcoming byte array, and
            // read that many bytes.
            int len = this._reader.ReadInt32();
            byte[] value = this._reader.ReadBytes(len);

            // Check to see if we read to the end of the stream.
            // If so, dispose.
            if (this._reader.BaseStream.Position == this._reader.BaseStream.Length) {
                this.Dispose();
            }

            // Return what we stored.
            return value;
        }

        // Other utility methods.
        public void Save(string filepath, bool dispose = true) {

            // Check to see if a file of the same name
            // exists. If so, delete it.
            if (File.Exists(filepath)) {
                File.Delete(filepath);
            }

            // Make sure that we can read from the stream.
            if (this._buffer != null && this._buffer.CanRead) {

                // Write all the bytes in the buffer to the specified filepath.
                File.WriteAllBytes(filepath, this._buffer.ToArray());

                // Unless instructed otherwise, dispose afterwards.
                if (dispose) {
                    this.Dispose();
                }
            }
        }
        public byte[] ToArray(bool dispose = true) {

            // Make sure that we can read from the stream.
            if (this._buffer != null && this._buffer.CanRead) {

                // Store the byte array.
                var array = this._buffer.ToArray();

                // Unless instructed otherwise, dispose afterwards.
                if (dispose) {
                    this.Dispose();
                }

                // Return the array.
                return array;
            }
            // If we cannot read from the stream, return 
            // an empty byte array.
            return new byte[0];
        }
        public void Dispose() {
            // Dispose of any of the objects if they are not null.
            if (this._reader != null) {
                this._reader.Dispose();
            }
            if (this._writer != null) {
                this._writer.Dispose();
            }
            if (this._buffer != null) {
                this._buffer.Dispose();
            }
        }

    }
}
