using Snakey.Config;
using Snakey.Flyweight;
using Snakey.Visitor;

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
            Body = new();

            Body.Source = ImageFactory.GetImage("bad_apple.png");
            Body.Width = Body.Height = Settings.CellSize;

        }
        public override void Accept(IVisitor visitor)
        {
            visitor.VisitApple(this);
        }
    }
}
