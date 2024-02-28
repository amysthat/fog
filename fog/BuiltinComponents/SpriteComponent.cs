using fog.Assets;
using fog.Entities;
using fog.Memory;
using fog.Rendering;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace fog.BuiltinComponents
{
    public class SpriteComponent : Component
    {
        public Reference<Sprite> Sprite { get; set; }
        public float Scale { get; set; } = 1f;
        public bool IsHorizontallyFlipped { get; set; } = false;
        public Color Tint { get; set; } = Color.White;

        public override void OnDraw()
        {
            Graphics.DrawTexture(Sprite.Get().Texture!, entity.Get().Position, tint: Tint, scale: Scale, isFlipped: IsHorizontallyFlipped, rotation: 0);
        }
    }
}