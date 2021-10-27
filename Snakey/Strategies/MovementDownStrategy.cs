using Common.Enums;
using Snakey.Models;

namespace Snakey.Strategies
{
    class MovementDownStrategy : IMovementStrategy
    {
        public void ChangeMovementDirection(Snake player)
        {
            if (player.CurrentMovementDirection != MovementDirection.Up)
                player.CurrentMovementDirection = MovementDirection.Down;
        }
    }
}
