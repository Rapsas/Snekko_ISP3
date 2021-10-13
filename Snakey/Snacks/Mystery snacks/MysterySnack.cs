using Common.Enums;
using Snakey.Models;
using System.Windows.Media;

namespace Snakey.Snacks
{
    class MysterySnack : Snack
    {
        protected SolidColorBrush Stroke = Brushes.Blue;
        protected double StrokeThickness = 5;
        public MysterySnack()
        {
            WasConsumed = false;
            _effectType = EffectType.Mystery;
        }
        public override void TriggerEffect()
        {

        }
    }
}
