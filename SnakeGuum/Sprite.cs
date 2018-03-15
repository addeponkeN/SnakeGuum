using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SnakeGuum
{
    public class Sprite
    {
        public Texture2D Texture;
        public Vector2 Position;
        public Vector2 Size;

        public Rectangle Rectangle => new Rectangle((int)Position.X, (int)Position.Y, (int)Size.X, (int)Size.Y);

        //  Center point of the sprite
        public Vector2 Center => new Vector2((int)Position.X + (Size.X / 2), (int)Position.Y + (Size.Y / 2));

        public Color Color;

        public float Rotation = 0f;

        public virtual void Update(GameTime gt)
        {
        }

        public virtual void Draw(SpriteBatch batch)
        {
            //  Draw to screen
            batch.Draw(Texture, Rectangle, null, Color, Rotation, Size * 0.5f, SpriteEffects.None, 0.5f);
        }
    }
}
