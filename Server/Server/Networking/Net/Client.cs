using System;
using System.Net.Sockets;

namespace Server.Networking.Net
{
    public class Client
    {
        public Socket Socket;
        public byte[] Buffer;
        public bool canReceive;
        public bool Connected { private set; get; }

        public Client(Socket connection) {
            Socket = connection;
            Buffer = new byte[Socket.ReceiveBufferSize];
            Connected = true;
            canReceive = true;
        }

        public void Disconnect() {
            Console.WriteLine("Client at " + Socket.RemoteEndPoint.ToString().Remove(Socket.RemoteEndPoint.ToString().IndexOf(':')) + " disconnected.");

            Socket.Disconnect(true);
            Connected = false;
            canReceive = false;
            Buffer = null;
        }
    }
}
