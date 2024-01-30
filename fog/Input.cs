using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using _Keyboard = Microsoft.Xna.Framework.Input.Keyboard;

namespace fog
{
    /// <summary>
    /// Unfinished.
    /// </summary>
    public static class Input
    {
        /// <summary>
        /// Unfinished.
        /// </summary>
        public static class Keyboard
        {
            public static bool IsKeyDown(Keys key) => _Keyboard.GetState().IsKeyDown(key);
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