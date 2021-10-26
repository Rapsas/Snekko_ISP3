using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Utility;
using Snakey.Models;

namespace Snakey.Adapter
{
    public interface ISnackTarget
    {
        public Vector2D Location { get; set; }
        public bool WasConsumed { get; set; }

        public void Draw();
        public SnackPackage SnackPackage();
        public Type GetSnackType();
        public void TriggerEffect();
    }
}
