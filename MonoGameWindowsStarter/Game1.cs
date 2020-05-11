using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MonoGameWindowsStarter
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Player player;
        Walls walls;

        BoundingRectangle goal;
        Texture2D goalText;

        SpriteFont font;
        //Hub hub;
        //Foutain fountain;

        //Fire fire;

        // map and map renderer
        //private TiledMap map;
        //private TiledMapRenderer mapRenderer;

        public Game1()
        {
            Content.RootDirectory = "Content";
            graphics = new GraphicsDeviceManager(this);

            player = new Player(this);
            walls = new Walls(this);
            //hub = new Hub(this);
            //fountain = new Foutain(this);

            //fire = new Fire(this, new Vector2(750, 750), 50, 75, 15, 16, 0.40f);
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
            graphics.PreferredBackBufferWidth = 1500;
            graphics.PreferredBackBufferHeight = 900;
            graphics.ApplyChanges();

            player.Initialize();
            walls.Initialize();
            //hub.Initialize();
            player.Bounds.X = 75;
            player.Bounds.Y = 75;

            goal.Width = 120;
            goal.Height = 120;
            goal.X = walls.WallE.X - goal.Width;
            goal.Y = walls.WallS.Y - goal.Height;
            //fountain.Initialize();

            //fire.Initialize();

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

            // TODO: use this.Content to load your game content here

            // load and initialize map and mapRenderer
            //map = Content.Load<TiledMap>("overworld");
            //mapRenderer = new TiledMapRenderer(GraphicsDevice);

            player.LoadContent(Content);
            walls.LoadContent(Content);
            font = Content.Load<SpriteFont>("Calibri");
            goalText = Content.Load<Texture2D>("pixel");

            //hub.LoadContent(Content);
            //fountain.LoadContent(Content);

            //fire.LoadContent(Content);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            player.Update(gameTime);
            walls.Update(gameTime);

            if ((player.Bounds.CollidesWith(walls.WallN))
                || (player.Bounds.CollidesWith(walls.WallS))
                || (player.Bounds.CollidesWith(walls.WallE))
                || (player.Bounds.CollidesWith(walls.WallW))
                || (player.Bounds.CollidesWith(walls.MazeWall01))
                || (player.Bounds.CollidesWith(walls.MazeWall02)))
            {
                player.playerSpeed *= 0;
                player.gameState = GameState.Over;
            }

            if(player.Bounds.CollidesWith(goal))
            {
                player.gameState = GameState.Win;
            }

            /*
            //Collision with World Borders
            if (player.Bounds.X < walls.WallW.X + walls.WallW.Width)
            {
                player.Bounds.X = walls.WallW.X + walls.WallW.Width;
            }
            if (player.Bounds.X + player.Bounds.Width > walls.WallE.X)
            {
                player.Bounds.X = walls.WallE.X - player.Bounds.Width;
            }
            if (player.Bounds.Y < walls.WallN.Y + walls.WallN.Height)
            {
                player.Bounds.Y = walls.WallN.Y + walls.WallN.Height;
            }
            if (player.Bounds.Y + player.Bounds.Height > walls.WallS.Y)
            {
                player.Bounds.Y = walls.WallS.Y - player.Bounds.Height;
            }
            
            //player collision with hub objects
            if(player.Bounds.CollidesWith(hub.CabinBounds))
            {
                if(player.Bounds.X + player.Bounds.Width > hub.CabinBounds.X)
                {
                    player.Bounds.X = hub.CabinBounds.X - player.Bounds.Width - 1;
                }
                else if (player.Bounds.X < hub.CabinBounds.X + hub.CabinBounds.Width)
                {
                    player.Bounds.X = hub.CabinBounds.X + hub.CabinBounds.Width + 1;
                }
                else if (player.Bounds.Y + player.Bounds.Height > hub.CabinBounds.Y)
                {
                    player.Bounds.Y = hub.CabinBounds.Y - player.Bounds.Height - 1;
                }
                else if (player.Bounds.Y < hub.CabinBounds.Y + hub.CabinBounds.Height)
                {
                    player.Bounds.Y = hub.CabinBounds.Y + hub.CabinBounds.Height + 1;
                }
            }
            */


            //update mapRenderer
            //mapRenderer.Update(gameTime);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            var offset = new Vector2(750,500);
            offset.X -= player.Bounds.X;
            offset.Y -= player.Bounds.Y;
            var tMatrix = Matrix.CreateTranslation(offset.X, offset.Y, 0);

            // TODO: Add your drawing code here
            //mapRenderer.LoadMap(map);
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, tMatrix);
            
            player.Draw(spriteBatch);
            walls.Draw(spriteBatch);
            spriteBatch.Draw(goalText, goal, Color.ForestGreen);

            var textOffset1 = offset * -1;
            textOffset1.X += 5;
            textOffset1.Y += 5;
            var textOffset2 = offset * -1;
            textOffset2.X += 5;
            textOffset2.Y += 35;

            spriteBatch.DrawString(font, "Reach the goal in the bottom-right corner", textOffset1, Color.White);
            spriteBatch.DrawString(font, "Don't touch the walls", textOffset2, Color.White);

            if (player.gameState == GameState.Over)
            {
                var textOffsetGameOver = offset * -1;
                textOffsetGameOver.X += 750;
                textOffsetGameOver.Y += 500;
                spriteBatch.DrawString(font, "Game Over", textOffsetGameOver, Color.White);
            }
            if (player.gameState == GameState.Win)
            {
                var textOffsetWin = offset * -1;
                textOffsetWin.X += 750;
                textOffsetWin.Y += 500;
                spriteBatch.DrawString(font, "You Win", textOffsetWin, Color.White);
            }

            //hub.Draw(spriteBatch);
            //fountain.Draw(spriteBatch);

            //fire.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}