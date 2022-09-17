namespace Snakey.Strategies;

using Common.Enums;
using Snakey.Models;
using Snakey.States;

public class MovementUpStrategy : IMovementStrategy
{
    public void ChangeMovementDirection(Snake player)
    {
        if (player.CurrentMovementDirection == MovementDirection.Down)
            return;
        player.CurrentMovementDirection = MovementDirection.Up;
        player.SwitchState(new UpState(player));

    }
}
