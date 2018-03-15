using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeGuum
{
    public static class Globals
    {
        //  global settings

        public static int ScreenWidth = 1280;
        public static int ScreenHeight = 720;

        //  center point of the screen
        public static Vector2 Center => new Vector2(ScreenWidth / 2, ScreenHeight / 2);

        //  etc..
        //public static float Volume = 1f;
    }

    public static class Rng
    {
        static Random rnd = new Random();

        /// <summary>
        /// get random number between min(included) & max(excluded)
        /// </summary>
        public static int Range(int min, int max)
        {
            return rnd.Next(min, max);
        }
    }

}
