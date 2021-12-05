﻿using Common.Enums;
using Common.Utility;
using Snakey.Composite;
using Snakey.Managers;
using Snakey.Visitor;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Controls;

namespace Snakey.Models
{
    // NOTE: this shit wont send through SignalR so we will need some sort of 
    // new package to transfer type and location in rebuild the list it at the other end
    [SuppressMessage("NDepend", "ND1400:AvoidNamespacesMutuallyDependent", Justification = "...")]
    public abstract class Snack : IDrawableComponenet
    {
        public virtual Vector2D Location { get; set; }
        public virtual bool WasConsumed { get; set; } = false;
        protected Canvas GameArea { get => _gameArea; set => _gameArea = value; }
        protected Image Body { get => _body; set => _body = value; }

        private EffectType _effectType;
        private FoodType _foodType;
        private Canvas _gameArea = GameState.Instance.GameArea;
        private Image _body;

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
            return new SnackPackage(
                Location,
                _foodType,
                _effectType,
                WasConsumed
            );
        }
        public abstract void TriggerEffect();

        public virtual Snack GetBaseType()
        {
            return this;
        }

        public virtual void Accept(IVisitor visitor) { }
    }
}
