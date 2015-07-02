using System.IO;

namespace _2D_Multiplayer_Engine_Client.IO
{
    public class DataBuffer
    {
        private MemoryStream _buffer;
        private BinaryReader _reader;
        private BinaryWriter _writer;

        // Constructors that initialize the memorystream
        // and either the writer or reader.
        public DataBuffer() {
            _buffer = new MemoryStream();
            _writer = new BinaryWriter(_buffer);
        }
        public DataBuffer(string file) {
            if (!File.Exists(file)) {
                return;
            }
            _buffer = new MemoryStream(File.ReadAllBytes(file));
            _reader = new BinaryReader(_buffer);
        }
        public DataBuffer(byte[] array) {
            _buffer = new MemoryStream(array);
            _reader = new BinaryReader(_buffer);
        }

        // Manual disposing of the objects.
        public void Dispose() {
            if (_reader != null) {
                _reader.Dispose();
            }
            if (_writer != null) {
                _writer.Dispose();
            }
            if (_buffer != null) {
                _buffer.Dispose();
            }
        }

        // Methods that write to the buffer.
        public void Write(int value) {
            _writer.Write(value);
        }
        public void Write(string value) {
            _writer.Write(value);
        }
        public void Write(bool value) {
            _writer.Write(value);
        }
        public void Write(byte value) {
            _writer.Write(value);
        }
        public void Write(byte[] value) {
            _writer.Write(value.Length);
            _writer.Write(value);
        }
        public void Write(Networking.Packets value) {
            _writer.Write((int)value);
        }

        // Methods that read from the buffer.
        public int ReadInt() {
            if (_reader == null) {
                return 0;
            }
            int value = _reader.ReadInt32();
            if (_buffer.Position == _buffer.Length) {
                _reader.Dispose();
                _buffer.Dispose();
            }
            return value;
        }
        public string ReadString() {
            if (_reader == null) {
                return "";
            }
            string value = _reader.ReadString();
            if (_buffer.Position == _buffer.Length) {
                _reader.Dispose();
                _buffer.Dispose();
            }
            return value;
        }
        public bool ReadBool() {
            if (_reader == null) {
                return false;
            }
            bool value = _reader.ReadBoolean();
            if (_buffer.Position == _buffer.Length) {
                _reader.Dispose();
                _buffer.Dispose();
            }
            return value;
        }
        public byte ReadByte() {
            if (_reader == null) {
                return 0;
            }
            byte value = _reader.ReadByte();
            if (_buffer.Position == _buffer.Length) {
                _reader.Dispose();
                _buffer.Dispose();
            }
            return value;
        }
        public byte[] ReadBytes() {
            if (_reader == null) {
                return new byte[] { 0 };
            }
            int len = _reader.ReadInt32();
            byte[] value = _reader.ReadBytes(len);
            if (_buffer.Position == _buffer.Length) {
                _reader.Dispose();
                _buffer.Dispose();
            }
            return value;
        }

        // Saving gamefiles.
        public void Save(string file) {
            if (File.Exists(file)) {
                File.Delete(file);
            }
            File.WriteAllBytes(file, _buffer.ToArray());
            _writer.Dispose();
            _buffer.Dispose();
        }
        public byte[] toArray() {
            var array = _buffer.ToArray();
            return array;
        }
        public byte[] toNetworkArray() {
            int length = _buffer.ToArray().Length;

            using (MemoryStream memory = new MemoryStream()) {
                using (BinaryWriter writer = new BinaryWriter(memory)) {
                    writer.Write(length + 4);
                    writer.Write(_buffer.ToArray());
                    return memory.ToArray();
                }
            }
        }
    }
}
