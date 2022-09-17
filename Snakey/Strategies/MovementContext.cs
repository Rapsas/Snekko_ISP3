namespace Snakey.Strategies;

using Snakey.Models;

public class MovementContext
{
    private IMovementStrategy _movementStrategy;

    public MovementContext(IMovementStrategy movementStrategy)
    {
        _movementStrategy = movementStrategy;
    }
    public MovementContext() { }
    public void SetStrategy(IMovementStrategy movementStrategy)
    {
        _movementStrategy = movementStrategy;
    }
    public void ExecuteStrategy(Snake player)
    {
        if (_movementStrategy != null)
            _movementStrategy.ChangeMovementDirection(player);
    }
    public IMovementStrategy GetStrategy() => _movementStrategy;
}
