using Snakey.Memento;
using Snakey.Models;

namespace Snakey.Command
{
    public class SnakeSpeakCommand : ICommand
    {
        private Snake _receiver;
        private string _parameters;

        private SnakeMemento _backup; 

        public SnakeSpeakCommand(Snake receiver, string wordsToSay)
        {
            _receiver = receiver;
            _parameters = wordsToSay;
        }
        public void Execute()
        {
            _backup = _receiver.Save();
            _receiver.Speak(_parameters);
        }

        public void Undo()
        {
            if (_backup != null)
            {
                _backup.Restore();
            }
        }
    }
}
