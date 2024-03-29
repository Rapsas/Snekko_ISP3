﻿namespace Snakey.Command;

using Snakey.Models;

public class SnakeShrinkCommand : ICommand
{
    private Snake _receiver;
    public void Execute()
    {
        _receiver.Shrink();
    }

    public void Undo()
    {
        _receiver.Expand();
    }
    public SnakeShrinkCommand(Snake receiver)
    {
        _receiver = receiver;
    }
}
