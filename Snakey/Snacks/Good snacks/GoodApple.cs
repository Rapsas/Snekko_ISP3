using Snakey.Config;
using Snakey.Flyweight;
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
            Body = new();

            Body.Source = ImageFactory.GetImage("good_apple.png");
            Body.Width = Body.Height = Settings.CellSize;
        }
        public override void Accept(IVisitor visitor)
        {
            visitor.VisitApple(this);
        }
    }
}
