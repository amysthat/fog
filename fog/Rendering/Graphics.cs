using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace fog.Rendering
{
    /// <summary>
    /// Combines both game and editor graphics calls into a single class.
    /// </summary>
    public static class Graphics
    {
        public delegate void DrawStringEventHandler(DrawStringEventArgs args);
        public delegate void DrawTextureEventHandler(DrawTextureEventArgs args);

        public static event DrawStringEventHandler DrawStringEvent;
        public static event DrawTextureEventHandler DrawTextureEvent;

        public static void DrawText(string text, int fontSize, System.Numerics.Vector2 position, Color? color = null)
        {
            DrawStringEvent.Invoke(new DrawStringEventArgs
            {
                Text = text,
                FontSize = fontSize,
                Position = position,
                Color = color
            });
        }

        public static void DrawTexture(Texture2D texture, Vector2 position, Color? tint = null, float scale = 1f, bool isFlipped = false, float rotation = 0f)
        {
            DrawTextureEvent.Invoke(new DrawTextureEventArgs
            {
                Texture = texture,
                Position = position,
                Tint = tint,
                Scale = scale,
                IsFlipped = isFlipped,
                Rotation = rotation,
            });
        }

        public class DrawStringEventArgs : EventArgs
        {
            public string Text { get; set; }
            public int FontSize { get; set; }
            public System.Numerics.Vector2 Position { get; set; }
            public Color? Color { get; set; }
        }

        public class DrawTextureEventArgs : EventArgs
        {
            public Texture2D Texture { get; set; }
            public Vector2 Position { get; set; }
            public Color? Tint { get; set; }
            public float Scale { get; set; }
            public bool IsFlipped { get; set; }
            public float Rotation { get; set; }
        }
    }
}