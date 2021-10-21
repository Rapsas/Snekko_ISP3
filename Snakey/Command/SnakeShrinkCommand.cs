using Snakey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakey.Command
{
    class SnakeShrinkCommand : ICommand
    {
        private Snake _receiver;
        public void Execute()
        {
            _receiver.Shrink();
        }

        public void Undo()
        {
            _receiver.Expand();
        }
        public SnakeShrinkCommand(Snake receiver)
        {
            _receiver = receiver;
        }
    }
}
