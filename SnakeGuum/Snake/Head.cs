using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeGuum
{
    public class Head : SnakePart
    {
        public List<Body> bodies = new List<Body>();

        public Head()
        {
            Texture = GameContent.snakeHead;    // set texture as snakeHead
            Position = Globals.Center;  // set start position to center of screen
            Speed = 150f;   // 200 speed
            Size = new Vector2(32, 32); // size of the sprite/head  (pixels  32x32)

            Color = Color.DarkGreen;
        }


        public void AddBody()
        {
            SnakePart target;

            if(bodies.Count == 0)
                target = this;
            else
                target = bodies.Last();


            var body = new Body(target);

            body.Color = Color.ForestGreen;

            bodies.Add(body);
        }


        public override void Update(GameTime gt)
        {
            base.Update(gt);

            //  get delta time
            var delta = (float)gt.ElapsedGameTime.TotalSeconds;

            //  get direction towards mouse
            //  math magics
            var dir = Input.MousePos - Center;
            Direction = Vector2.Normalize(dir);
            Rotation = (float)Math.Atan2(dir.Y, dir.X) + (float)(Math.PI * 0.5f);

            //  move head towards mouse position
            Position += Speed * Direction * delta;

            //  increase speed as time goes (+1 speed / per second)
            Speed += delta;

            //  update all body parts in the List
            foreach(Body body in bodies)
            {
                body.Speed = Speed;
                body.Update(gt);
            }

        }


        public void Eat(Fruit fruit)
        {
            fruit.Eaten = true;
            AddBody();
        }


        public override void Draw(SpriteBatch batch)
        {
            base.Draw(batch);

            //  draw the body parts
            foreach(Body body in bodies)
            {
                body.Draw(batch);
            }

        }

    }
}
