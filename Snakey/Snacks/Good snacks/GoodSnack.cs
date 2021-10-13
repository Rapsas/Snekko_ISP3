using Common.Enums;
using Snakey.Models;
using System.Windows.Media;

namespace Snakey.Snacks
{
    class GoodSnack : Snack
    {
        protected SolidColorBrush Stroke = Brushes.Green;
        protected double StrokeThickness = 5;
        public GoodSnack()
        {
            WasConsumed = false;
            _effectType = EffectType.Good;
        }
        public override void TriggerEffect()
        {
            
        }
    }
}
