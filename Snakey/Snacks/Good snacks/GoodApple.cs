using Snakey.Config;
using Snakey.Flyweight;
using Snakey.Managers;
using System;
using System.Windows.Media.Imaging;

namespace Snakey.Snacks
{
    public class GoodApple : GoodSnack
    {
        public override void TriggerEffect()
        {
            GameState.Instance.Player.Expand();
        }
        public GoodApple() : base()
        {
            _body = new();

            var imagePath = System.IO.Path.Combine(Settings.AssetFolder, "good_apple.png");
            BitmapImage image = new(new Uri(imagePath));
            _body.Source = image;
            _body.Width = _body.Height = Settings.CellSize;
        }
    }
}
