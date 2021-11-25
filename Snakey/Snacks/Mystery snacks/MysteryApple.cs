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
            cloned._body = new();

            cloned._body.Source = ImageFactory.GetImage("mystery_apple.png");
            cloned._body.Width = cloned._body.Height = Settings.CellSize;

            return cloned;
        }

        public MysteryApple() : base()
        {
            _body = new();

            _body.Source = ImageFactory.GetImage("mystery_apple.png"); ;
            _body.Width = _body.Height = Settings.CellSize;
        }
        public override string ToString()
        {
            return this.rnd.GetHashCode().ToString();
        }

        public override MysterySnack DeepClone()
        {
            MysteryApple other = (MysteryApple)this.Clone(); //same as shallow clone, setting new random
            other.rnd = new Random();
            return other;
        }
        public override void Accept(IVisitor visitor)
        {
            visitor.VisitApple(this);
        }
    }
}
