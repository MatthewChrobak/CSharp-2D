namespace MultiplayerEngine_Client.Networking
{
    public interface INetwork
    {
        void Destroy();
        void SendData(byte[] array);
    }
}
