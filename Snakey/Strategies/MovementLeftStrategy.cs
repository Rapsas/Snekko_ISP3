using Common.Enums;
using Snakey.Models;

namespace Snakey.Strategies
{
    public class MovementLeftStrategy : IMovementStrategy
    {
        public void ChangeMovementDirection(Snake player)
        {
            if (player.CurrentMovementDirection != MovementDirection.Right)
                player.CurrentMovementDirection = MovementDirection.Left;
        }
    }
}
