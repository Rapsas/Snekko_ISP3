namespace Snakey.Proxy
{
    public interface IConnectionManager
    {
        bool IsConnected();
        void ConnectToServer();
    }
}
