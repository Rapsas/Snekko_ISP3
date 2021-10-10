using Common.Enums;
using Snakey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakey.Strategies
{
    class MovementUpStrategy : IMovementStrategy
    {
        public void ChangeMovementDirection(Snake player)
        {
            if (player.CurrentMovementDirection != MovementDirection.Down)
                player.CurrentMovementDirection = MovementDirection.Up;
        }
    }
}
