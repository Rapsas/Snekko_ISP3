﻿using Snakey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakey.Command
{
    class SnakeSpeakCommand : ICommand
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