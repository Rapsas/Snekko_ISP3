using Microsoft.AspNetCore.SignalR.Client;
using Snakey.Flyweight;
using Snakey.Managers;

namespace Snakey.Snacks
{
    public class BadLemon : BadSnack
    {
        public override void TriggerEffect()
        {
            if (GameState.Instance.MultiplayerManager.Connection.State == HubConnectionState.Connected)
                GameState.Instance.MultiplayerManager.Connection?.SendAsync("ChangePlayerSize", 1).Wait();
        }

        public BadLemon() : base()
        {
            _body = new();

            _body.Source = ImageFactory.GetImage("bad_lemon.png");
            _body.Width = 40;
            _body.Height = 40;
        }
    }
}
