using Snakey.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Snakey.Snacks
{
    class MysterySnack : Snack
    {
        protected Canvas _gameArea = GameState.Instance.GameArea;
        protected SolidColorBrush Stroke = Brushes.Blue;
        protected double StrokeThickness = 5;
        public MysterySnack()
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
