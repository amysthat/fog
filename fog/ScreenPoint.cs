namespace fog
{
    public struct ScreenPoint
    {
        public ScreenPoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; set; }
        public int Y { get; set; }

        public Vector2 ToVector2() => new Vector2(X, Y);

        internal static ScreenPoint FromXNA(Microsoft.Xna.Framework.Point point)
        {
            return new ScreenPoint(point.X, point.Y);
        }
    }
}
