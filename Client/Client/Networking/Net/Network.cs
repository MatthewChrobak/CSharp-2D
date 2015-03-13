using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Client.Networking.Net
{
    public class Network : iNetwork
    {
        private byte[] _buffer;
        private Socket _client;
        private bool _connected;

        public void Initialize() {
            _client = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);
            _client.BeginConnect(new IPEndPoint(IPAddress.Parse(Client.Settings.IP), Client.Settings.Port), new AsyncCallback(ConnectCallBack), null);

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
            PacketManager.HandlePacket(_buffer);
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
