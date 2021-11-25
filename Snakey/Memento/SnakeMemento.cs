using Snakey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakey.Memento
{
    public class SnakeMemento
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
