using Server.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading;

namespace Server.Networking.Net
{
    public class Client
    {
        // The socket to maintain the connection with the client, its flag, and
        // a boolean variable for the server to dictate whether or not the 
        // socket is connected.
        private Socket _socket;
        private SocketSendFlag _sendFlag;
        public bool Connected { private set; get; }

        // Byte arrays for storing incoming and unprocessed data.
        private byte[] _inBuffer;   // incoming
        private byte[] _unBuffer;   // unprocessed

        // Wait packet variables.
        private int _ticket;
        private int _servicing;

        public Client(Socket connection, int index) {
            // Store the socket connection for later use.
            this._socket = connection;

            // Initialize the arrays that will store data received from the client, and 
            // flag the socket so it can send data.
            this._inBuffer = new byte[_socket.ReceiveBufferSize];
            this._unBuffer = new byte[0];
            this._sendFlag = SocketSendFlag.CanSend;
            this.Connected = true;

            // Write a message to the console that we accepted a new connection.
            Server.Write("Accepted a connection at " + this.GetAddress());

            // Begin to receive data from the client.
            this._socket.BeginReceive(this._inBuffer, 0, this._inBuffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), index);
        }

        private void ReceiveCallback(IAsyncResult ar) {
            // Get the index of the client.
            int index = (int)ar.AsyncState;

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

                    // Connection with the client was abruptly severed.
                    // Disconnect the client.
                    case SocketError.ConnectionReset:
                        this.Disconnect();
                        return;

                    // An unknown error occured. Throw an exception.
                    default:
                        throw new Exception("ReceiveCallback: Unknown SocketException '" + e.SocketErrorCode + "'");
                }
            }

            // If the length of the incoming data is 0, it means that the client disconnected.
            if (length == 0) {
                this.Disconnect();
                return;
            }

            // Resize the array containing the incoming bytes to its actual size.
            Array.Resize(ref this._inBuffer, length);

            // Merge both byte arrays, and store the leftovers in one of the arrays.
            this._unBuffer = NetworkManager.PacketManager.HandlePacket(index, this.MergeBuffers());

            // Resize the array back to a larger size for receiving data.
            Array.Resize(ref this._inBuffer, this._socket.ReceiveBufferSize);

            // Starting an asynchronous operation might cause an error. Encase it
            // in a try/catch.
            try {
                // Continue to receive from the client.
                this._socket.BeginReceive(this._inBuffer, 0, this._inBuffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), index);
            } catch (SocketException e) {

                // Figure out what caused the error.
                switch (e.SocketErrorCode) {

                    // An unknown error occured. Throw an exception.
                    default:
                        throw new Exception("ReceiveCallback: Unknown SocketException '" + e.SocketErrorCode + "'");
                }
            }
        }

        public void SendData(byte[] array) {
            // Make sure that the socket is connected.
            if (this._socket?.Connected != true) {
                Server.Write("Tried to send data to disconnected client at " + this.GetAddress());
                return;
            }

            // Make sure the data we're sending isn't over the limit.
            if (array.Length > this._socket.SendBufferSize) {
                Server.Write("Tried to send data bigger than the buffer size at " + array.Length + " bytes at client " + this.GetAddress());
                return;
            }

            // Can we send data right now?
            if (this._sendFlag != SocketSendFlag.CanSend) {

                // Create and start a new thread that will wait to send the data.
                object packetObject = array;
                var thread = new Thread(new ParameterizedThreadStart(SendDataWait));
                thread.Start(packetObject);
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

        private void SendDataWait(object obj) {
            // Create a ticket
            int ticket = this._ticket++;

            // Cast the argument to an array of bytes.
            byte[] array = (byte[])obj;

            // Take note of when this method was called.
            int start = Environment.TickCount;

            // Continue to loop while we're waiting to send this data, or we're not first in line.
            while (this._sendFlag != SocketSendFlag.WaitCanSend || this._servicing != ticket) ;

            // Starting an asynchronous operation might cause an error. Encase it
            // in a try/catch.
            try {
                // Flag the socket as sending data, and begin to send.
                this._sendFlag = SocketSendFlag.Sending;
                this._socket.BeginSend(array, 0, array.Length, SocketFlags.None, new AsyncCallback(SendCallback), null);
            } catch (SocketException e) {

                // Figure out what cause the error.
                switch (e.SocketErrorCode) {

                    // The connection to the client was abruptly severed.
                    // Disconnect the client.
                    case SocketError.ConnectionAborted:
                        this.Disconnect();
                        return;

                    // An unknown error occured. Throw an exception.
                    default:
                        throw new Exception("SendDataWait: Unknown SocketException '" + e.SocketErrorCode + "'");
                }
            }
        }

        public void Disconnect() {
            // Make sure we aren't already disconnected.
            if (!this.Connected) {
                return;
            }

            // Let the server know a user disconnected.
            Server.Write("Disconnected user at " + this.GetAddress());

            // Disconnecting a socket might throw an error if the socket is
            // already disconnected.
            try {
                this._socket.Disconnect(false);
            } catch { }

            // Set the buffers to null, and mark this client
            // as not conencted.
            this._inBuffer = null;
            this._unBuffer = null;
            this.Connected = false;
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

        private string GetAddress() {
            string endpoint = this._socket.RemoteEndPoint.ToString();
            return endpoint.Remove(endpoint.IndexOf(':'));
        }
    }
}
