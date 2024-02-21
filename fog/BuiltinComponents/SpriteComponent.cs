using fog.Assets;
using fog.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace fog.BuiltinComponents
{
    public class SpriteComponent : Component
    {
        public AssetRef Sprite { get; set; }
        public float Scale { get; set; } = 1f;
        public bool IsHorizontallyFlipped { get; set; } = false;
        public Color Tint { get; set; } = Color.White;

        public override void OnDraw()
        {
            if (Sprite.IsPointing())
            {
                Graphics.DrawTexture(Sprite.Get<Texture2D>(), entity.Get().Position, tint: Tint, scale: Scale, isFlipped: IsHorizontallyFlipped, rotation: 0);
            }
        }
    }
}