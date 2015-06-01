using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;

namespace Server.Networking.Net
{
    public class Network : iNetwork
    {
        private Socket _server;
        private List<Client> _client;

        public void Initialize() {
            _client = new List<Client>();
            _server = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);
            _server.Bind(new IPEndPoint(IPAddress.Any, Server.Settings.Port));
            _server.Listen(5);
            _server.BeginAccept(new AsyncCallback(AcceptCallBack), null);
        }
        public void Destroy() {
            foreach (var client in _client) {
                client.Disconnect();
            }
        }

        private void AcceptCallBack(IAsyncResult ar) {
            var connection = _server.EndAccept(ar);
            var client = new Client(connection);
            _client.Add(client);
            Console.WriteLine("Accepted connection at " + client.Socket.RemoteEndPoint.ToString().Remove(client.Socket.RemoteEndPoint.ToString().IndexOf(':')));
            connection.BeginReceive(client.Buffer, 0, client.Buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), _client.Count - 1);
            Data.DataManager.Player.Add(new Data.Models.Players.Player());

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
                using (var memory = new MemoryStream(client.Buffer)) {
                    using (var reader = new BinaryReader(memory)) {
                        if (reader.ReadInt32() == -1) {
                            client.canReceive = true;
                        } else {
                            PacketManager.HandlePacket(index, client.Buffer);
                        }
                    }
                }
            }

            Array.Resize(ref client.Buffer, client.Socket.ReceiveBufferSize);

            if (client.Connected) {
                client.Socket.BeginReceive(client.Buffer, 0, client.Buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallBack), index);
            }
        }
        private void SendCallBack(IAsyncResult ar) {
            int index = (int)ar.AsyncState;
            _client[index].Socket.EndSend(ar);
        }
        private void SendFileCallBack(IAsyncResult ar) {
            int index = (int)ar.AsyncState;
            _client[index].Socket.EndSendFile(ar);
        }

        public void SendDataTo(int index, byte[] array) {
            var client = _client[index];

            if (!client.Connected) {
                Console.WriteLine("Tried to send data to disconnected client " + index);
                client.Disconnect();
                return;
            }

            if (array.Length > _server.SendBufferSize) {
                Console.WriteLine("Tried to send data bigger than the buffer size at " + array.Length + " bytes at client " + index);
                return;
            }

            if (!client.canReceive) {
                object packetObject = new object[] { index, array };
                var thread = new Thread(new ParameterizedThreadStart(SendDataWait));
                thread.Start(packetObject);
                return;
            }

            client.Socket.BeginSend(array, 0, array.Length, SocketFlags.None, new AsyncCallback(SendCallBack), index);
            client.canReceive = false;
        }
        private void SendDataWait(object packetObject) {
            Array packet = new object[2];
            packet = (Array)packetObject;
            int index = (int)packet.GetValue(0);
            byte[] array = (byte[])packet.GetValue(1);

            var client = _client[index];

            int start = Environment.TickCount;

            while (!client.canReceive) {
                if (Environment.TickCount - start > 1000) {
                    Console.WriteLine("Dropped a packet that was going to be sent to client " + index);
                    return;
                }
            }
            client.Socket.BeginSend(array, 0, array.Length, SocketFlags.None, new AsyncCallback(SendCallBack), index);
            client.canReceive = false;
        }

        public void SendFileTo(int index, string file) {
            var client = _client[index];

            if (!client.Connected) {
                Console.WriteLine("Tried to send data to disconnected client " + index);
                client.Disconnect();
                return;
            }

            if (!File.Exists(file)) {
                Console.WriteLine("Tried to send " + file + " which does not exist to " + index);
                return;
            }

            if (!client.canReceive) {
                object packetObject = new object[] { index, file };
                var thread = new Thread(new ParameterizedThreadStart(SendFileWait));
                thread.Start(packetObject);
                return;
            }

            byte[] array = File.ReadAllBytes(file);

            using (var memory = new MemoryStream()) {
                using (var writer = new BinaryWriter(memory)) {
                    writer.Write(-1);
                    writer.Write(array.Length);
                    writer.Write(file.Remove(0, Server.StartupPath.Length));
                    SendDataTo(index, memory.ToArray());
                }
            }

            client.Socket.BeginSendFile(file, new AsyncCallback(SendFileCallBack), index);
            client.canReceive = false;
        }
        private void SendFileWait(object packetObject) {
            Array packet = new object[2];
            packet = (Array)packetObject;
            int index = (int)packet.GetValue(0);
            string file = (string)packet.GetValue(1);

            var client = _client[index];

            int start = Environment.TickCount;

            while (!client.canReceive) {
                if (Environment.TickCount - start > 1000) {
                    Console.WriteLine("Dropped a file packet that was going to be sent to client " + index);
                    return;
                }
            }

            byte[] array = File.ReadAllBytes(file);

            using (var memory = new MemoryStream()) {
                using (var writer = new BinaryWriter(memory)) {
                    writer.Write(-1);
                    writer.Write(array.Length);
                    writer.Write(file.Remove(0, Server.StartupPath.Length));
                    SendDataTo(index, memory.ToArray());
                }
            }

            client.Socket.BeginSendFile(file, new AsyncCallback(SendFileCallBack), index);
            client.canReceive = false;
        }

        public void SendDataToMap(int map, byte[] array) {

        }
        public void SendDataToAll(byte[] array) {

        }
        public void SendDataToAllBut(int exception, byte[] array) {

        }
    }
}
