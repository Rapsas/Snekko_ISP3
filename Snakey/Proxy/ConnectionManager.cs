﻿using Microsoft.AspNetCore.SignalR.Client;
using Snakey.Managers;

namespace Snakey.Proxy
{
    public class ConnectionManager : IConnectionManager
    {
        public MultiplayerManager MultiplayerManager { get; set; }

        public ConnectionManager()
        {
            MultiplayerManager = new("http://localhost:5000/gameHub"); // new("http://158.129.23.210:5003/gameHub");
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
}