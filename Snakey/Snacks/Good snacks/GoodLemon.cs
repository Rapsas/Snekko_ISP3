using Common.Enums;
using Microsoft.AspNetCore.SignalR.Client;
using Snakey.Config;
using Snakey.Managers;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snakey.Snacks
{
    class GoodLemon : GoodSnack
    {
        public override void TriggerEffect()
        {
            //GameState.Instance.Score++;
            if (GameState.Instance.MultiplayerManager.Connection.State == HubConnectionState.Connected)
                GameState.Instance.MultiplayerManager.Connection?.SendAsync("ChangePlayerSize", -1).Wait();
        }
        public GoodLemon() : base()
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
