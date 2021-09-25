using Microsoft.AspNetCore.SignalR.Client;
using System;

namespace Snakey.Managers
{
    public class MultiplayerManager
    {
        public HubConnection Connection { get; set; }

        public MultiplayerManager(string url)
        {
            Connection = new HubConnectionBuilder()
               .WithUrl(new Uri(url))
               .WithAutomaticReconnect()
               .Build();

        }

        public void ConnectToServer()
        {
            Connection.StartAsync();
        }
    }
}
