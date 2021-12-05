using System;
using System.Collections.Generic;
using Common.Enums;

namespace Common.Utility
{
    public readonly struct SnackPackage : IEquatable<SnackPackage>

    {
        public SnackPackage(Vector2D location, FoodType foodType, EffectType effectType, bool wasConsumed)
        {
            Location = location;
            FoodType = foodType;
            EffectType = effectType;
            WasConsumed = wasConsumed;
        }

        public Vector2D Location { get; }
        public FoodType FoodType { get; }
        public EffectType EffectType { get;}
        public bool WasConsumed { get; }

        public override bool Equals(object obj)
        {
            return obj is SnackPackage package && Equals(package);
        }

        public bool Equals(SnackPackage other)
        {
            return Location.Equals(other.Location)
                    && FoodType == other.FoodType
                    && EffectType == other.EffectType
                    && WasConsumed == other.WasConsumed;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Location, FoodType, EffectType, WasConsumed);
        }

        public static bool operator ==(SnackPackage left, SnackPackage right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SnackPackage left, SnackPackage right)
        {
            return !(left == right);
        }
    }
}
