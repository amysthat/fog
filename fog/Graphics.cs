using FontStashSharp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace fog
{
    public static class Graphics
    {
        private static SpriteBatch? spriteBatch;

        public static void Initialize(SpriteBatch _spriteBatch)
        {
            spriteBatch = _spriteBatch;

            Logging.Log("Initialized.");
        }

        public static void DrawText(string text, int fontSize, System.Numerics.Vector2 position, Color? color = null)
        {
            var textColor = color.HasValue ? color.Value : ProjectSettings.Active.DefaultTextColor;
            var font = fogEngine.DefaultFont.Get();

            spriteBatch!.DrawString(font.GetSize(fontSize), text, position, textColor);
        }

        public static void DrawTexture(Texture2D texture, Vector2 position, Color? tint = null, float scale = 1f, bool isFlipped = false, float rotation = 0f)
        {
            Color color = tint.HasValue ? tint.Value : Color.White;
            SpriteEffects spriteEffects = isFlipped ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

            spriteBatch!.Draw(texture,
                             position,
                             null,
                             color,
                             rotation,
                             texture.Bounds.Center.ToVector2(),
                             scale,
                             spriteEffects,
                             0);
        }
    }
}