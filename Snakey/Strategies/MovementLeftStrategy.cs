namespace Snakey.Strategies;

using Common.Enums;
using Snakey.Models;
using Snakey.States;

public class MovementLeftStrategy : IMovementStrategy
{
    public void ChangeMovementDirection(Snake player)
    {
        if (player.CurrentMovementDirection == MovementDirection.Right)
            return;

        player.CurrentMovementDirection = MovementDirection.Left;
        player.SwitchState(new LeftState(player));
    }
}
