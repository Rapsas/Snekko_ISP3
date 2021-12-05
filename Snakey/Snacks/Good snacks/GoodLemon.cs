using Snakey.Config;
using Snakey.Flyweight;
using Snakey.Visitor;

namespace Snakey.Snacks
{
    public class GoodLemon : GoodSnack
    {
        public override void TriggerEffect()
        {
            Accept(new GoodVisitor());
        }
        public GoodLemon() : base()
        {
            Body = new();

            Body.Source = ImageFactory.GetImage("good_lemon.png");
            Body.Width = Body.Height = Settings.CellSize;
        }
        public override void Accept(IVisitor visitor)
        {
            visitor.VisitLemon(this);
        }
    }
}
