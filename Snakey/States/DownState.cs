﻿namespace Snakey.States;

using Snakey.Config;
using Snakey.Models;

public class DownState : State
{
    public DownState(Snake player) : base(player) { }
    public override void Move()
    {
        this.Player.BodyParts.Enqueue(this.Player.HeadLocation);
        this.Player.HeadLocation += (0, Settings.CellSize);

        var lastPart = this.Player.BodyParts.Dequeue();
        this.Player.TailLocation = lastPart;
        this.Player.IsMovementLocked = false;
        this.Player.IgnoreBodyCollisionWithHead = false;
    }

    public override void SpeakDirection()
    {
        this.Player.HeadSpeak("🢃");
    }
}
