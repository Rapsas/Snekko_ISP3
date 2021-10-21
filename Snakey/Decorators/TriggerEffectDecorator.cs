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
    public class TriggerEffectDecorator : Snack
    {
        public override Vector2D Location { get => Snack.Location; set => Snack.Location = value; }
        public override bool WasConsumed { get => Snack.WasConsumed; set => Snack.WasConsumed = value; }
        protected Snack Snack;

        public TriggerEffectDecorator(Snack snack)
        {
            Snack = snack;
        }

        public override void TriggerEffect()
        {
            Snack.TriggerEffect();
        }

        public override void SetTypesForServer(EffectType effectType, FoodType foodType)
        {
            Snack.SetTypesForServer(effectType, foodType);
        }
        public override void Draw()
        {
            Snack.Draw();
        }
        public override SnackPackage SnackPackage()
        {
            return Snack.SnackPackage();
        }
    }
}
