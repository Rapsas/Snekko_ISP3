using Snakey.Config;
using Snakey.Flyweight;
using Snakey.Managers;
using System;
using System.Windows.Media;

namespace Snakey.Snacks
{
    public class BadApple : BadSnack
    {
        public override void TriggerEffect()
        {
            var rnd = new Random();

            byte R = (byte)rnd.Next(256);
            byte G = (byte)rnd.Next(256);
            byte B = (byte)rnd.Next(256);

            GameState.Instance.Player.HeadColor.Color = Color.FromRgb(R, G, B);
        }
        public BadApple() : base()
        {
            _body = new();

            _body.Source = ImageFactory.GetImage("bad_apple.png");
            _body.Width = _body.Height = Settings.CellSize;

        }
    }
}
