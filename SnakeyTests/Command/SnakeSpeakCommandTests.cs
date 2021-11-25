using Snakey.Models;
using Xunit;

namespace Snakey.Command.Tests
{
    public class SnakeSpeakCommandTests
    {
        SnakeSpeakCommand command;
        Snake player;
        string parameters = "Hello!";
        private void InitData()
        {
            player = new Snake();
            command = new SnakeSpeakCommand(player, parameters);
        }
        [StaFact]
        public void SnakeSpeakCommandTest()
        {
            InitData();
            Assert.IsType<SnakeSpeakCommand>(command);
        }

        [StaFact]
        public void ExecuteTest()
        {
            InitData();
            command.Execute();
            Assert.True(true);
        }

        [StaFact]
        public void UndoTest()
        {
            InitData();
            command.Execute();
            command.Undo();
            Assert.True(true);
        }
    }
}