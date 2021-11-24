using Common.Enums;
using Snakey.Models;
using Snakey.States;

namespace Snakey.Strategies
{
    public class MovementUpStrategy : IMovementStrategy
    {
        public void ChangeMovementDirection(Snake player)
        {
            if (player.CurrentMovementDirection != MovementDirection.Down)
            {
                player.CurrentMovementDirection = MovementDirection.Up;
                player.SwitchState(new UpState(player));
            }
            
        }
    }
}
