using System.Net.Sockets;

namespace _2D_Multiplayer_Engine_Server.Networking.Net
{
    public class Client
    {
        public Socket Socket;
        public byte[] Buffer;
        public bool IsReceiving;
        public bool Connected { private set; get; }

        public Client(Socket connection) {
            Socket = connection;
            Buffer = new byte[Socket.ReceiveBufferSize];
            Connected = true;
            IsReceiving = false;
        }

        public void Disconnect() {
            Program.Write("Client at " + Socket.RemoteEndPoint.ToString().Remove(Socket.RemoteEndPoint.ToString().IndexOf(':')) + " disconnected.");

            Socket.Disconnect(true);
            Connected = false;
            IsReceiving = false;
            Buffer = null;
        }
    }
}
