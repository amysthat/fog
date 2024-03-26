using fog;
using fog.BuiltinComponents;
using fog.Entities;
using Microsoft.Xna.Framework.Input;

namespace Game
{
    public class TestComponent : Component
    {
        public override void OnUpdate()
        {
            if (Input.Mouse.IsMouseButtonStaying(MouseButton.Left))
                entity.Get().Position = Input.Mouse.Position.ToVector2();

            if (Input.Keyboard.IsKeyIncoming(Keys.Space))
            {
                entity.Get().GetComponent<SpriteComponent>().IsHorizontallyFlipped = !entity.Get().GetComponent<SpriteComponent>().IsHorizontallyFlipped;
            }

            if (Input.Keyboard.IsKeyIncoming(Keys.Escape))
            {
                fogEngine.Quit();
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

            if (Input.Keyboard.IsKeyIncoming(Keys.Delete))
            {
                throw new Exception("User initiated crash.");
            }
        }

        private static Vector2 TextOffset = new Vector2(15, 15);

        public override void OnDraw()
        {
            Graphics.DrawText("Test text, if you see this, hooraayy!", 20, TextOffset);
            Graphics.DrawText("Delta time: " + fogEngine.DeltaTime, 15, TextOffset + new Vector2(0, 20));
            Graphics.DrawText("Total time: " + fogEngine.TotalTime, 15, TextOffset + new Vector2(0, 35));
            Graphics.DrawText("Press DEL to crash.", 15, TextOffset + new Vector2(0, 50), Microsoft.Xna.Framework.Color.Red);
        }
    }
}