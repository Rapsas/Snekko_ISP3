using Common.Utility;
using Snakey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakey.Adapter
{
    public class SnackAdapter : ISnackTarget
    {
        public Vector2D Location { get => _snack.Location; set => _snack.Location = value; }
        public bool WasConsumed { get => _snack.WasConsumed; set => _snack.WasConsumed = value; }
        private readonly Snack _snack;

        public SnackAdapter(Snack snack)
        {
            _snack = snack;
        }

        public void Draw()
        {
            _snack.Draw();
        }

        public SnackPackage SnackPackage()
        {
            return _snack.SnackPackage();
        }

        public Type GetSnackType()
        {
            return _snack.GetType();
        }

        public void TriggerEffect()
        {
            _snack.TriggerEffect();
        }
    }
}
