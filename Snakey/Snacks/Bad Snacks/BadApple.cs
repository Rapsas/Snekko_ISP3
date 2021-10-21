using Common.Enums;
using Snakey.Config;
using Snakey.Managers;
using System;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snakey.Snacks
{
    class BadApple: BadSnack
    {
        public override void TriggerEffect()
        {
            // GameState.Instance.Score--;
            // GameState.Instance.Player.Shrink();

            var rnd = new Random();

            byte R = (byte)rnd.Next(256);
            byte G = (byte)rnd.Next(256);
            byte B = (byte)rnd.Next(256);

            GameState.Instance.Player.HeadColor.Color = Color.FromRgb(R, G, B);
        }
        public BadApple() : base()
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
    }
}
