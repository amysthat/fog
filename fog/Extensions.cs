using Microsoft.Xna.Framework;

namespace fog
{
    public static class Extensions
    {
        //public static Microsoft.Xna.Framework.Color ToXNA(this System.Drawing.Color color) => new Microsoft.Xna.Framework.Color
        //{
        //    R = color.R,
        //    G = color.G,
        //    B = color.B,
        //    A = color.A
        //};

        public static System.Numerics.Vector2 ToVector2(this Point point) => new System.Numerics.Vector2
        {
            X = point.X,
            Y = point.Y,
        };
    }
}
