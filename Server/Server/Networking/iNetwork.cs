namespace Server.Networking
{
    interface iNetwork
    {
        void Initialize();
        void Destroy();
        void SendDataTo(int index, byte[] array);
        void SendDataToAll(byte[] array);
        void SendDataToMap(int map, byte[] array);
        void SendDataToAllBut(int exception, byte[] array);
    }
}
