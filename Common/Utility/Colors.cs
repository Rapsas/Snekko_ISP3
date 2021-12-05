using System;

namespace Common.Utility
{
    public readonly struct Colors : IEquatable<Colors>
    {
        public byte R { get; }
        public byte G { get; }
        public byte B { get; }

        public Colors(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }

        public override bool Equals(object obj)
        {
            Colors other = (Colors)obj;
            return R == other.R
                    && G == other.G
                    && B == other.B;
        }

        public bool Equals(Colors other)
        {
            return R == other.R &&
                   G == other.G &&
                   B == other.B;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(R, G, B);
        }

        public static bool operator ==(Colors left, Colors right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Colors left, Colors right)
        {
            return !(left == right);
        }
    }
}
