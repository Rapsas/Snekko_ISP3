namespace Snakey.Command
{
    interface ICommand
    {
        public void Execute();
        public void Undo();
    }
}
