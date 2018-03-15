using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SnakeGuum
{
    public static class GameContent
    {
        public static Texture2D snakeHead;
        public static Texture2D snakeBody;

        public static void Load(ContentManager content)
        {
            snakeHead = content.Load<Texture2D>("snakehead");
            snakeBody = content.Load<Texture2D>("snakebody");
        }
    }
}
