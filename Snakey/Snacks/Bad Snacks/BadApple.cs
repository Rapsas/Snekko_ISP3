namespace Snakey.Snacks;

using Snakey.Config;
using Snakey.Flyweight;
using Snakey.Visitor;

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
