using Microsoft.AspNetCore.SignalR.Client;
using Snakey.Config;
using Snakey.Managers;
using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            var imagePath = System.IO.Path.Combine(Settings.AssetFolder, "bad_lemon.png");
            BitmapImage image = new(new Uri(imagePath));
            _body.Source = image;
        }
    }
}
