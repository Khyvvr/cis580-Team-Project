using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameWindowsStarter
{
    enum objectState
    {
        Animate = 0,
        Paused = 1,
    }

    public class Fire
    {
        Game1 game;
        Texture2D texture;

        const int FRAMERATE = 124;      // animation speed of object
        float OBJECT_SPEED;             // object speed (if it moves)
        int FRAME_WIDTH;                // frame width of the frames to be used for object
        int FRAME_HEIGHT;               // frame height of the frames to be used for object

        public BoundingRectangle bounds;   //the object's bounds
        objectState state;                  // state of the object if it moves
        Vector2 position;                   // object's position
        Vector2 origin;                     // object's origin
        TimeSpan animationTimer;            // timer for animations
        int frame;                          // current frame of object


        public Fire(Game1 game, Vector2 position, int width, int height, int widthOfFrame, int heightOfFrame, float speed)
        {
            this.game = game;
            this.position = position;
            this.FRAME_WIDTH = widthOfFrame;
            this.FRAME_HEIGHT = heightOfFrame;
            this.OBJECT_SPEED = speed;
            origin = new Vector2(0, 0);

            this.bounds.Width = width;
            this.bounds.Height = height;

            state = objectState.Animate;
            animationTimer = new TimeSpan(0);
        }


        public void Initialize()
        {
            bounds.X = position.X;
            bounds.Y = position.Y;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("fire");
        }

        public void Update(GameTime gameTime)
        {
            float delta = (float)gameTime.ElapsedGameTime.TotalMilliseconds;

            //Animation timer
            
            if (state != objectState.Paused)
            {
                animationTimer += gameTime.ElapsedGameTime;
            }
            while (animationTimer.TotalMilliseconds > FRAMERATE)
            {
                frame++;
                animationTimer -= new TimeSpan(0, 0, 0, 0, FRAMERATE);
            }

            frame %= 7;    // keep frame within bounds
            
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            var source = new Rectangle(
                frame * FRAME_WIDTH,
                (int)state * FRAME_HEIGHT,
                FRAME_WIDTH,
                FRAME_HEIGHT);

            spriteBatch.Draw(texture, bounds, source, Color.White, 0, origin, SpriteEffects.None, 1);
        }

    }
}
