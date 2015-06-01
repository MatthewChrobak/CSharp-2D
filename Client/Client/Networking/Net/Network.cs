using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;

using Client;

namespace Networking.Net
{
    public class Network : INetwork
    {
        private byte[] _buffer;
        private Socket _client;
        private bool _connected;

        private List<byte> _fileData;
        private string _file;
        private int _fileSize;
        private bool _incomingFile;

        public void Initialize() {
            _client = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);
            _client.BeginConnect(new IPEndPoint(IPAddress.Parse(Application.Settings.IP), Application.Settings.Port), new AsyncCallback(ConnectCallBack), null);

            while (!_connected) {
                // waste time.
            }
        }
        public void Destroy() {
            _client.Disconnect(false);
        }

        private void ConnectCallBack(IAsyncResult ar) {
            try {
                _client.EndConnect(ar);
            }
            catch {
                System.Windows.Forms.MessageBox.Show("Could not connect to the server.", "Networking Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                Environment.Exit(1);
            }

            _buffer = new byte[_client.ReceiveBufferSize];
            _client.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), null);
            _connected = true;

        }
        private void ReceiveCallBack(IAsyncResult ar) {
            int length = 0;

            try {
                length = _client.EndReceive(ar);
            }
            catch {
                System.Windows.Forms.MessageBox.Show("Disconnected from the server.", "Networking Error", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                Environment.Exit(1);
            }

            Array.Resize(ref _buffer, length);
            SendCanReceive();

            if (length > 0) {
                if (_incomingFile) {

                    // Update the file stuff.
                    foreach (byte data in _buffer) {
                        _fileData.Add(data);
                    }

                    // Write the file and clear our stuff.
                    if (_fileData.Count == _fileSize) {
                        _incomingFile = false;
                        _fileSize = 0;
                        File.WriteAllBytes(Application.StartupPath + _file, _fileData.ToArray());
                        _file = "";
                        _fileData = null;
                    }

                } else {
                    using (var memory = new MemoryStream(_buffer)) {
                        using (var reader = new BinaryReader(memory)) {
                            if (reader.ReadInt32() == -1) {
                                _fileSize = reader.ReadInt32();
                                _file = reader.ReadString();
                                _fileData = new List<byte>(_fileSize);
                                _incomingFile = true;
                            } else {
                                PacketManager.HandlePacket(_buffer);
                            }
                        }
                    }
                }
            }

            Array.Resize(ref _buffer, _client.ReceiveBufferSize);
            _client.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), null);   
        }
        private void SendCallBack(IAsyncResult ar) {
            _client.EndSend(ar);
        }

        public void SendData(byte[] array) {
            _client.BeginSend(array, 0, array.Length, SocketFlags.None, new AsyncCallback(SendCallBack), null);
        }

        private void SendCanReceive() {
            using (var memory = new MemoryStream()) {
                using (var writer = new BinaryWriter(memory)) {
                    writer.Write(-1);
                    SendData(memory.ToArray());
                }
            }
        }
    }
}
