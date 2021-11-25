﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snakey.Managers;
using Snakey.Chain_of_Responsibility;

namespace Snakey.Proxy
{
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
