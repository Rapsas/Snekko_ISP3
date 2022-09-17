namespace Snakey.Proxy;

using Microsoft.AspNetCore.SignalR.Client;
using Snakey.Config;
using Snakey.Managers;

public class ConnectionManager : IConnectionManager
{
    public MultiplayerManager MultiplayerManager { get; set; }

    public ConnectionManager()
    {
        MultiplayerManager = new($"{Settings.ServerIPAddress}/gameHub");
        GameState.Instance.MultiplayerManager = MultiplayerManager;
    }

    public async void ConnectToServer()
    {
        await MultiplayerManager.ConnectToServer();
    }

    public bool IsConnected()
    {
        return MultiplayerManager.Connection.State == HubConnectionState.Connected;
    }
}
