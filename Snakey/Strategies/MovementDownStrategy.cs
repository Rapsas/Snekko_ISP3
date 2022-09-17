namespace Snakey.Strategies;

using Common.Enums;
using Snakey.Models;
using Snakey.States;


public class MovementDownStrategy : IMovementStrategy
{
    public void ChangeMovementDirection(Snake player)
    {
        if (player.CurrentMovementDirection == MovementDirection.Up)
            return;

        player.CurrentMovementDirection = MovementDirection.Down;
        player.SwitchState(new DownState(player));
    }
}
