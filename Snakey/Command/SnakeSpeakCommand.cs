namespace Snakey.Command;

using Snakey.Memento;
using Snakey.Models;

public class SnakeSpeakCommand : ICommand
{
    private readonly Snake _receiver;
    private readonly string _parameters;

    private IMemento _backup;

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
