using Common.Utility;
using Snakey.Config;
using Snakey.Managers;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snakey.Snacks
{
    class GoodSnack : Snack
    {
        private Rectangle _body { get; set; }

        private Canvas _gameArea = GameState.Instance.GameArea;
        public GoodSnack()
        {
            _body = new()
            {
                Width = Settings.CellSize,
                Height = Settings.CellSize,
                Fill = Brushes.AliceBlue
            };
            WasConsumed = false;
        }
        public override void TriggerEffect()
        {
            GameState.Instance.Score++;
        }

        public override void Draw()
        {
            _gameArea.Children.Add(_body);
            Canvas.SetLeft(_body, Location.X);
            Canvas.SetTop(_body, Location.Y);
        }
    }
}
