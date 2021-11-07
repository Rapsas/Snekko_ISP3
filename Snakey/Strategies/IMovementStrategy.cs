using Snakey.Models;

namespace Snakey.Strategies
{
    public interface IMovementStrategy
    {
        public void ChangeMovementDirection(Snake player);
    }
}
