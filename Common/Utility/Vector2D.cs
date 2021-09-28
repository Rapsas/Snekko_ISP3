using System;

namespace Common.Utility
{
    public struct Vector2D
    {
        public int X { get; set; } // Need to expose set; for SignalR to correctly serialize :(
        public int Y { get; set; }

        public Vector2D(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Vector2D operator +(Vector2D left, (int X, int Y) right)
        {
            return new Vector2D(left.X + right.X, left.Y + right.Y);
        }

        public static Vector2D operator -(Vector2D left, (int X, int Y) right)
        {
            return new Vector2D(left.X - right.X, left.Y - right.Y);
        }

        public bool IsOverlaping(Vector2D vector)
        {
            return vector.X == X && vector.Y == Y;
        }

        public override string ToString()
        {
            return $"{X}:{Y}";
        }
    }
}