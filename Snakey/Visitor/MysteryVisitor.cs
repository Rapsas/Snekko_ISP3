using Microsoft.AspNetCore.SignalR.Client;
using Snakey.Managers;
using Snakey.Models;
using System;

namespace Snakey.Visitor
{
    class MysteryVisitor : IVisitor
    {
        public void VisitApple(Snack snack)
        {
            Random rnd = new Random();
            var choice = rnd.Next(11);

            if (choice > 5)
            {
                if (GameState.Instance.MultiplayerManager.Connection.State == HubConnectionState.Connected)
                    GameState.Instance.MultiplayerManager.Connection?.SendAsync("ChangePlayerSize", 2).Wait();
            }
            else
            {
                GameState.Instance.Player.Expand();
                GameState.Instance.Player.Expand();
            }
        }

        public void VisitLemon(Snack snack)
        {
            Random rnd = new Random();
            var choice = rnd.Next(11);

            if (choice > 5)
            {
                if (GameState.Instance.MultiplayerManager.Connection.State == HubConnectionState.Connected)
                    GameState.Instance.MultiplayerManager.Connection?.SendAsync("ChangePlayerSize", -2).Wait();
            }
            else
            {
                GameState.Instance.Player.Shrink();
                GameState.Instance.Player.Shrink();
            }
        }
    }
}
