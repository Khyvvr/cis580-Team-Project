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
        Hub hub;

        Fire fire;

        // map and map renderer
        //private TiledMap map;
        //private TiledMapRenderer mapRenderer;

        public Game1()
        {
            Content.RootDirectory = "Content";
            graphics = new GraphicsDeviceManager(this);

            player = new Player(this);
            walls = new Walls(this);
            hub = new Hub(this);

            fire = new Fire(this, new Vector2(750, 750), 50, 75, 15, 16, 0.40f);
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
            hub.Initialize();
            player.Bounds.X = hub.PlayerSpawn.X;
            player.Bounds.Y = hub.PlayerSpawn.Y;

            fire.Initialize();

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
            hub.LoadContent(Content);

            fire.LoadContent(Content);
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
                    player.Bounds.X = hub.CabinBounds.X - player.Bounds.Width;
                }
                else if (player.Bounds.X < hub.CabinBounds.X + hub.CabinBounds.Width)
                {
                    player.Bounds.X = hub.CabinBounds.X + hub.CabinBounds.Width;
                }
                else if (player.Bounds.Y + player.Bounds.Height > hub.CabinBounds.Y)
                {
                    player.Bounds.Y = hub.CabinBounds.Y - player.Bounds.Height;
                }
                else if (player.Bounds.Y < hub.CabinBounds.Y + hub.CabinBounds.Height)
                {
                    player.Bounds.Y = hub.CabinBounds.Y + hub.CabinBounds.Height;
                }
            }



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
            GraphicsDevice.Clear(Color.LimeGreen);

            var offset = new Vector2(750,500);
            offset.X -= player.Bounds.X;
            offset.Y -= player.Bounds.Y;
            var tMatrix = Matrix.CreateTranslation(offset.X, offset.Y, 0);

            // TODO: Add your drawing code here
            //mapRenderer.LoadMap(map);
            spriteBatch.Begin(SpriteSortMode.Deferred, null, null, null, null, null, tMatrix);
            
            player.Draw(spriteBatch);
            walls.Draw(spriteBatch);
            hub.Draw(spriteBatch);

            fire.Draw(spriteBatch);

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}