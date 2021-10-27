using Snakey.Models;

namespace Snakey.Strategies
{
    interface IMovementStrategy
    {
        public void ChangeMovementDirection(Snake player);
    }
}
