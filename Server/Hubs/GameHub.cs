﻿using Common.Models;
using Common.Utility;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Hubs
{
    public class GameHub : Hub
    {
        public async Task SendPositions(Package package)
        {
            Console.WriteLine($"Got player data from ID {Context.ConnectionId} with data {package.SnakeHeadLocation}");
            await Clients.Others.SendAsync("RecievePositions", package);
        }

        public async Task SendSnackPositions(List<Snack> snacks)
        {
            Console.WriteLine($"Got snack data from ID {Context.ConnectionId}");
            await Clients.Others.SendAsync("RecieveSnackPositions", snacks);
        }

        public async override Task OnConnectedAsync()
        {
            Console.WriteLine($"Player connected with ID {Context.ConnectionId}");
            await base.OnConnectedAsync();
        }

        public async override Task OnDisconnectedAsync(Exception exception)
        {
            Console.WriteLine($"Player disconnected with ID {Context.ConnectionId}");
            await base.OnDisconnectedAsync(new Exception("Disconnected player"));
        }
    }
}