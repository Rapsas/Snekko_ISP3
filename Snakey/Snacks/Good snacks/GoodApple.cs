using Snakey.Config;
using Snakey.Flyweight;
using Snakey.Managers;
using Snakey.Visitor;

namespace Snakey.Snacks
{
    public class GoodApple : GoodSnack
    {
        public override void TriggerEffect()
        {
            Accept(new GoodVisitor());
        }
        public GoodApple() : base()
        {
            _body = new();

            _body.Source = ImageFactory.GetImage("good_apple.png");
            _body.Width = _body.Height = Settings.CellSize;
        }
        public override void Accept(IVisitor visitor)
        {
            visitor.VisitApple(this);
        }
    }
}
