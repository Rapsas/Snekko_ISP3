using Common.Models;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Server.Hubs
{
    public class GameHub : Hub
    {
        public async Task SendPositions(Snake player)
        {
            await Clients.All.SendAsync("ReceivePositions", player);
        }
    }
}