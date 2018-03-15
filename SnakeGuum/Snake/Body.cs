using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace SnakeGuum
{
    public class Body : SnakePart
    {
        public Sprite FollowTarget;

        public Body(Sprite toFollow)
        {
            Texture = GameContent.snakeBody;

            FollowTarget = toFollow;
            Position = FollowTarget.Position;

            Speed = 150f;
            Size = new Vector2(32, 32);
        }

        public override void Update(GameTime gt)
        {
            base.Update(gt);

            var distance = Vector2.Distance(FollowTarget.Center, Center);

            //  move towards FollowTarget if the distance between them is > 30 (pixels)
            if(distance > 30)
            {
                //  get delta time
                float delta = (float)gt.ElapsedGameTime.TotalSeconds;

                //  get direction to FollowTargets center
                var dir = FollowTarget.Center - Center;
                Direction = Vector2.Normalize(dir);
                Rotation = (float)Math.Atan2(dir.Y, dir.X) + (float)(Math.PI * 0.5f);

                Position += Speed * Direction * delta;
            }

        }

        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);
        }
    }
}
