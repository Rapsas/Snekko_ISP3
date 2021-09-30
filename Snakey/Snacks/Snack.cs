using Common.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace Snakey.Snacks
{
    // NOTE: this shit wont send through SignalR so we will need some sort of 
    // new package to transfer type and location in rebuild the list it at the other end
    public abstract class Snack
    {
        public Vector2D Location { get; set; }
        public bool WasConsumed { get; set; } = false;
        public abstract void TriggerEffect();
        public abstract void Draw();
    }
}
