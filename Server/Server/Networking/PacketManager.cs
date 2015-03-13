using System;
using System.Collections.Generic;

using Server.IO;
using Server.Data;

namespace Server.Networking
{
    public static class PacketManager
    {
        private delegate void HandleData(int index, byte[] array);
        private static List<HandleData> _handleData;

        public static void Initialize() {
            // Add packet handlers in the same order as they appear
            // in the Packets enumeration in Packets.cs on the CLIENT side.
            _handleData = new List<HandleData>();

            _handleData.Add(new HandleData(HandleRequestCreate));
            _handleData.Add(new HandleData(HandleRequestLogin));
            _handleData.Add(new HandleData(HandleLeaveGame));
        }

        private static byte[] RemovePacketHead(byte[] array) {
            // If the size of the entire buffer is 4, all the packet contains is the head.
            // Packets like that are just initiation packets, and don't actually contain
            // any other data. What we return won't be manipulated anyways. Return null.
            if (array.Length == 4) {
                return null;
            }

            // Create a new array to hold the clipped data.
            byte[] clippedArray = new byte[array.Length - 4];

            // Clip the data.
            for (int i = 4; i < array.Length; i++) {
                clippedArray[i - 4] = array[i];
            }

            // Return it.
            return clippedArray;
        }

        public static void HandlePacket(int index, byte[] array) {
            var packet = new DataBuffer(array);
            int head = packet.ReadInt();
            _handleData[head].Invoke(index, RemovePacketHead(array));
            packet.Dispose();
        }

        #region Handling incoming packets
        private static void HandleRequestCreate(int index, byte[] array) {
            var packet = new DataBuffer(array);
            var player = DataManager.Player[index];

            string username = packet.ReadString();
            string password = packet.ReadString();
            packet.Dispose();

            if (player.Create(username, password)) {
                SendEnterGame(index);
            }
        }
        private static void HandleRequestLogin(int index, byte[] array) {
            var packet = new DataBuffer(array);
            var player = DataManager.Player[index];

            string username = packet.ReadString();
            string password = packet.ReadString();
            packet.Dispose();

            if (player.Login(username, password)) {
                SendEnterGame(index);
            }
        }
        private static void HandleLeaveGame(int index, byte[] array) {

        }
        #endregion

        #region Sending outgoing packets
        public static void SendEnterGame(int index) {
            var packet = new DataBuffer();
            packet.Write(Packets.SendEnterGame);
            NetworkManager.SendDataTo(index, packet.toArray());
        }
        public static void SendNotification(int index, string notification) {
            var packet = new DataBuffer();
            packet.Write(Packets.SendNotification);
            packet.Write(notification);
            NetworkManager.SendDataTo(index, packet.toArray());
        }
        #endregion
    }
}
