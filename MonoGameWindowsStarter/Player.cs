using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MonoGameWindowsStarter
{
    enum State
    {
        South = 0,
        East = 1,
        West = 3,
        North = 2,
        Idle = 4,
    }

    public enum GameState
    {
        Game = 0,
        Over = 1,
        Win = 2,
    }

    public class Player
    {
        Game1 game;
        Texture2D texture;

        const int FRAMERATE = 124;
        public float playerSpeed = 0.40f;
        const int FRAME_WIDTH = 16;
        const int FRAME_HEIGHT = 31;

        public BoundingRectangle Bounds;
        State animationState;
        TimeSpan timer;
        int frame;
        public Vector2 Position;
        Vector2 origin;
        public GameState gameState;

        public Player(Game1 game)
        {
            this.game = game;
            timer = new TimeSpan(0);
            animationState = State.Idle;
            Position = new Vector2(500, 500);
            origin = new Vector2(0, 0);
            gameState = GameState.Game;
        }

        public void Initialize()
        {
            Bounds.Width = 75;
            Bounds.Height = 100;
            Bounds.X = 500;
            Bounds.Y = 500;

            Position.X = 500;
            Position.Y = 500;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("gfx/character");
        }

        public void Update(GameTime gameTime)
        {
            var keyboardState = Keyboard.GetState();
            float delta = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            //State Change and player movement
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                animationState = State.North;
                Bounds.Y -= delta * playerSpeed;
            }
            else if (keyboardState.IsKeyDown(Keys.Left))
            {
                animationState = State.West;
                Bounds.X -= delta * playerSpeed;
            }
            else if (keyboardState.IsKeyDown(Keys.Right))
            {
                animationState = State.East;
                Bounds.X += delta * playerSpeed;
            }
            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                animationState = State.South;
                Bounds.Y += delta * playerSpeed;
            }
            else
            {
                animationState = State.Idle;
            }

            //Animation timer
            if (animationState != State.Idle)
            {
                timer += gameTime.ElapsedGameTime;
            }
            while (timer.TotalMilliseconds > FRAMERATE)
            {
                frame++;
                timer -= new TimeSpan(0, 0, 0, 0, FRAMERATE);
            }
            frame %= 4;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var source = new Rectangle(
                frame * FRAME_WIDTH,
                (int)animationState % 4 * FRAME_HEIGHT,
                FRAME_WIDTH,
                FRAME_HEIGHT);

            spriteBatch.Draw(texture, Bounds, source, Color.White, 0, origin, SpriteEffects.None, 0);
        }
    }
}