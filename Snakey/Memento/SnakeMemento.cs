using Snakey.Models;

namespace Snakey.Memento
{
    public class SnakeMemento : IMemento
    {
        private Snake snake;
        private string snakeText;
        public SnakeMemento(Snake snake, string snakeText)
        {
            this.snake = snake;
            this.snakeText = snakeText;
        }
        public void Restore()
        {
            snake.SetSnakeText(snakeText);
        }
    }
}
