using Common.Utility;
using System;

namespace Snakey.Adapter
{
    public interface ISnackTarget
    {
        public Vector2D Location { get; set; }
        public bool WasConsumed { get; set; }

        public SnackPackage SnackPackage();
        public Type GetSnackType();
        public void TriggerEffect();
    }
}
