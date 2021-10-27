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
        }
        public override void TriggerEffect()
        {

        }
    }
}
