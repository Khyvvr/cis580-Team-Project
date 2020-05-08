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

    public class Player
    {
        Game1 game;
        Texture2D texture;

        const int FRAMERATE = 124;
        const float PLAYER_SPEED = 0.25f;
        const int FRAME_WIDTH = 16;
        const int FRAME_HEIGHT = 31;

        public BoundingRectangle Bounds;
        State state;
        TimeSpan timer;
        int frame;
        public Vector2 Position;
        Vector2 origin;

        public Player(Game1 game)
        {
            this.game = game;
            timer = new TimeSpan(0);
            state = State.Idle;
            Position = new Vector2(500, 500);
            origin = new Vector2(0, 0);
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
                state = State.North;
                Bounds.Y -= delta * PLAYER_SPEED;
            }
            else if (keyboardState.IsKeyDown(Keys.Left))
            {
                state = State.West;
                Bounds.X -= delta * PLAYER_SPEED;
            }
            else if (keyboardState.IsKeyDown(Keys.Right))
            {
                state = State.East;
                Bounds.X += delta * PLAYER_SPEED;
            }
            else if (keyboardState.IsKeyDown(Keys.Down))
            {
                state = State.South;
                Bounds.Y += delta * PLAYER_SPEED;
            }
            else
            {
                state = State.Idle;
            }

            //Animation timer
            if (state != State.Idle)
            {
                timer += gameTime.ElapsedGameTime;
            }
            while (timer.TotalMilliseconds > FRAMERATE)
            {
                frame++;
                timer -= new TimeSpan(0, 0, 0, 0, FRAMERATE);
            }
            frame %= 4;

            //Collision with World Borders
            if (Bounds.X < 0)
            {
                Bounds.X = 0;
            }
            if (Bounds.X + Bounds.Width > 1500)
            {
                Bounds.X = 1500 - Bounds.Width;
            }
            if (Bounds.Y < 0)
            {
                Bounds.Y = 0;
            }
            if (Bounds.Y + Bounds.Height > 1000)
            {
                Bounds.Y = 1000 - Bounds.Height;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var source = new Rectangle(
                frame * FRAME_WIDTH,
                (int)state % 4 * FRAME_HEIGHT,
                FRAME_WIDTH,
                FRAME_HEIGHT);

            spriteBatch.Draw(texture, Bounds, source, Color.White, 0, origin, SpriteEffects.None, 1);
        }
    }
}