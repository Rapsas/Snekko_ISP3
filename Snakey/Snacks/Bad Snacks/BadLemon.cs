using Snakey.Config;
using Snakey.Flyweight;
using Snakey.Visitor;

namespace Snakey.Snacks
{
    public class BadLemon : BadSnack
    {
        public override void TriggerEffect()
        {

            Accept(new BadVisitor());
        }

        public BadLemon() : base()
        {
            Body = new();

            Body.Source = ImageFactory.GetImage("bad_lemon.png");
            Body.Width = Body.Height = Settings.CellSize;
        }
        public override void Accept(IVisitor visitor)
        {
            visitor.VisitLemon(this);
        }
    }
}
