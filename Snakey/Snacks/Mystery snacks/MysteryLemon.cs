using Microsoft.AspNetCore.SignalR.Client;
using Snakey.Config;
using Snakey.Flyweight;
using Snakey.Managers;
using Snakey.Visitor;
using System;

namespace Snakey.Snacks
{
    public class MysteryLemon : MysterySnack
    {
        public override void TriggerEffect()
        {
            
            Accept(new MysteryVisitor());
        }

        public override MysterySnack Clone()
        {
            var cloned = (MysteryLemon)this.MemberwiseClone();

            cloned._body = new();

            cloned._body.Source = ImageFactory.GetImage("mystery_lemon.png");
            cloned._body.Width = cloned._body.Height = Settings.CellSize;
            return cloned;
        }

        public override MysterySnack DeepClone()
        {
            MysteryLemon other = (MysteryLemon)this.Clone();
            other.rnd = new Random();
            return other;
        }

        public MysteryLemon() : base()
        {
            _body = new();

            _body.Source = ImageFactory.GetImage("mystery_lemon.png");
            _body.Width = _body.Height = Settings.CellSize;
        }
        public override void Accept(IVisitor visitor)
        {
            visitor.VisitLemon(this);
        }
    }
}
