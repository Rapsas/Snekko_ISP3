using Snakey.Chain_of_Responsibility;
using Snakey.Managers;
using System;

namespace Snakey.Proxy
{
    public class ConnectionManagerProxy : IConnectionManager
    {
        private readonly ConnectionManager _connectionManager;
        private readonly GameState _gameState;
        private readonly MainWindow _window;

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
                _gameState.Logger.Log(MessageType.Warning, "Connecting to server");
                _connectionManager.ConnectToServer();
                _gameState.Logger.Log(MessageType.Warning, "Connected to server");
            }
            catch (Exception)
            {
                _gameState.Logger.Log(MessageType.Error, "Encountered an error when connecting to the server");
                _window.ConnectButton.IsEnabled = true;
            }
        }

        public bool IsConnected()
        {
            _gameState.Logger.Log(MessageType.Warning, "Checking if player connected...");

            if (_connectionManager.IsConnected())
            {
                _gameState.Logger.Log(MessageType.Warning, "Player has connected");
                return true;
            }
            else
            {
                _gameState.Logger.Log(MessageType.Warning, "Player has disconnected");
                return false;
            }
        }
    }
}
