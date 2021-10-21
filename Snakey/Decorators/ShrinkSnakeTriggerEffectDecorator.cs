using Common.Enums;
using Common.Utility;
using Snakey.Command;
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
        private CommandInvoker shrinker;
        public ShrinkSnakeTriggerEffectDecorator(Snack snack) 
            : base(snack) {
            shrinker = new CommandInvoker();
            shrinker.SetCommand(new SnakeShrinkCommand(GameState.Instance.Player));
        }

        public override void TriggerEffect()
        {
            shrinker.ExecuteCommand();
            base.TriggerEffect();
        }
    }
}
