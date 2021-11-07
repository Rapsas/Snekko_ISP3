using Xunit;
using Snakey.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snakey.Models;

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