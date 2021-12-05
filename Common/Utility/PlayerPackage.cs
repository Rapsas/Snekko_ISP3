using Common.Enums;
using System;
using System.Collections.Generic;

namespace Common.Utility
{
    public struct PlayerPackage : IEquatable<PlayerPackage>
    {
        public Vector2D SnakeHeadLocation { get; set; }
        public Vector2D SnakeTailLocation { get; set; }
        public MovementDirection SnakeMovementDirection { get; set; }
        public Queue<Vector2D> SnakeBodyLocation { get; set; }
        public Colors HeadColor { get; set; }
        public Colors BodyColor { get; set; }
        public Colors TailColor { get; set; }

        public override bool Equals(object obj)
        {
            return obj is PlayerPackage package && Equals(package);
        }

        public bool Equals(PlayerPackage other)
        {
            return SnakeHeadLocation.Equals(other.SnakeHeadLocation) &&
                   SnakeTailLocation.Equals(other.SnakeTailLocation) &&
                   SnakeMovementDirection == other.SnakeMovementDirection &&
                   SnakeBodyLocation.Equals(other.SnakeBodyLocation) &&
                   HeadColor.Equals(other.HeadColor) &&
                   BodyColor.Equals(other.BodyColor) &&
                   TailColor.Equals(other.TailColor);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(SnakeHeadLocation, SnakeTailLocation, SnakeMovementDirection, SnakeBodyLocation, HeadColor, BodyColor, TailColor);
        }

        public static bool operator ==(PlayerPackage left, PlayerPackage right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PlayerPackage left, PlayerPackage right)
        {
            return !(left == right);
        }
    }

}
