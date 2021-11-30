using Snakey.Config;
using Snakey.Models;
using System.Diagnostics.CodeAnalysis;

namespace Snakey.States
{
    public class RightState : State
    {
        [SuppressMessage("NDepend", "ND1400:AvoidNamespacesMutuallyDependent", Justification = "...")]
        public RightState(Snake player) : base(player) { }
        [SuppressMessage("NDepend", "ND1400:AvoidNamespacesMutuallyDependent", Justification = "...")]
        public override void Move()
        {
            this.Player.BodyParts.Enqueue(this.Player.HeadLocation);
            this.Player.HeadLocation += (Settings.CellSize, 0);

            var lastPart = this.Player.BodyParts.Dequeue();
            this.Player.TailLocation = lastPart;
            this.Player.IsMovementLocked = false;
            this.Player.IgnoreBodyCollisionWithHead = false;
        }
        [SuppressMessage("NDepend", "ND1400:AvoidNamespacesMutuallyDependent", Justification = "...")]
        public override void SpeakDirection()
        {
            this.Player.HeadSpeak("🢂");
        }

        //public override bool TryToSwitchState(State state)
        //{
        //    if (state is LeftState) return false;
        //    this.Player.CurrentMovementDirection = Common.Enums.MovementDirection.Right;
        //    this.Player.SwitchState(state);
        //    return true;

        //}
    }
}
