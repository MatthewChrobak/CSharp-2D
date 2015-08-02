namespace _2D_Multiplayer_Engine_Client.Networking {
    interface INetwork {
        void Initialize();
        void Destroy();
        void SendData(byte[] array);
    }
}
