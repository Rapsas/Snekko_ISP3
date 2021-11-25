using Microsoft.AspNetCore.SignalR.Client;
using Snakey.Managers;
using Snakey.Models;
using System;
using System.Windows.Media;

namespace Snakey.Visitor
{
    class BadVisitor : IVisitor
    {
        public void VisitApple(Snack snack)
        {
            var rnd = new Random();

            byte R = (byte)rnd.Next(256);
            byte G = (byte)rnd.Next(256);
            byte B = (byte)rnd.Next(256);

            GameState.Instance.Player.HeadColor.Color = Color.FromRgb(R, G, B);
        }

        public void VisitLemon(Snack snack)
        {
            if (GameState.Instance.MultiplayerManager.Connection.State == HubConnectionState.Connected)
                GameState.Instance.MultiplayerManager.Connection?.SendAsync("ChangePlayerSize", 1).Wait();
        }
    }
}
