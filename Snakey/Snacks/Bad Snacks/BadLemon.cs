using Microsoft.AspNetCore.SignalR.Client;
using Snakey.Config;
using Snakey.Flyweight;
using Snakey.Managers;
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
            _body = new();

            _body.Source = ImageFactory.GetImage("bad_lemon.png");
            _body.Width = _body.Height = Settings.CellSize;
        }
        public override void Accept(IVisitor visitor)
        {
            visitor.VisitLemon(this);
        }
    }
}
