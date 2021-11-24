using Snakey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakey.States
{
    public abstract class State
    {
        protected Snake Player;
        public  State(Snake player)
        {
            Player = player;
        }

        public abstract void Move();
        public abstract void SpeakDirection();
        //public abstract bool TryToSwitchState(State state);
    }
}
