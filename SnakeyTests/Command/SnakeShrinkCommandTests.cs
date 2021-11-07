using Snakey.Models;
using System.Linq;
using Xunit;

namespace Snakey.Command.Tests
{
    public class SnakeShrinkCommandTests
    {
        SnakeShrinkCommand command;
        Snake player;

        private void InitData()
        {
            player = new Snake();
            for (int i = 0; i < 3; i++)
            {
                player.Expand();
            }
            command = new SnakeShrinkCommand(player);
        }
        [StaFact]
        public void ExecuteTest()
        {
            InitData();
            var lenghtBeforeShrink = player.BodyParts.Count();
            command.Execute();
            Assert.True(lenghtBeforeShrink == player.BodyParts.Count() + 1);
        }

        [StaFact]
        public void UndoTest()
        {
            InitData();
            var lenghtBeforeShrink = player.BodyParts.Count();
            command.Execute();
            command.Undo();
            Assert.True(lenghtBeforeShrink == player.BodyParts.Count());
        }

        [StaFact]
        public void SnakeShrinkCommandTest()
        {
            var result = new SnakeShrinkCommand(new Snake());
            Assert.IsType<SnakeShrinkCommand>(result);
        }
    }
}