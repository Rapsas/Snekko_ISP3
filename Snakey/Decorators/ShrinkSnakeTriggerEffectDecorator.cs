﻿namespace Snakey.Decorators;

using Snakey.Command;
using Snakey.Managers;
using Snakey.Models;
using System;
using System.Windows.Threading;

public class ShrinkSnakeTriggerEffectDecorator : TriggerEffectDecorator
{
    private readonly CommandInvoker invoker;
    public ShrinkSnakeTriggerEffectDecorator(Snack snack)
        : base(snack)
    {
        invoker = new CommandInvoker();
        invoker.SetCommand(new SnakeShrinkCommand(GameState.Instance.Player));
    }

    public override void TriggerEffect()
    {
        invoker.ExecuteCommand();
        invoker.SetCommand(new SnakeSpeakCommand(GameState.Instance.Player, "OUCH!"));
        invoker.ExecuteCommand();
        Action a = () => invoker.UndoCommand();
        DelayAction(1000, a);
        base.TriggerEffect();
    }
    private static void DelayAction(int millisecond, Action action)
    {
        var timer = new DispatcherTimer();
        timer.Tick += delegate

        {
            action.Invoke();
            timer.Stop();
        };

        timer.Interval = TimeSpan.FromMilliseconds(millisecond);
        timer.Start();
    }
}
