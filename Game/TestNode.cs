using fog;
using fog.BuiltinNodes;
using fog.Nodes;
using Microsoft.Xna.Framework.Input;
using System.Numerics;

namespace Game
{
    public class TestNode : Node
    {
        public override void OnUpdate()
        {
            if (Input.Mouse.IsMouseDown(MouseButton.Left))
                Position = Input.Mouse.ScreenPosition.ToVector2();

            if (Input.Keyboard.IsKeyIncoming(Keys.Space))
            {
                ((SpriteNode)Children[0].Get()).IsHorizontallyFlipped = !((SpriteNode)Children[0].Get()).IsHorizontallyFlipped;
            }

            if (Input.Keyboard.IsKeyIncoming(Keys.F11))
            {
                ProjectSettings.Active.Resolution = new Resolution
                {
                    Width = ProjectSettings.Active.Resolution.Width,
                    Height = ProjectSettings.Active.Resolution.Height,
                    Fullscreen = !ProjectSettings.Active.Resolution.Fullscreen,
                };
            }
        }

        private static Vector2 TextOffset = new Vector2(15, 15);

        public override void OnDraw()
        {
            Graphics.DrawText("Test text, if you see this, hooraayy!", 20, TextOffset);
            Graphics.DrawText("Delta time: " + fog.fog.DeltaTime, 15, TextOffset + new Vector2(0, 20));
            Graphics.DrawText("Total time: " + fog.fog.TotalTime, 15, TextOffset + new Vector2(0, 35));
        }
    }
}