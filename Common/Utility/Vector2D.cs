namespace Common.Utility
{
    public class Vector2D
    {
        public int X { get; }
        public int Y { get; }

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
    }
}