using Common.Enums;
using Snakey.Models;
using Snakey.States;

namespace Snakey.Strategies
{
    public class MovementLeftStrategy : IMovementStrategy
    {
        public void ChangeMovementDirection(Snake player)
        {
            if (player.CurrentMovementDirection != MovementDirection.Right)
            {
                player.CurrentMovementDirection = MovementDirection.Left;
                player.SwitchState(new LeftState(player));
            }
                
        }
    }
}
