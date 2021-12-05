using Snakey.Models;
using Snakey.Visitor;
using System.Windows.Media;

namespace Snakey.Snacks
{
    public class BadSnack : Snack
    {
        private SolidColorBrush stroke = Brushes.Red;
        private double strokeThickness = 5;

        protected SolidColorBrush Stroke { get => stroke; set => stroke = value; }
        protected double StrokeThickness { get => strokeThickness; set => strokeThickness = value; }

        public BadSnack()
        {
            WasConsumed = false;
        }

        public override void Accept(IVisitor visitor)
        {

        }

        public override void TriggerEffect()
        {

        }
    }
}
