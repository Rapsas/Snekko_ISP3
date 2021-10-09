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
        protected Canvas _gameArea = GameState.Instance.GameArea;
        protected SolidColorBrush Stroke = Brushes.Green;
        protected double StrokeThickness = 5;
        public GoodSnack()
        {
            WasConsumed = false;
        }
        public override void TriggerEffect()
        {
            
        }

        public override void Draw()
        {
            
        }
    }
}
