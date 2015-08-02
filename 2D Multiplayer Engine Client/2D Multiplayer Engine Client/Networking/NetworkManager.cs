namespace _2D_Multiplayer_Engine_Client.Networking {
    public static class NetworkManager {
        private static INetwork _network;

        public static void Initialize() {
            PacketManager.Initialize();
            _network = new Networking.Net.Network();
            _network.Initialize();
        }

        public static void SendData(byte[] array) {
            _network.SendData(array);
        }

        public static void Destroy() {
            _network.Destroy();
        }
    }
}
