using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Server.Hubs
{
    public class GameHub : Hub
    {
        public async Task SendPositions(string player, string playstate)
        {
            await Clients.All.SendAsync("RecievePositions", player, playstate);
        }
    }
}
