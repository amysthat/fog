using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using _Keyboard = Microsoft.Xna.Framework.Input.Keyboard;
using _Mouse = Microsoft.Xna.Framework.Input.Mouse;

namespace fog
{
    /// <summary>
    /// Unfinished.
    /// </summary>
    public static class Input
    {
        internal static void Update()
        {
            Keyboard.Update();
            Mouse.Update();
        }

        public static class Keyboard
        {
            private static Keys[] prev_keys = new Keys[0];
            private static Keys[] keys = new Keys[0];

            private static List<Keys> incomingKeys = new();
            private static List<Keys> outgoingKeys = new();

            internal static void Update()
            {
                prev_keys = keys;
                keys = _Keyboard.GetState().GetPressedKeys();

                incomingKeys.Clear();
                outgoingKeys.Clear();

                foreach (var key in keys)
                {
                    if (!prev_keys.Contains(key))
                        incomingKeys.Add(key);
                }

                foreach (var key in prev_keys)
                {
                    if (!keys.Contains(key))
                        outgoingKeys.Add(key);
                }
            }

            public static bool IsKeyIncoming(Keys key) => incomingKeys.Contains(key);
            public static bool IsKeyStaying(Keys key) => keys.Contains(key);
            public static bool IsKeyOutgoing(Keys key) => outgoingKeys.Contains(key);
        }

        public static class Mouse
        {
            private static MouseState prev_state;
            private static MouseState state;

            internal static void Update()
            {
                prev_state = state;
                state = _Mouse.GetState();
            }

            public static bool IsMouseButtonIncoming(MouseButton button)
            {
                return button switch
                {
                    MouseButton.Left => state.LeftButton == ButtonState.Pressed && prev_state.LeftButton == ButtonState.Released,
                    MouseButton.Middle => state.MiddleButton == ButtonState.Pressed && prev_state.LeftButton == ButtonState.Released,
                    MouseButton.Right => state.RightButton == ButtonState.Pressed && prev_state.LeftButton == ButtonState.Released,
                    _ => throw new InvalidProgramException(),
                };
            }

            public static bool IsMouseButtonOutcoming(MouseButton button)
            {
                return button switch
                {
                    MouseButton.Left => state.LeftButton == ButtonState.Released && prev_state.LeftButton == ButtonState.Pressed,
                    MouseButton.Middle => state.MiddleButton == ButtonState.Released && prev_state.LeftButton == ButtonState.Pressed,
                    MouseButton.Right => state.RightButton == ButtonState.Released && prev_state.LeftButton == ButtonState.Pressed,
                    _ => throw new InvalidProgramException(),
                };
            }

            public static bool IsMouseButtonStaying(MouseButton button)
            {
                return button switch
                {
                    MouseButton.Left => state.LeftButton == ButtonState.Pressed,
                    MouseButton.Middle => state.MiddleButton == ButtonState.Pressed,
                    MouseButton.Right => state.RightButton == ButtonState.Pressed,
                    _ => throw new InvalidProgramException(),
                };
            }

            public static ScreenPoint Position => ScreenPoint.FromXNA(state.Position);
        }
    }

    public enum MouseButton
    {
        Left,
        Middle,
        Right,
    }
}