using Snakey.Models;
using System.Windows.Media;

namespace Snakey.Snacks
{
    public class BadSnack : Snack
    {
        protected SolidColorBrush Stroke = Brushes.Red;
        protected double StrokeThickness = 5;
        public BadSnack()
        {
            WasConsumed = false;
        }
        public override void TriggerEffect()
        {

        }
    }
}
