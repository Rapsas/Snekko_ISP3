using Snakey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snakey.Managers;
using System.Windows;
using Common.Utility;
using Common.Enums;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Snakey.Decorators
{
    public class DecreaseScoreTriggerEffectDecorator : TriggerEffectDecorator
    {
        public DecreaseScoreTriggerEffectDecorator(Snack snack)
            : base(snack) { }

        public override void TriggerEffect()
        {
            GameState.Instance.Score--;
            base.TriggerEffect();
        }
    }
}
