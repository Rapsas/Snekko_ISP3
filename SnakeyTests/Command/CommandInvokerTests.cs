using Snakey.Models;
using System.Linq;
using Xunit;

namespace Snakey.Command.Tests
{
    public class CommandInvokerTests
    {
        SnakeShrinkCommand command;
        CommandInvoker invoker;
        Snake player;
        private void InitData()
        {
            player = new Snake();
            for (int i = 0; i < 3; i++)
            {
                player.Expand();
            }
            command = new SnakeShrinkCommand(player);
            invoker = new CommandInvoker();
        }
        [StaFact]
        public void SetCommandTest()
        {
            this.InitData();
            var result = invoker.SetCommand(command);
            Assert.Equal(command, result);
        }

        [StaFact]
        public void ExecuteCommandTest()
        {
            this.InitData();
            invoker.SetCommand(command);
            int previousLenght = player.BodyParts.Count();
            invoker.ExecuteCommand();
            Assert.True(previousLenght == player.BodyParts.Count() + 1);
        }

        [StaFact]
        public void UndoCommandTest()
        {
            this.InitData();
            invoker.SetCommand(command);
            int previousLenght = player.BodyParts.Count();
            invoker.ExecuteCommand();
            invoker.UndoCommand();
            Assert.True(previousLenght == player.BodyParts.Count());
        }
    }
}