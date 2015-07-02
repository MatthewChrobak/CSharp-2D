using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace _2D_Multiplayer_Engine_Server.Networking.Net
{
    public class Network : INetwork
    {
        private Socket _server;
        private List<Client> _client;

        public void Initialize() {
            _client = new List<Client>();
            _server = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);
            _server.Bind(new IPEndPoint(IPAddress.Any, 7001));
            _server.Listen(5);
            _server.BeginAccept(new AsyncCallback(AcceptCallBack), null);
        }
        public void Destroy() {
            for (int i = 0; i < _client.Count; i++) {
                _client[i].Disconnect();
                _client.RemoveAt(i);
            }
        }

        private void AcceptCallBack(IAsyncResult ar) {
            var connection = _server.EndAccept(ar);
            var client = new Client(connection);
            _client.Add(client);
            Program.Write("Accepted connection at " + client.Socket.RemoteEndPoint.ToString().Remove(client.Socket.RemoteEndPoint.ToString().IndexOf(':')));
            connection.BeginReceive(client.Buffer, 0, client.Buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), _client.Count - 1);

            _server.Listen(5);
            _server.BeginAccept(new AsyncCallback(AcceptCallBack), null);
        }
        private void ReceiveCallBack(IAsyncResult ar) {
            int index = (int)ar.AsyncState;
            var client = _client[index];
            int length = 0;

            try {
                length = client.Socket.EndReceive(ar);
            }
            catch {
                client.Disconnect();
            }

            Array.Resize(ref client.Buffer, length);

            if (length > 0) {
                PacketManager.HandlePacket(index, client.Buffer);
            }

            Array.Resize(ref client.Buffer, client.Socket.ReceiveBufferSize);

            if (client.Connected) {
                client.Socket.BeginReceive(client.Buffer, 0, client.Buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), index);
            }
        }
        private void SendCallBack(IAsyncResult ar) {
            int index = (int)ar.AsyncState;
            _client[index].Socket.EndSend(ar);
            _client[index].IsReceiving = false;
        }

        public void SendDataTo(int index, byte[] array) {
            var client = _client[index];

            if (!client.Connected) {
                Program.Write("Tried to send data to disconnected client " + index);
                client.Disconnect();
                return;
            }

            if (array.Length > _server.SendBufferSize) {
                Console.WriteLine("Tried to send data bigger than the buffer size at " + array.Length + " bytes at client " + index);
                return;
            }

            if (client.IsReceiving) {
                object packetObject = new object[] { index, array };
                var thread = new Thread(new ParameterizedThreadStart(SendDataWait));
                thread.Start(packetObject);
                return;
            }

            client.IsReceiving = true;
            client.Socket.BeginSend(array, 0, array.Length, SocketFlags.None, new AsyncCallback(SendCallBack), index);
        }
        private void SendDataWait(object packetObject) {
            Array packet = new object[2];
            packetObject = (Array)packetObject;
            int index = (int)packet.GetValue(0);
            byte[] array = (byte[])packet.GetValue(1);

            var client = _client[index];
            int start = Environment.TickCount;

            while (client.IsReceiving) {
                if (Environment.TickCount - start > 1000) {
                    Program.Write("Dropped a packet that was going to be sent to client " + index);
                    return;
                }
            }

            client.IsReceiving = true;
            client.Socket.BeginSend(array, 0, array.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), index);
        }

        public void SendDataToAll(byte[] array) {
            for (int i = 0; i < _client.Count; i++) {
                if (_client[i].Connected) {
                    SendDataTo(i, array);
                }
            }
        }
        public void SendDataToAllBut(int exception, byte[] array) {
            for (int i = 0; i < _client.Count; i++) {
                if (i != exception) {
                    if (_client[i].Connected) {
                        SendDataTo(i, array);
                    }
                }
            }
        }
    }
}
