namespace Snakey.Strategies;

using Snakey.Models;

public interface IMovementStrategy
{
    public void ChangeMovementDirection(Snake player);
}
