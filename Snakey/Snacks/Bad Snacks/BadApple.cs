using Snakey.Config;
using Snakey.Flyweight;
using Snakey.Managers;
using System;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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
            var imagePath = System.IO.Path.Combine(Settings.AssetFolder, "bad_apple.png");
            BitmapImage image = new(new Uri(imagePath));
            _body.Source = image;
            _body.Width = _body.Height = Settings.CellSize;

        }
    }
}
