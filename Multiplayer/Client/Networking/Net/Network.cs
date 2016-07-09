using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace MultiplayerEngine_Client.Networking.Net
{
    public class Network : INetwork
    {
        // The socket to maintain the connection with the server
        // and its flag.
        private Socket _socket;
        private SocketSendFlag _sendFlag;

        // Byte arrays for storing incoming and unprocessed data.
        private byte[] _inBuffer;    // incoming
        private byte[] _unBuffer;    // unprocessed

        // Wait packet variables.
        private int _ticket;
        private int _servicing;


        public Network() {
            // Create a TCP socket and attempt to connect to the server.
            this._socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this._socket.BeginConnect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 7001), new AsyncCallback(ConnectCallback), null);

            // Hang the application until we get a response.
            while (this._socket?.Connected != true) ;
        }

        private void ConnectCallback(IAsyncResult ar) {
            // Ending an asynchronous operation might cause an error. Encase it
            // in a try/catch.
            try {
                this._socket.EndConnect(ar);
            } catch (SocketException e) {

                // Figure what caused the error.
                switch (e.SocketErrorCode) {
                    // We could not establish a connection. Destroy the client.
                    case SocketError.ConnectionRefused:
                        Environment.Exit(1);
                        break;

                    // An unknown error occured. Throw an exception.
                    default:
                        throw new Exception("ConnectCallback: Unknown SocketException '" + e.SocketErrorCode + "'");
                }
            }

            // Initialize the arrays that will store data received from the server, and 
            // flag the socket so it can send data.
            this._inBuffer = new byte[this._socket.ReceiveBufferSize];
            this._unBuffer = new byte[0];
            this._sendFlag = SocketSendFlag.CanSend;

            // Begin to receive data from the server.
            this._socket.BeginReceive(this._inBuffer, 0, this._inBuffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), null);
        }

        private void ReceiveCallback(IAsyncResult ar) {
            // Create a variable that will store the length of the incoming data.
            int length = 0;

            // Ending an asynchronous operation might cause an error. Encase it
            // in a try/catch.
            try {
                // Get the length of the incoming data.
                length = this._socket.EndReceive(ar);
            } catch (SocketException e) {

                // Figure out what caused the error.
                switch (e.SocketErrorCode) {

                    // The server has shut down. Flag the client to be closed, and
                    // do not continue to receive data.
                    case SocketError.ConnectionReset:
                        Client.SetClientFlag(ClientFlag.Closing);
                        return;

                    // An unknown error occured. Throw an exception.
                    default:
                        throw new Exception("ReceiveCallback: Unknown SocketException '" + e.SocketErrorCode + "'");
                }
            }

            // If the length of the incoming data is 0, it means that the server disconnected.
            // Flag the client to be closed.
            if (length == 0) {
                Client.SetClientFlag(ClientFlag.Closing);
                return;
            }

            // Resize the array containing the incoming bytes to its actual size.
            Array.Resize(ref this._inBuffer, length);

            // Merge both byte arrays, and store the leftovers in one of the arrays.
            this._unBuffer = NetworkManager.PacketManager.HandlePacket(MergeBuffers());

            // Resize the array back to a larger size for receiving data.
            Array.Resize(ref this._inBuffer, this._socket.ReceiveBufferSize);

            // Starting an asynchronous operation might cause an error. Encase it
            // in a try/catch.
            try {
                // Continue to receive from the server.
                this._socket.BeginReceive(this._inBuffer, 0, this._inBuffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), null);
            } catch (SocketException e) {

                // Figure out what caused the error.
                switch (e.SocketErrorCode) {

                    // The connection to the server was abruptly severed.
                    // Flag the client to be closed, and do not continue to send.
                    case SocketError.ConnectionAborted:
                        Client.SetClientFlag(ClientFlag.Closing);
                        return;
                    
                    // An unknown error occured. Throw an exception.
                    default:
                        throw new Exception("ReceiveCallback: Unknown SocketException '" + e.SocketErrorCode + "'");
                }
            }
            
        }

        private byte[] MergeBuffers() {
            // Create a new array of the size of both arrays added together.
            byte[] array = new byte[this._inBuffer.Length + this._unBuffer.Length];

            // Copy both arrays into the new array.
            Array.Copy(this._unBuffer, array, this._unBuffer.Length);
            Array.Copy(this._inBuffer, 0, array, this._unBuffer.Length, this._inBuffer.Length);

            // Return the merged arrays.
            return array;
        }

        public void Destroy() {
            // Disconnect the socket if we can.
            if (this._socket.Connected) {
                this._socket.Disconnect(false);
            }
        }

        public void SendData(byte[] array) {
            // Make sure we're connected.
            if (this._socket?.Connected != true) {
                return;
            }

            // Make sure the data we're sending isn't over the limit.
            if (array.Length > this._socket.SendBufferSize) {
                Client.Write("A packet being sent was over the allowed array size: length=" + array.Length);
                return;
            }


            // Can we send data right now?
            if (this._sendFlag != SocketSendFlag.CanSend) {

                // Create and start a new thread that will wait to send the data.
                var thread = new Thread(new ParameterizedThreadStart(SendDataWait));
                thread.Start(array);
                return;
            }

            // Starting an asynchronous operation might cause an error. Encase it
            // in a try/catch.
            try {
                // Flag the socket as sending data, and begin sending data.
                this._sendFlag = SocketSendFlag.Sending;
                this._socket.BeginSend(array, 0, array.Length, SocketFlags.None, new AsyncCallback(SendCallback), null);
            } catch (SocketException e) {

                // Figure out what caused the error.
                switch (e.SocketErrorCode) {

                    // An unknown error occured. Throw an exception.
                    default:
                        throw new Exception("SendData: Unknown SocketException '" + e.SocketErrorCode + "'");
                }
            }
        }

        private void SendDataWait(object obj) {
            // Create a ticket.
            int ticket = this._ticket++;

            // Cast the argument to an array of bytes.
            byte[] array = (byte[])obj;

            // Take note of when this method was called.
            int start = Environment.TickCount;

            // Continue to loop while we're waiting to send data, or we're not first in line.
            while (this._sendFlag != SocketSendFlag.WaitCanSend || this._servicing != ticket) ;

            // Starting an asynchronous operation might cause an error. Encase it
            // in a try/catch.
            try {
                // Flag the socket as sending data, and begin to send.
                this._sendFlag = SocketSendFlag.Sending;
                this._socket.BeginSend(array, 0, array.Length, SocketFlags.None, new AsyncCallback(SendCallback), null);
            } catch (SocketException e) {

                // Figure out what caused the error.
                switch (e.SocketErrorCode) {

                    // The connection to the server was abruptly severed.
                    // Flag the client to be closed and do not continue to send.
                    case SocketError.ConnectionAborted:
                        Client.SetClientFlag(ClientFlag.Closing);
                        return;

                    // An unknown error occured. Throw an exception.
                    default:
                        throw new Exception("SendDataWait: Unknown SocketException '" + e.SocketErrorCode + "'");
                }
            }
        }

        private void SendCallback(IAsyncResult ar) {
            // End the asynchronous operation.
            this._socket.EndSend(ar);

            // If the ticket is equal to the current ticket being served, then
            // we're either not using the waiting system or we've fully caught up.
            if (this._ticket == this._servicing) {
                // Reset the ticketing system, and flag the socket so 
                // it can begin to send data.
                this._ticket = 0;
                this._servicing = 0;
                this._sendFlag = SocketSendFlag.CanSend;
            } else {
                // Otherwise, increment the service number and
                // flag the socket to service another wait packet.
                this._sendFlag = SocketSendFlag.WaitCanSend;
                this._servicing++;
            }
        }
    }
}
