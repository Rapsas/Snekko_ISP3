using Microsoft.AspNetCore.SignalR.Client;
using Snakey.Config;
using Snakey.Flyweight;
using Snakey.Managers;
using System;
using System.Windows.Media.Imaging;

namespace Snakey.Snacks
{
    public class GoodLemon : GoodSnack
    {
        public override void TriggerEffect()
        {
            if (GameState.Instance.MultiplayerManager.Connection.State == HubConnectionState.Connected)
                GameState.Instance.MultiplayerManager.Connection?.SendAsync("ChangePlayerSize", -1).Wait();
        }
        public GoodLemon() : base()
        {
            _body = new();

            var imagePath = System.IO.Path.Combine(Settings.AssetFolder, "good_lemon.png");
            BitmapImage image = new(new Uri(imagePath));
            _body.Source = image;
            _body.Width = _body.Height = Settings.CellSize;
        }
    }
}
