using Microsoft.AspNetCore.SignalR.Client;
using Snakey.Config;
using Snakey.Managers;
using System;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snakey.Snacks
{
    class MysteryLemon : MysterySnack
    {
        public override void TriggerEffect()
        {
            //GameState.Instance.Score++;
            var choice = new Random().Next(11);
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
        public MysteryLemon() : base()
        {
            _body = new Ellipse()
            {
                Stroke = this.Stroke,
                StrokeThickness = this.StrokeThickness,
                Width = Settings.CellSize,
                Height = Settings.CellSize,
                Fill = Brushes.Yellow
            };
        }
    }
}
