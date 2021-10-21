using Common.Enums;
using Common.Utility;
using Snakey.Managers;
using Snakey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Snakey.Decorators
{
    class ShrinkSnakeTriggerEffectDecorator : TriggerEffectDecorator
    {
        public ShrinkSnakeTriggerEffectDecorator(Snack snack) 
            : base(snack) {}

        public override void TriggerEffect()
        {
            GameState.Instance.Player.Shrink();
            base.TriggerEffect();
        }
    }
}
