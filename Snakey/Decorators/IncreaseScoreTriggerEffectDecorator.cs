using Snakey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snakey.Managers;
using Common.Enums;
using Common.Utility;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Snakey.Decorators
{
    public class IncreaseScoreTriggerEffectDecorator : TriggerEffectDecorator
    {
        public IncreaseScoreTriggerEffectDecorator(Snack snack) 
            : base(snack) {}

        public override void TriggerEffect()
        {
            GameState.Instance.Score++;
            base.TriggerEffect();
        }
    }
}
