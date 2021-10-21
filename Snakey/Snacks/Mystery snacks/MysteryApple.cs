using Common.Enums;
using Microsoft.AspNetCore.SignalR.Client;
using Snakey.Config;
using Snakey.Managers;
using System;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snakey.Snacks
{
    class MysteryApple: MysterySnack
    {
        public override void TriggerEffect()
        {
            GameState.Instance.Score++;
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

        public override MysterySnack Clone()
        {
            return (MysterySnack)this.MemberwiseClone();
        }

        public MysteryApple() : base()
        {
            _body = new Rectangle()
            {
                Stroke = this.Stroke,
                StrokeThickness = this.StrokeThickness,
                Width = Settings.CellSize,
                Height = Settings.CellSize,
                Fill = Brushes.IndianRed
            };
        }
        public override string ToString()
        {
            return this.rnd.GetHashCode().ToString();
        }
    }
}
