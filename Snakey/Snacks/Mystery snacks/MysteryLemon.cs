using Microsoft.AspNetCore.SignalR.Client;
using Snakey.Config;
using Snakey.Flyweight;
using Snakey.Managers;
using System;
using System.Windows.Media.Imaging;

namespace Snakey.Snacks
{
    public class MysteryLemon : MysterySnack
    {
        public override void TriggerEffect()
        {
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

        public override MysterySnack Clone()
        {
            var cloned = (MysteryLemon)this.MemberwiseClone();

            cloned._body = new();
            var imagePath = System.IO.Path.Combine(Settings.AssetFolder, "mystery_lemon.png");
            BitmapImage image = new(new Uri(imagePath));
            cloned._body.Source = image;
            cloned._body.Width = cloned._body.Height = Settings.CellSize;
            return cloned;
        }

        public override MysterySnack DeepClone()
        {
            MysteryLemon other = (MysteryLemon)this.Clone();
            other.rnd = new Random();
            return other;
        }

        public MysteryLemon() : base()
        {
            _body = new();

            var imagePath = System.IO.Path.Combine(Settings.AssetFolder, "mystery_lemon.png");
            BitmapImage image = new(new Uri(imagePath));
            _body.Source = image;
            _body.Width = _body.Height = Settings.CellSize;
        }
    }
}
