﻿using Common.Enums;
using Snakey.Models;

namespace Snakey.Strategies
{
    class MovementRightStrategy : IMovementStrategy
    {
        public void ChangeMovementDirection(Snake player)
        {
            if (player.CurrentMovementDirection != MovementDirection.Left)
                player.CurrentMovementDirection = MovementDirection.Right;
        }
    }
}
