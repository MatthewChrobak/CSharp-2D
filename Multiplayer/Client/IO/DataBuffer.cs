using System.IO;

namespace Client.IO
{
    public class DataBuffer
    {
        // Class objects used to read and write data.
        private MemoryStream _buffer;
        private BinaryReader _reader;
        private BinaryWriter _writer;


        // Constructors that, depending on the arguments,
        // initialize the memory and either the binarywriter or binaryreader.
        public DataBuffer() {
            // Initialize a clean memorystream and initialize the 
            // writer to write to that memorystream.
            this._buffer = new MemoryStream();
            this._writer = new BinaryWriter(this._buffer);
        }

        public DataBuffer(string file) {
            // Make sure that the file actually exists.
            if (!File.Exists(file)) {
                throw new FileNotFoundException("DataBuffer: " + file);
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

        // A deconstructor to ensure that the class objects
        // are properly disposed of.
        ~DataBuffer() {
            this.Dispose();
        }

        private void Dispose() {
            // Dispose of any of the objects if they are not null.
            this._reader?.Dispose();
            this._writer?.Dispose();
            this._buffer?.Dispose();
        }

        #region Methods used to write to memory.
        public void Write(string value) {
            // Make sure that we can actually write to memory.
            if (this._writer?.BaseStream?.CanWrite == true) {
                this._writer.Write(value);
            }
        }

        public void Write(char value) {
            // Make sure that we can actually write to memory.
            if (this._writer?.BaseStream?.CanWrite == true) {
                this._writer.Write(value);
            }
        }

        public void Write(bool value) {
            // Make sure that we can actually write to memory.
            if (this._writer?.BaseStream?.CanWrite == true) {
                this._writer.Write(value);
            }
        }

        public void Write(byte value) {
            // Make sure that we can actually write to memory.
            if (this._writer?.BaseStream?.CanWrite == true) {
                this._writer.Write(value);
            }
        }

        public void Write(short value) {
            // Make sure that we can actually write to memory.
            if (this._writer?.BaseStream?.CanWrite == true) {
                this._writer.Write(value);
            }
        }

        public void Write(int value) {
            // Make sure that we can actually write to memory.
            if (this._writer?.BaseStream?.CanWrite == true) {
                this._writer.Write(value);
            }
        }

        public void Write(long value) {
            // Make sure that we can actually write to memory.
            if (this._writer?.BaseStream?.CanWrite == true) {
                this._writer.Write(value);
            }
        }

        public void Write(byte[] value) {
            // Make sure that we can actually write to memory.
            if (this._writer?.BaseStream?.CanWrite == true) {
                // Write the length to memory before the actual array
                // so when we read the data, we know how big the array is.
                this._writer.Write(value.Length);
                this._writer.Write(value);
            }
        }

        public void Write(float value) {
            // Make sure that we can actually write to memory.
            if (this._writer?.BaseStream?.CanWrite == true) {
                this._writer.Write(value);
            }
        }

        public void Write(double value) {
            // Make sure that we can actually write to memory.
            if (this._writer?.BaseStream?.CanWrite == true) {
                this._writer.Write(value);
            }
        }

        public void Write(Networking.Packet value) {
            // Make sure that we can actually write to memory.
            if (this._writer?.BaseStream?.CanWrite == true) {
                this._writer.Write((int)value);
            }
        }
        #endregion

        #region Methods used to read from memory.
        public string ReadString() {
            // Make sure we can actually read from the stream.
            // If not, return a default value.
            if (this._reader?.BaseStream?.CanRead == true) {
                
                // Read and store the value.
                string value = this._reader.ReadString();

                // Check to see if we read to the end of the stream.
                // If so, dispose.
                if (this._reader.BaseStream.Position == this._reader.BaseStream.Length) {
                    this.Dispose();
                }

                // Return what we stored.
                return value;
            } else {
                return "";
            }
        }

        public char ReadChar() {
            // Make sure we can actually read from the stream.
            // If not, return a default value.
            if (this._reader?.BaseStream?.CanRead == true) {

                // Read and store the value.
                char value = this._reader.ReadChar();

                // Check to see if we read to the end of the stream.
                // If so, dispose.
                if (this._reader.BaseStream.Position == this._reader.BaseStream.Length) {
                    this.Dispose();
                }

                // Return what we stored.
                return value;
            } else {
                return ' ';
            }
        }

        public bool ReadBool() {
            // Make sure we can actually read from the stream.
            // If not, return a default value.
            if (this._reader?.BaseStream?.CanRead == true) {

                // Read and store the value.
                bool value = this._reader.ReadBoolean();

                // Check to see if we read to the end of the stream.
                // If so, dispose.
                if (this._reader.BaseStream.Position == this._reader.BaseStream.Length) {
                    this.Dispose();
                }

                // Return what we stored.
                return value;
            } else {
                return false;
            }
        }

        public byte ReadByte() {
            // Make sure we can actually read from the stream.
            // If not, return a default value.
            if (this._reader?.BaseStream?.CanRead == true) {

                // Read and store the value.
                byte value = this._reader.ReadByte();

                // Check to see if we read to the end of the stream.
                // If so, dispose.
                if (this._reader.BaseStream.Position == this._reader.BaseStream.Length) {
                    this.Dispose();
                }

                // Return what we stored.
                return value;
            } else {
                return 0;
            }
        }

        public short ReadShort() {
            // Make sure we can actually read from the stream.
            // If not, return a default value.
            if (this._reader?.BaseStream?.CanRead == true) {

                // Read and store the value.
                short value = this._reader.ReadInt16();

                // Check to see if we read to the end of the stream.
                // If so, dispose.
                if (this._reader.BaseStream.Position == this._reader.BaseStream.Length) {
                    this.Dispose();
                }

                // Return what we stored.
                return value;
            } else {
                return 0;
            }
        }

        public int ReadInt() {
            // Make sure we can actually read from the stream.
            // If not, return a default value.
            if (this._reader?.BaseStream?.CanRead == true) {

                // Read and store the value.
                int value = this._reader.ReadInt32();

                // Check to see if we read to the end of the stream.
                // If so, dispose.
                if (this._reader.BaseStream.Position == this._reader.BaseStream.Length) {
                    this.Dispose();
                }

                // Return what we stored.
                return value;
            } else {
                return 0;
            }
        }

        public long ReadLong() {
            // Make sure we can actually read from the stream.
            // If not, return a default value.
            if (this._reader?.BaseStream?.CanRead == true) {

                // Read and store the value.
                long value = this._reader.ReadInt64();

                // Check to see if we read to the end of the stream.
                // If so, dispose.
                if (this._reader.BaseStream.Position == this._reader.BaseStream.Length) {
                    this.Dispose();
                }

                // Return what we stored.
                return value;
            } else {
                return 0;
            }
        }
        public float ReadFloat() {
            // Make sure we can actually read from the stream.
            // If not, return a default value.
            if (this._reader?.BaseStream?.CanRead == true) {

                // Read and store the value.
                float value = this._reader.ReadSingle();

                // Check to see if we read to the end of the stream.
                // If so, dispose.
                if (this._reader.BaseStream.Position == this._reader.BaseStream.Length) {
                    this.Dispose();
                }

                // Return what we stored.
                return value;
            } else {
                return 0;
            }
        }
        public double ReadDouble() {
            // Make sure we can actually read from the stream.
            // If not, return a default value.
            if (this._reader?.BaseStream?.CanRead == true) {

                // Read and store the value.
                double value = this._reader.ReadDouble();

                // Check to see if we read to the end of the stream.
                // If so, dispose.
                if (this._reader.BaseStream.Position == this._reader.BaseStream.Length) {
                    this.Dispose();
                }

                // Return what we stored.
                return value;
            } else {
                return 0;
            }
        }

        public byte[] ReadBytes() {
            // Make sure we can actually read from the stream.
            // If not, return a default value.
            if (this._reader?.BaseStream?.CanRead == true) {

                // Read the length of the upcoming byte array, and
                // read that many bytes.
                int length = this.ReadInt();
                byte[] value = this._reader.ReadBytes(length);

                // Check to see if we read to the end of the stream.
                // If so, dispose.
                if (this._reader.BaseStream.Position == this._reader.BaseStream.Length) {
                    this.Dispose();
                }

                // Return what we stored.
                return value;
            } else {
                return new byte[0];
            }
        }
        #endregion

        #region Utility Methods.
        public void Save(string filepath, bool dispose = true) {

            // Make sure we have something to save.
            if (this?._buffer?.CanRead == true) {
                // Make sure no file of the same name exists.
                if (File.Exists(filepath)) {
                    File.Delete(filepath);
                }

                // Write all the bytes in the buffer to the specified filepath.
                File.WriteAllBytes(filepath, this.ToArray(dispose));
            }
        }
        
        public byte[] ToArray(bool dispose = true) {
            // Make sure that we can read from the stream.
            if (this?._buffer?.CanRead == true) {
                // Store the byte array.
                byte[] array = this._buffer.ToArray();

                // Unless instructed otherwise, dispose.
                if (dispose) {
                    this.Dispose();
                }
                
                // Return the array.
                return array;
            } else {
                // If we cannot read from the stream, return
                // an empty byte array.
                return new byte[0];
            }
        }

        public byte[] ToPaddedArray() {
            int length = this._buffer.ToArray().Length;

            using (var memory = new MemoryStream()) {
                using (var writer = new BinaryWriter(memory)) {
                    writer.Write(length + 4);
                    writer.Write(this._buffer.ToArray());
                    this.Dispose();
                    return memory.ToArray();
                }
            }
        }
        #endregion
    }
}
