﻿namespace Snakey.Snacks;

using Snakey.Models;
using Snakey.Visitor;
using System;
using System.Windows.Media;

public abstract class MysterySnack : Snack
{
    protected SolidColorBrush Stroke = Brushes.Blue;
    protected double StrokeThickness = 5;
    public Random rnd;
    public MysterySnack()
    {
        WasConsumed = false;
        rnd = new Random();
    }
    public abstract MysterySnack Clone();
    public abstract MysterySnack DeepClone();
    public override void TriggerEffect() { }
    public override void Accept(IVisitor visitor) { }
}
