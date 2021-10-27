namespace Snakey.Command
{
    class CommandInvoker
    {
        private ICommand _command;
        public void SetCommand(ICommand command)
        {
            _command = command;
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
}
