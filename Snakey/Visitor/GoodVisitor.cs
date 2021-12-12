using Microsoft.AspNetCore.SignalR.Client;
using Snakey.Managers;
using Snakey.Models;

namespace Snakey.Visitor
{
    class GoodVisitor : IVisitor
    {
        public void VisitApple(Snack snack)
        {
            GameState.Instance.Player.Expand();
        }
        //asdfghjk
        public void VisitLemon(Snack snack)
        {
            if (GameState.Instance.MultiplayerManager.Connection.State == HubConnectionState.Connected)
                GameState.Instance.MultiplayerManager.Connection?.SendAsync("ChangePlayerSize", -1).Wait();
        }
    }
}
