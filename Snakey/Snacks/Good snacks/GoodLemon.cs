using Microsoft.AspNetCore.SignalR.Client;
using Snakey.Config;
using Snakey.Managers;
using System;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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
            _body.Width = 40;
            _body.Height = 40;
        }
    }
}
