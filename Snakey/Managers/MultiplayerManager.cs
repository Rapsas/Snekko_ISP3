using Microsoft.AspNetCore.SignalR.Client;
using Snakey.Chain_of_Responsibility;
using System;
using System.Threading.Tasks;

namespace Snakey.Managers
{
    public class MultiplayerManager
    {
        public HubConnection Connection { get; set; }
        public MultiplayerManager(string url)
        {
            GameState.Instance.Logger.Log(MessageType.Server, $"Creating connection via {url}");
            Connection = new HubConnectionBuilder()
               .WithUrl(new Uri(url))
               .WithAutomaticReconnect()
               .Build();
        }

        public async Task ConnectToServer()
        {
            await Connection.StartAsync();
        }
        public async Task DisconnectFromServer()
        {
            await Connection.StopAsync();
        }
    }
}
