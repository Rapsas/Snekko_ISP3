﻿namespace Snakey.Models;

using Common.Enums;
using Common.Utility;
using Snakey.Composite;
using Snakey.Managers;
using Snakey.Visitor;
using System.Windows.Controls;

// NOTE: this shit wont send through SignalR so we will need some sort of 
// new package to transfer type and location in rebuild the list it at the other end
// EDIT: thats what I did :^)
public abstract class Snack : IDrawableComponenet
{
    public virtual Vector2D Location { get; set; }
    public virtual bool WasConsumed { get; set; } = false;

    private EffectType _effectType;
    private FoodType _foodType;
    protected Canvas _gameArea = GameState.Instance.GameArea;
    protected Image _body;

    public virtual void SetTypesForServer(EffectType effectType, FoodType foodType)
    {
        _effectType = effectType;
        _foodType = foodType;
    }
    public virtual void Draw()
    {
        if (WasConsumed)
            return;
        _gameArea.Children.Add(_body);
        Canvas.SetLeft(_body, Location.X);
        Canvas.SetTop(_body, Location.Y);
    }
    public virtual SnackPackage SnackPackage()
    {
        return new SnackPackage()
        {
            Location = Location,
            EffectType = _effectType,
            FoodType = _foodType,
            WasConsumed = WasConsumed
        };
    }
    public abstract void TriggerEffect();

    public virtual Snack GetBaseType() => this;

    public virtual void Accept(IVisitor visitor) { }
}
