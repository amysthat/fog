using FontStashSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using static fog.Rendering.Graphics;

namespace fog.Rendering
{
    internal static class RuntimeGraphics
    {
        private static SpriteBatch spriteBatch;

        public static void Initialize(SpriteBatch _spriteBatch)
        {
            spriteBatch = _spriteBatch;

            DrawStringEvent += DrawText;
            DrawTextureEvent += DrawTexture;

            Logging.Log("Initialized.");
        }

        private static void DrawText(DrawStringEventArgs args)
        {
            Color color = args.Color.HasValue ? args.Color.Value : ProjectSettings.Active.DefaultTextColor;
            spriteBatch.DrawString(fogEngine.DefaultFont.GetFont(args.FontSize), args.Text, args.Position, color);
        }

        private static void DrawTexture(DrawTextureEventArgs args)
        {
            Color color = args.Tint.HasValue ? args.Tint.Value : Color.White;
            SpriteEffects spriteEffects = args.IsFlipped ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

            spriteBatch.Draw(args.Texture,
                             args.Position,
                             null,
                             color,
                             args.Rotation,
                             args.Texture.Bounds.Center.ToVector2(),
                             args.Scale,
                             spriteEffects,
                             0);
        }
    }
}