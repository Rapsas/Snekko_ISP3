using Snakey.Config;
using Snakey.Flyweight;
using Snakey.Visitor;
using System;

namespace Snakey.Snacks
{
    public class MysteryApple : MysterySnack
    {
        public override void TriggerEffect()
        {

            Accept(new MysteryVisitor());
        }

        public override MysterySnack Clone()
        {
            var cloned = (MysteryApple)this.MemberwiseClone();
            cloned.Body = new();

            cloned.Body.Source = ImageFactory.GetImage("mystery_apple.png");
            cloned.Body.Width = cloned.Body.Height = Settings.CellSize;

            return cloned;
        }

        public MysteryApple() : base()
        {
            Body = new();

            Body.Source = ImageFactory.GetImage("mystery_apple.png"); ;
            Body.Width = Body.Height = Settings.CellSize;
        }
        public override string ToString()
        {
            return this.Rnd.GetHashCode().ToString();
        }

        public override MysterySnack DeepClone()
        {
            MysteryApple other = (MysteryApple)this.Clone(); //same as shallow clone, setting new random
            other.Rnd = new Random();
            return other;
        }
        public override void Accept(IVisitor visitor)
        {
            visitor.VisitApple(this);
        }
    }
}
