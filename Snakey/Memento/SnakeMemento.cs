using Snakey.Models;
using System.Diagnostics.CodeAnalysis;

namespace Snakey.Memento
{
    [SuppressMessage("NDepend", "ND1400:AvoidNamespacesMutuallyDependent", Justification = "...")]
    public class SnakeMemento : IMemento
    {
        [SuppressMessage("NDepend", "ND1400:AvoidNamespacesMutuallyDependent", Justification = "...")]
        private Snake snake;
        private string snakeText;
        [SuppressMessage("NDepend", "ND1400:AvoidNamespacesMutuallyDependent", Justification = "...")]
        public SnakeMemento(Snake snake, string snakeText)
        {
            this.snake = snake;
            this.snakeText = snakeText;
        }
        [SuppressMessage("NDepend", "ND1400:AvoidNamespacesMutuallyDependent", Justification = "...")]
        public void Restore()
        {
            snake.SetSnakeText(snakeText);
        }
    }
}
