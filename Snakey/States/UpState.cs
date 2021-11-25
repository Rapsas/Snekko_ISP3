using Snakey.Config;
using Snakey.Models;

namespace Snakey.States
{
    public class UpState : State
    {
        public UpState(Snake player) : base(player) { }
        public override void Move()
        {
            this.Player.BodyParts.Enqueue(this.Player.HeadLocation);
            this.Player.HeadLocation -= (0, Settings.CellSize);

            var lastPart = this.Player.BodyParts.Dequeue();
            this.Player.TailLocation = lastPart;
            this.Player.IsMovementLocked = false;
            this.Player.IgnoreBodyCollisionWithHead = false;
        }

        public override void SpeakDirection()
        {
            this.Player.HeadSpeak("🢁");
        }

        //public override bool TryToSwitchState(State state)
        //{
        //    if (state is DownState) return false;
        //    this.Player.CurrentMovementDirection = Common.Enums.MovementDirection.Up;
        //    this.Player.SwitchState(state);
        //    return true;

        //}
    }
}
