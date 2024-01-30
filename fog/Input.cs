using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using _Keyboard = Microsoft.Xna.Framework.Input.Keyboard;

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

        /// <summary>
        /// Unfinished.
        /// </summary>
        public static class Mouse
        {
            public static bool IsMouseDown(MouseButton button)
            {
                MouseState state = Microsoft.Xna.Framework.Input.Mouse.GetState();

                switch (button)
                {
                    case MouseButton.Left:
                        return state.LeftButton == ButtonState.Pressed;
                    case MouseButton.Right:
                        return state.RightButton == ButtonState.Pressed;
                    case MouseButton.Middle:
                        return state.MiddleButton == ButtonState.Pressed;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(button));
                }
            }

            public static bool IsMouseUp(MouseButton button)
            {
                MouseState state = Microsoft.Xna.Framework.Input.Mouse.GetState();

                switch (button)
                {
                    case MouseButton.Left:
                        return state.LeftButton == ButtonState.Released;
                    case MouseButton.Right:
                        return state.RightButton == ButtonState.Released;
                    case MouseButton.Middle:
                        return state.MiddleButton == ButtonState.Released;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(button));
                }
            }

            public static Point ScreenPosition
            {
                get
                {
                    MouseState state = Microsoft.Xna.Framework.Input.Mouse.GetState();

                    return new Point(state.X, state.Y);
                }
            }
        }
    }

    public enum MouseButton
    {
        Left,
        Middle,
        Right,
    }
}