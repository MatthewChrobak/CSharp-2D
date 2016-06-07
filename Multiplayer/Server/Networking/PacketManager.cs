using Server.IO;
using System;
using System.Collections.Generic;

namespace Server.Networking
{
    public class PacketManager
    {
        public Dictionary<int, Action<int, byte[]>> PacketHandlers { get; private set; }

        public PacketManager() {
            // Create the array of data handlers.
            PacketHandlers = new Dictionary<int, Action<int, byte[]>>();

            // Add all packet handlers at the bottom.
        }

        private void AddPacket(Action<int, byte[]> packet) {
            this.PacketHandlers.Add(PacketHandlers.Keys.Count, packet);
        }

        private byte[] RemovePacketHead(byte[] array) {
            // If the size of the entire buffer is 8, all the packet contains is the head and size.
            // Packets like that are just initiation packets, and don't actually contain
            // other data. So, what we return won't be manipulated anyways. Return null.
            if (array.Length == 8) {
                return null;
            }

            // Create a new array of the size desired.
            byte[] clippedArray = new byte[array.Length - 8];

            // Copy the offset bytes into the clipped array.
            Array.Copy(array, 8, clippedArray, 0, array.Length - 8);

            // Return the clipped array.
            return clippedArray;
        }

        public byte[] HandlePacket(int index, byte[] array) {
            // Push the bytes into a new databuffer object.
            var packet = new DataBuffer(array);
            bool process = true;

            // Continue to loop while there's still data to process.
            while (process) {
                // Get the size of the next packet.
                int size = packet.ReadInt();

                // Do we have more than all the data need for the packet?
                if (array.Length > size) {
                    
                    // Resize the array containing the bytes needed for this packet, and
                    // create a new array containing the excess.
                    byte[] excessbuffer = new byte[array.Length - size];
                    Array.ConstrainedCopy(array, size, excessbuffer, 0, array.Length - size);
                    Array.Resize(ref array, size);

                    // Read the packet head, validate its contents, and invoke its data handler.
                    int head = packet.ReadInt();
                    if (PacketHandlers.ContainsKey(head)) {
                        PacketHandlers[head].Invoke(index, RemovePacketHead(array));
                    }

                    // Re-create the databuffer object with just the excess bytes, and 
                    // continue to loop.
                    packet = new DataBuffer(excessbuffer);

                    // Do we have all the data needed for the packet?
                } else if (array.Length == size) {

                    // Read the packet head, validate its contents, and invoke its data handler.
                    int head = packet.ReadInt();
                    if (PacketHandlers.ContainsKey(head)) {
                        PacketHandlers[head].Invoke(index, RemovePacketHead(array));
                    }

                    // Return an empty array.
                    return new byte[0];
                } else {
                    // Display a message if something goes wrong.
                    if (size > 8192) {
                        Server.Write("Absurd packet size expected: " + size);
                        return new byte[0];
                    }

                    // We have less data than we need. There's nothing to process yet.
                    process = false;
                }
            }

            // Return the unprocessed bytes.
            return packet.ToArray();
        }

        #region Handling incoming packets

        #endregion

        #region Sending outgoing packets

        #endregion
    }
}
