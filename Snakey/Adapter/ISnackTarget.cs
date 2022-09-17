namespace Snakey.Adapter;
using Common.Utility;
using System;

public interface ISnackTarget
{
    public Vector2D Location { get; set; }
    public bool WasConsumed { get; set; }

    public SnackPackage SnackPackage();
    public Type GetSnackType();
    public void TriggerEffect();
}
