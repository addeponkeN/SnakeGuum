using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace SnakeGuum
{
    public class Game1 : Game
    {

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //  define the player
        public Head Player;

        public List<Fruit> fruits = new List<Fruit>();
        public float FruitSpawnTimer = 0f;
        

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //  resolution
            graphics.PreferredBackBufferWidth = Globals.ScreenWidth;
            graphics.PreferredBackBufferHeight = Globals.ScreenHeight;

            //  show the mouse/cursor
            this.IsMouseVisible = true;

        }



        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here



            base.Initialize();
        }


        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            GameContent.Load(Content);


            Player = new Head();

            //  add 3 body parts to start with
            for(int i = 0; i < 3; i++)
            {
                Player.AddBody();
            }

            //  spawn a fruit to start with
            SpawnFruit();

        }




        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // Unload any non ContentManager content here

        }




        //  update stuff in here
        protected override void Update(GameTime gameTime)
        {
            if(GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //  update the input wrapper class
            Input.Update(gameTime);


            //  update the player (head)
            Player.Update(gameTime);

            foreach(Fruit fruit in fruits)
            {
                fruit.CheckIfPlayerIsClose(Player);
            }

            //  remove all eaten fruits from list
            fruits.RemoveAll(x => x.Eaten);

            var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

            FruitSpawnTimer += delta;

            if(FruitSpawnTimer > 4)
            {
                SpawnFruit();
                FruitSpawnTimer = 0;
            }


            base.Update(gameTime);
        }

        void SpawnFruit()
        {
            //  get random fruit type
            var fruitType = (FruitType)Rng.Range(0, 3);

            var fruit = new Fruit(fruitType);

            //  randomize position
            int x = Rng.Range(0, Globals.ScreenWidth);  // 0 to width of the screen
            int y = Rng.Range(0, Globals.ScreenHeight); // 0 to height of the screen
            fruit.Position = new Vector2(x, y);

            fruits.Add(fruit);
        }


        //  draw stuff in here
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //  begin drawing
            spriteBatch.Begin();

            //  draw the player
            Player.Draw(spriteBatch);

            //  draw all fruit
            foreach(Fruit fruit in fruits)
            {
                fruit.Draw(spriteBatch);
            }


            //  end drawing
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
