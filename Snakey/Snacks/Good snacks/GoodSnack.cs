using Snakey.Models;
using Snakey.Visitor;
using System.Windows.Media;

namespace Snakey.Snacks
{
    public class GoodSnack : Snack
    {
        private SolidColorBrush stroke = Brushes.Green;
        private double strokeThickness = 5;

        protected SolidColorBrush Stroke { get => stroke; set => stroke = value; }
        protected double StrokeThickness { get => strokeThickness; set => strokeThickness = value; }

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
