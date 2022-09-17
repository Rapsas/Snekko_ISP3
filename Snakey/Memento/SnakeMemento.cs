namespace Snakey.Memento;

using Snakey.Models;

public class SnakeMemento : IMemento
{
    private readonly Snake snake;
    private readonly string snakeText;
    public SnakeMemento(Snake snake, string snakeText)
    {
        this.snake = snake;
        this.snakeText = snakeText;
    }
    public void Restore()
    {
        snake.Speak(snakeText);
    }
}
