namespace Snakey.Command
{
    public interface ICommand
    {
        public void Execute();
        public void Undo();
    }
}
