using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace Snakey.Managers
{
    public class MultiplayerManager
    {
        public HubConnection Connection { get; set; }
        public string ID { get { return Connection.ConnectionId; }  }

        public MultiplayerManager(string url)
        {
            Connection = new HubConnectionBuilder()
               .WithUrl(new Uri(url))
               .WithAutomaticReconnect()
               .Build();

        }

        public async Task ConnectToServer()
        {
            await Connection.StartAsync();
        }
    }
}
