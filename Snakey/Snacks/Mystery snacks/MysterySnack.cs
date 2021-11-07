using Snakey.Models;
using System;
using System.Windows.Media;

namespace Snakey.Snacks
{
    public abstract class MysterySnack : Snack
    {
        protected SolidColorBrush Stroke = Brushes.Blue;
        protected double StrokeThickness = 5;
        public Random rnd;
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
    }
}
