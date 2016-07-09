namespace MultiplayerEngine_Server.Networking
{
    public static class NetworkManager
    {
        // The objects containing the networking system, and the packet handling system.
        public static INetwork Network { private set; get; }
        public static PacketManager PacketManager { private set; get; }

        public static void Initialize() {
            NetworkManager.Network = new Net.Network();
            NetworkManager.PacketManager = new PacketManager();
        }

        public static void Destroy() {
            NetworkManager.Network.Destroy();
        }
    }
}
