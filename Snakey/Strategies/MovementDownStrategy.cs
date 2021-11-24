using Common.Enums;
using Snakey.Models;
using Snakey.States;

namespace Snakey.Strategies
{
    public class MovementDownStrategy : IMovementStrategy
    {
        public void ChangeMovementDirection(Snake player)
        {
            if (player.CurrentMovementDirection != MovementDirection.Up)
            {
                player.CurrentMovementDirection = MovementDirection.Down;
                player.SwitchState(new DownState(player));
            }
                
        }
    }
}
