using Snakey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakey.Strategies
{
    interface IMovementStrategy
    {
        public void ChangeMovementDirection(Snake player);
    }
}
