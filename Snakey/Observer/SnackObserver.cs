using Snakey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakey.Observer
{
    class SnackObserver : IObserver
    {
        public void Update(Snack snack)
        {
            snack.TriggerEffect();
            snack.WasConsumed = true;
        }
    }
}
