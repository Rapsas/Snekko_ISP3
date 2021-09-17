using Common.Utility;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Hubs
{
    public class GameHub : Hub
    {
        public async Task SendPositions(List<Vector2D> players)
        {
            await Clients.All.SendAsync("RecievePositions", players);
        }
    }
}