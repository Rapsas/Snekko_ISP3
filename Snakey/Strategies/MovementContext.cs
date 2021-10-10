using Snakey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakey.Strategies
{
    class MovementContext
    {
        private IMovementStrategy _movementStrategy;
        
        public MovementContext(IMovementStrategy movementStrategy)
        {
            _movementStrategy = movementStrategy;
        }
        public MovementContext()
        {
            
        }
        public void SetStrategy(IMovementStrategy movementStrategy)
        {
            _movementStrategy = movementStrategy;
        }
        public void ExecuteStrategy(Snake player)
        {
            if (_movementStrategy != null)
            _movementStrategy.ChangeMovementDirection(player);
        }
    }
}
