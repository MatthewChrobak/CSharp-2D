using _2D_Multiplayer_Engine_Server.IO;
using System;
using System.Collections.Generic;

namespace _2D_Multiplayer_Engine_Server.Networking {
    public class PacketManager {
        private delegate void HandleData(int index, byte[] array);
        private static List<HandleData> _handleData;

        public static void Initialize() {
            // Add packet handlers in the same order as they appear
            // in the Packets enumeration in Packets.cs on the CLIENT side.
            _handleData = new List<HandleData>();
        }

        private static byte[] RemovePacketHead(byte[] array) {
            // If the size of the entire buffer is 8, all the packet contains is the head.
            // Packets like that are just initiation packets, and don't actually contain
            // any other data. What we return won't be manipulated anyways. Return null.
            if (array.Length == 8) {
                return null;
            }

            // Create a new array to hold the clipped data.
            byte[] clippedArray = new byte[array.Length - 8];

            // Clip the data.
            for (int i = 8; i < array.Length; i++) {
                clippedArray[i - 8] = array[i];
            }

            // Return it.
            return clippedArray;
        }

        public static void HandlePacket(int index, byte[] array) {
            bool process = true;
            var packet = new DataBuffer(array);

            while (process) {
                int size = packet.ReadInt();
                byte[] packetbuffer = packet.toArray();

                if (packetbuffer.Length > size) {
                    byte[] excessbuffer = new byte[packetbuffer.Length - size];
                    Array.ConstrainedCopy(packetbuffer, size, excessbuffer, 0, packetbuffer.Length - size);
                    Array.Resize(ref packetbuffer, size);

                    int head = packet.ReadInt();
                    if (head >= 0 && head < _handleData.Count) {
                        _handleData[head].Invoke(index, RemovePacketHead(packetbuffer));
                    }

                    packet = new DataBuffer(excessbuffer);
                } else {
                    int head = packet.ReadInt();
                    process = false;
                    if (head >= 0 && head < _handleData.Count) {
                        _handleData[head].Invoke(index, RemovePacketHead(packetbuffer));
                    }
                }
            }

            packet.Dispose();
        }

        #region Handling incoming packets

        #endregion

        #region Sending outgoing packets

        #endregion
    }
}
