using Snakey.Models;
using System.Diagnostics.CodeAnalysis;

namespace Snakey.States
{
    [SuppressMessage("NDepend", "ND1400:AvoidNamespacesMutuallyDependent", Justification = "...")]
    public abstract class State
    {
        private Snake player;
        public State(Snake player)
        {
            Player = player;
        }

        protected Snake Player { get => player; set => player = value; }

        [SuppressMessage("NDepend", "ND1400:AvoidNamespacesMutuallyDependent", Justification = "...")]
        public abstract void Move();
        [SuppressMessage("NDepend", "ND1400:AvoidNamespacesMutuallyDependent", Justification = "...")]
        public abstract void SpeakDirection();
        //public abstract bool TryToSwitchState(State state);
    }
}
