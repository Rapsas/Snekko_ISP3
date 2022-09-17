namespace Snakey.Command;

public class CommandInvoker
{
    private ICommand _command;
    public ICommand SetCommand(ICommand command)
    {
        _command = command;
        return _command;
    }
    public void ExecuteCommand()
    {
        _command.Execute();
    }

    public void UndoCommand()
    {
        _command.Undo();
    }
}
