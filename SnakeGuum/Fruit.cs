using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGuum
{
    public enum FruitType
    {
        Apple,
        Orange,
        Banana,
    }

    public class Fruit : Sprite
    {
        public FruitType fruitType;
        public bool Eaten = false;

        public Fruit(FruitType type)
        {
            fruitType = type;

            Texture = GameContent.snakeBody;
            Size = new Vector2(16, 16);

            switch(fruitType)
            {
                case FruitType.Apple:
                    Color = Color.LawnGreen;
                    break;

                case FruitType.Orange:
                    Color = Color.Orange;
                    break;

                case FruitType.Banana:
                    Color = Color.Yellow;
                    break;
            }

        }


        public void CheckIfPlayerIsClose(Head player)
        {

            if(player.Rectangle.Intersects(Rectangle))
            {
                player.Eat(this);
            }

        }


    }
}
