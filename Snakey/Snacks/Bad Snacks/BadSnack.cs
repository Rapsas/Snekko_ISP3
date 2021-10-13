﻿using Common.Enums;
using Snakey.Models;
using System.Windows.Media;

namespace Snakey.Snacks
{
    class BadSnack : Snack
    {
        protected SolidColorBrush Stroke = Brushes.Red;
        protected double StrokeThickness = 5;
        public BadSnack()
        {
            WasConsumed = false;
            _effectType = EffectType.Bad;
        }
        public override void TriggerEffect()
        {

        }
    }
}
