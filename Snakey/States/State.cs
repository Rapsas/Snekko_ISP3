namespace Snakey.States;

using Snakey.Models;

public abstract class State
{
    protected Snake Player;
    public State(Snake player)
    {
        Player = player;
    }

    public abstract void Move();
    public abstract void SpeakDirection();
}
