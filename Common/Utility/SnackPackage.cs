using System;
using System.Collections.Generic;
using Common.Enums;

namespace Common.Utility
{
    public struct SnackPackage : IEquatable<SnackPackage>

    {
        public Vector2D Location { get; set; }
        public FoodType FoodType { get; set; }
        public EffectType EffectType { get; set; }
        public bool WasConsumed { get; set; }

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
