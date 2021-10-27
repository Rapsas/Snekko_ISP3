namespace Common.Utility
{
    public struct Colors
    {
        public byte R { get; set; }
        public byte G { get; set; }
        public byte B { get; set; }

        public Colors(byte r, byte g, byte b)
        {
            R = r;
            G = g;
            B = b;
        }
    }
}
