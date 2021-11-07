using Common.Enums;
using Snakey.Models;

namespace Snakey.Strategies
{
    public class MovementUpStrategy : IMovementStrategy
    {
        public void ChangeMovementDirection(Snake player)
        {
            if (player.CurrentMovementDirection != MovementDirection.Down)
                player.CurrentMovementDirection = MovementDirection.Up;
        }
    }
}
