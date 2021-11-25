using Snakey.Models;
using Snakey.Visitor;
using System.Windows.Media;

namespace Snakey.Snacks
{
    public class GoodSnack : Snack
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
        public override void Accept(IVisitor visitor)
        {

        }
    }
}
