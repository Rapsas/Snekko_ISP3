using Snakey.Models;

namespace Snakey.Command
{
    public class SnakeSpeakCommand : ICommand
    {
        private Snake _receiver;
        private string _parameters;

        public SnakeSpeakCommand(Snake receiver, string wordsToSay)
        {
            _receiver = receiver;
            _parameters = wordsToSay;
        }
        public void Execute()
        {
            _receiver.Speak(_parameters);
        }

        public void Undo()
        {
            _receiver.Shutup();
        }
    }
}
