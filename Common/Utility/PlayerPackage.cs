using Common.Enums;
using System;
using System.Collections.Generic;

namespace Common.Utility
{
    public readonly struct PlayerPackage : IEquatable<PlayerPackage>
    {
        public PlayerPackage(Vector2D snakeHeadLocation, Vector2D snakeTailLocation, MovementDirection snakeMovementDirection, Queue<Vector2D> snakeBodyLocation, Colors headColor, Colors bodyColor, Colors tailColor)
        {
            SnakeHeadLocation = snakeHeadLocation;
            SnakeTailLocation = snakeTailLocation;
            SnakeMovementDirection = snakeMovementDirection;
            SnakeBodyLocation = snakeBodyLocation;
            HeadColor = headColor;
            BodyColor = bodyColor;
            TailColor = tailColor;
        }

        public Vector2D SnakeHeadLocation { get; }
        public Vector2D SnakeTailLocation { get; }
        public MovementDirection SnakeMovementDirection { get; }
        public Queue<Vector2D> SnakeBodyLocation { get; }
        public Colors HeadColor { get; }
        public Colors BodyColor { get; }
        public Colors TailColor { get; }

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
