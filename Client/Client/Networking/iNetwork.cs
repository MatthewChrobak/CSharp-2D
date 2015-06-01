namespace Networking
{
    interface INetwork
    {
        void Initialize();
        void Destroy();
        void SendData(byte[] array);
    }
}
