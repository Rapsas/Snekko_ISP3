namespace Snakey.Strategies;

using Common.Enums;
using Snakey.Models;
using Snakey.States;

public class MovementRightStrategy : IMovementStrategy
{
    public void ChangeMovementDirection(Snake player)
    {
        if (player.CurrentMovementDirection == MovementDirection.Left)
            return;

        player.CurrentMovementDirection = MovementDirection.Right;
        player.SwitchState(new RightState(player));
    }
}
