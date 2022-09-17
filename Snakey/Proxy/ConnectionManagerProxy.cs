namespace Snakey.Proxy;

using Snakey.Chain_of_Responsibility;
using Snakey.Managers;
using System;

public class ConnectionManagerProxy : IConnectionManager
{
    private ConnectionManager _connectionManager;
    private GameState _gameState;
    private MainWindow _window;

    public ConnectionManagerProxy(ConnectionManager connectionManager, MainWindow window)
    {
        _connectionManager = connectionManager;
        _window = window;
        _gameState = GameState.Instance;
    }

    public void ConnectToServer()
    {
        try
        {
            _gameState.Logger.Log(MessageType.Network, "Connecting to server");
            _connectionManager.ConnectToServer();
            _gameState.Logger.Log(MessageType.Network, "Connected to server");
        }
        catch (Exception)
        {
            _gameState.Logger.Log(MessageType.Error, "Encountered an error when connecting to the server");
            _window.ConnectButton.IsEnabled = true;
        }
    }

    public bool IsConnected() => _connectionManager.IsConnected();
}
