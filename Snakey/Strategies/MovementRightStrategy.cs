using Common.Enums;
using Snakey.Models;
using Snakey.States;

namespace Snakey.Strategies
{
    public class MovementRightStrategy : IMovementStrategy
    {
        public void ChangeMovementDirection(Snake player)
        {
            if (player.CurrentMovementDirection != MovementDirection.Left)
            {
                player.CurrentMovementDirection = MovementDirection.Right;
                player.SwitchState(new RightState(player));
            }
        }
    }
}
