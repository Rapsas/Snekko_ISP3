using Snakey.Models;
using System.Diagnostics.CodeAnalysis;

namespace Snakey.States
{
    [SuppressMessage("NDepend", "ND1400:AvoidNamespacesMutuallyDependent", Justification = "...")]
    public abstract class State
    {
        protected Snake Player;
        public State(Snake player)
        {
            Player = player;
        }
        [SuppressMessage("NDepend", "ND1400:AvoidNamespacesMutuallyDependent", Justification = "...")]
        public abstract void Move();
        [SuppressMessage("NDepend", "ND1400:AvoidNamespacesMutuallyDependent", Justification = "...")]
        public abstract void SpeakDirection();
        //public abstract bool TryToSwitchState(State state);
    }
}
