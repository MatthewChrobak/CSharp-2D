namespace _2D_Multiplayer_Engine_Server.Networking {
    public class NetworkManager {
        private static INetwork _network;

        public static void Initialize() {
            PacketManager.Initialize();
            _network = new Networking.Net.Network();
            _network.Initialize();
        }

        public static void SendDataTo(int index, byte[] array) {
            _network.SendDataTo(index, array);
        }

        public static void SendDataToAll(byte[] array) {
            _network.SendDataToAll(array);
        }

        public static void SendDataToAllBut(int exception, byte[] array) {
            _network.SendDataToAllBut(exception, array);
        }
    }
}
