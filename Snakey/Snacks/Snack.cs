using Common.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snakey.Snacks
{
    public abstract class Snack
    {
        public Vector2D Location { get; set; }

        public abstract void TriggerEffect();
    }
}
