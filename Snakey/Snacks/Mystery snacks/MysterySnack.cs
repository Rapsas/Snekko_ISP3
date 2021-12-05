using Snakey.Models;
using Snakey.Visitor;
using System;
using System.Windows.Media;

namespace Snakey.Snacks
{
    public abstract class MysterySnack : Snack
    {
        private SolidColorBrush stroke = Brushes.Blue;
        private double strokeThickness = 5;
        private Random rnd;

        protected SolidColorBrush Stroke { get => stroke; set => stroke = value; }
        protected double StrokeThickness { get => strokeThickness; set => strokeThickness = value; }
        public Random Rnd { get => rnd; set => rnd = value; }

        public MysterySnack()
        {
            WasConsumed = false;
            rnd = new Random();
        }
        public override void TriggerEffect()
        {

        }
        public abstract MysterySnack Clone();
        public abstract MysterySnack DeepClone();
        public override void Accept(IVisitor visitor)
        {

        }
    }
}
