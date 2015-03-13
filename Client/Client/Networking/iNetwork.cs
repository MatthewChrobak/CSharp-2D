namespace Client.Networking
{
    interface iNetwork
    {
        void Initialize();
        void Destroy();
        void SendData(byte[] array);
    }
}
