using System;
using System.Collections.Generic;

using Client;
using IO;

namespace Networking
{
    public static class PacketManager
    {
        private delegate void HandleDataMethod(byte[] array);
        private static List<HandleDataMethod> _handleData;

        public static void Initialize() {
            // Add packet handlers in the same order as they appear
            // in the Packets enumeration in Packets.cs on the SERVER side.
            _handleData = new List<HandleDataMethod>();

            _handleData.Add(new HandleDataMethod(HandleNotification));
            _handleData.Add(new HandleDataMethod(HandleEnterGame));
            //_handleData.Add(new HandleDataMethod(HandleVerifyCache));
        }
        private static byte[] RemovePacketHead(byte[] array) {
            // If the size of the entire buffer is 4, all the packet contains is the head.
            // Packets like that are just initiation packets, and don't actually contin
            // other data. So, what we return won't be manipulated anyways. Return null.
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
        public static void HandlePacket(byte[] array) {
            var packet = new DataBuffer(array);
            int head = packet.ReadInt();
            _handleData[head].Invoke(RemovePacketHead(array));
            packet.Dispose();
        }

        #region Handling incoming packets
        private static void HandleNotification(byte[] array) {

        }
        private static void HandleEnterGame(byte[] array) {
            Application.inGame = true;
        }
        #endregion

        #region Sending outgoing packets
        public static void SendRequestLogin(string username, string password) {
            if (Application.inGame) {
                return;
            }

            var packet = new DataBuffer();
            packet.Write(Packets.SendRequestLogin);
            packet.Write(username);
            packet.Write(password);
            NetworkManager.SendData(packet.toArray());
        }
        public static void SendRequestCreate(string username, string password) {
            if (Application.inGame) {
                return;
            }

            var packet = new DataBuffer();
            packet.Write(Packets.SendRequestCreate);
            packet.Write(username);
            packet.Write(password);
            NetworkManager.SendData(packet.toArray());
        }
        public static void SendLeaveGame() {
            if (!Application.inGame) {
                return;
            }

            var packet = new DataBuffer();
            packet.Write(Packets.SendLeaveGame);
            NetworkManager.SendData(packet.toArray());

            Application.inGame = false;
        }
        #endregion
    }
}
