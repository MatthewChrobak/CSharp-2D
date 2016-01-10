using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;

namespace Server.Networking.Net
{
    public class Network : INetwork
    {
        // The socket to listen for new incoming connections.
        private Socket _server;

        // The list of clients connected to the server.
        private List<Client> _client;


        public Network() {
            // Initialize the list of clients.
            this._client = new List<Client>();

            // Create a TCP socket and bind it to a port.
            this._server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            this._server.Bind(new IPEndPoint(IPAddress.Any, 7001));

            // Allow up to five pending incoming connections.
            this._server.Listen(5);

            // Begin accepting connections.
            this._server.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        private void AcceptCallback(IAsyncResult ar) {
            // Add a new client with the accepted connection.
            this.AddConnection(this._server.EndAccept(ar));

            // Continue to accept connections.
            this._server.Listen(5);
            this._server.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        public void Destroy() {
            // Disconnect every client in the collection.
            foreach (var client in this._client) {
                client.Disconnect();
            }
            // Clear the list.
            this._client.Clear();
        }

        public void SendDataTo(int index, byte[] array) {
            // Make sure that the index provided is a valid client index.
            if (index >= 0 && index < this._client.Count) {
                this._client[index].SendData(array); 
            } else {
                // Otherwise, display an error message.
                Server.Write("NetworkError: Tried to send data to non-existant client: " + index);
            }
        }

        public void SendDataToAll(byte[] array) {
            // Send the given data to every client in the collection.
            foreach (var client in this._client) {
                client.SendData(array);
            }
        }

        public void AddConnection(Socket connection) {
            // Look through our collection for a free slot.
            for (int i = 0; i < this._client.Count; i++) {
                if (!this._client[i].Connected) {
                    // If there is a free slot, create a new client at that position.
                    this._client[i] = new Client(connection, i);
                    return;
                }
            }

            // If an unused spot could not be found, add a new entry in the collection.
            this._client.Add(new Client(connection, this._client.Count));
        }
    }
}
