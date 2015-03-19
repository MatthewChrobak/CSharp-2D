namespace Server.Networking
{
    public static class NetworkManager
    {
        private static iNetwork _network;

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

        public static void SendDataToMap(int map, byte[] array) {
            _network.SendDataToMap(map, array);
        }

        public static void SendDataToAllBut(int exception, byte[] array) {
            _network.SendDataToAllBut(exception, array);
        }

        public static void SendFile(int index, string file) {
            _network.SendFileTo(index, file);
        }
    }
}
