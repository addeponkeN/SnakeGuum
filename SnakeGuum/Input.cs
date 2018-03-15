using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SnakeGuum
{
    public static class Input
    {        
        //  keyboard & mouse input wrapper/helper class

        public static KeyboardState KeyState;
        public static MouseState MouseState;
        public static KeyboardState KeyStateOld;
        public static MouseState MouseStateOld;

        public static Vector2 MousePos => new Vector2(MouseState.X, MouseState.Y);
        static Vector2 OldMousePos => new Vector2(MouseStateOld.X, MouseStateOld.Y);

        public static void Update(GameTime gt)
        {
            KeyStateOld = KeyState;
            KeyState = Keyboard.GetState();

            MouseStateOld = MouseState;
            MouseState = Mouse.GetState();
        }

        public static bool AnyKeyDown => KeyState.GetPressedKeys().Length != 0;

        public static bool KeyClick(Keys key) => KeyState.IsKeyDown(key) && KeyStateOld.IsKeyUp(key);
        public static bool KeyRelease(Keys key) => KeyState.IsKeyUp(key) && KeyStateOld.IsKeyDown(key);
        public static bool KeyHold(Keys key) => KeyState.IsKeyDown(key);

        public static bool LeftClick => MouseState.LeftButton == ButtonState.Pressed && MouseStateOld.LeftButton == ButtonState.Released;
        public static bool LeftRelease => MouseState.LeftButton == ButtonState.Released && MouseStateOld.LeftButton == ButtonState.Pressed;
        public static bool LeftHold => MouseState.LeftButton == ButtonState.Pressed;

        public static bool RightClick => MouseState.RightButton == ButtonState.Pressed && MouseStateOld.RightButton == ButtonState.Released;
        public static bool RightRelease => MouseState.RightButton == ButtonState.Released && MouseStateOld.RightButton == ButtonState.Pressed;
        public static bool RightHold => MouseState.RightButton == ButtonState.Pressed;
    }
}
