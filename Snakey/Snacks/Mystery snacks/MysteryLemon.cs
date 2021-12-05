using Snakey.Config;
using Snakey.Flyweight;
using Snakey.Visitor;
using System;

namespace Snakey.Snacks
{
    public class MysteryLemon : MysterySnack
    {
        public override void TriggerEffect()
        {

            Accept(new MysteryVisitor());
        }

        public override MysterySnack Clone()
        {
            var cloned = (MysteryLemon)this.MemberwiseClone();

            cloned.Body = new();

            cloned.Body.Source = ImageFactory.GetImage("mystery_lemon.png");
            cloned.Body.Width = cloned.Body.Height = Settings.CellSize;
            return cloned;
        }

        public override MysterySnack DeepClone()
        {
            MysteryLemon other = (MysteryLemon)this.Clone();
            other.Rnd = new Random();
            return other;
        }

        public MysteryLemon() : base()
        {
            Body = new();

            Body.Source = ImageFactory.GetImage("mystery_lemon.png");
            Body.Width = Body.Height = Settings.CellSize;
        }
        public override void Accept(IVisitor visitor)
        {
            visitor.VisitLemon(this);
        }
    }
}
