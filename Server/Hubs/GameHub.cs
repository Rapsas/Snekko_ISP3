using Common.Enums;
using Common.Utility;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Server.Hubs
{
    public class Storage
    {
        public static int UserCount = 0;
        public static List<string> Players = new();
    }

    public class GameHub : Hub
    {
        public async Task SendPositions(PlayerPackage package)
        {
            //Console.WriteLine($"Got player data from ID {Context.ConnectionId} with data {package.SnakeHeadLocation}");
            await Clients.Others.SendAsync("RecievePositions", package);
        }

        public async Task SendEatenSnackPosition(SnackPackage snack)
        {
            //Console.WriteLine($"Got snack data from ID {Context.ConnectionId} with location {snack.Location}");
            await Clients.Others.SendAsync("RecieveEatenSnackPosition", snack);
        }

        public async Task SendSnackList(List<SnackPackage> snack)
        {
            //Console.WriteLine($"Got snack list");
            await Clients.Others.SendAsync("RecieveSnackList", snack);
        }

        public async Task AddNewSnack(SnackPackage snack)
        {
            //Console.WriteLine($"Got newly made snack ");
            await Clients.Others.SendAsync("AddSnack", snack);
        }

        public async Task ChangeMap(MapTypes mapType)
        {
            //Console.WriteLine($"Got newly made snack ");
            await Clients.Others.SendAsync("ChangeMap", mapType);
        }

        public async Task ChangePlayerSize(int timesToShorten)
        {
            Console.WriteLine($"Expand other players by {timesToShorten}");
            await Clients.Others.SendAsync("ShortenSecondPlayer", timesToShorten);
        }

        public async Task SendScore(int score)
        {
            await Clients.Others.SendAsync("RecieveScore", score);
        }

        public override async Task OnConnectedAsync()
        {
            Storage.Players.Add(Context.ConnectionId);
            Storage.UserCount++;
            Console.WriteLine($"Player connected with ID {Context.ConnectionId}");
            await base.OnConnectedAsync();
            if (Storage.UserCount == 2)
            {
                Console.WriteLine("Second player connected. Sending list");
                // Ask first player for a snack list
                await Clients.Client(Storage.Players[0]).SendAsync("AskForSnackList");
                Console.WriteLine("Clearing scores");
                await Clients.All.SendAsync("ClearScore"); // clear both player scores
            }

        }

        public async override Task OnDisconnectedAsync(Exception exception)
        {
            Storage.UserCount--;
            Storage.Players.Remove(Context.ConnectionId);
            Console.WriteLine($"Player disconnected with ID {Context.ConnectionId}");
            await base.OnDisconnectedAsync(new Exception("Disconnected player"));
        }
    }
}