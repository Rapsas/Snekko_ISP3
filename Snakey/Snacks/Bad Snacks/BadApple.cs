using Snakey.Config;
using Snakey.Flyweight;
using Snakey.Managers;
using Snakey.Visitor;
using System;
using System.Windows.Media;

namespace Snakey.Snacks
{
    public class BadApple : BadSnack
    {
        public override void TriggerEffect()
        {
            
            Accept(new BadVisitor());
        }
        public BadApple() : base()
        {
            _body = new();

            _body.Source = ImageFactory.GetImage("bad_apple.png");
            _body.Width = _body.Height = Settings.CellSize;

        }
        public override void Accept(IVisitor visitor)
        {
            visitor.VisitApple(this);
        }
    }
}
