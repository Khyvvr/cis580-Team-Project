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
	public class Walls
	{
        Game1 game;
        Texture2D texture;

        const int WALL_WIDTH = 50;
        const int CORRIDOR_WIDTH = 136;

        public BoundingRectangle WallN;
        public BoundingRectangle WallS;
        public BoundingRectangle WallE;
        public BoundingRectangle WallW;

        public BoundingRectangle MazeWall01;
        public BoundingRectangle MazeWall02;
        public BoundingRectangle MazeWall03;
        public BoundingRectangle MazeWall04;

        public Walls(Game1 game)
        {
            this.game = game;
        }

        public void Initialize()
        {
            WallN.X = -50;
            WallN.Y = -50;
            WallN.Width = 2050;
            WallN.Height = WALL_WIDTH;

            WallS.X = -50;
            WallS.Y = 1950;
            WallS.Width = 2050;
            WallS.Height = WALL_WIDTH;

            WallE.X = 1950;
            WallE.Y = 0;
            WallE.Width = WALL_WIDTH;
            WallE.Height = 1950;

            WallW.X = -50;
            WallW.Y = 0;
            WallW.Width = WALL_WIDTH;
            WallW.Height = 1950;

            MazeWall02.X = 300;
            MazeWall02.Y = 0;
            MazeWall02.Width = WALL_WIDTH;
            MazeWall02.Height = 100;

            MazeWall01.X = CORRIDOR_WIDTH;
            MazeWall01.Y = MazeWall02.Y + MazeWall02.Height + CORRIDOR_WIDTH;
            MazeWall01.Width = MazeWall02.X + MazeWall02.Width;
            MazeWall01.Height = WALL_WIDTH;

            MazeWall03.X = MazeWall01.Width + CORRIDOR_WIDTH;
            MazeWall03.Y = CORRIDOR_WIDTH;
            MazeWall03.Width = WALL_WIDTH;
            MazeWall03.Height = MazeWall02.Height + WALL_WIDTH;

            MazeWall04.X = MazeWall03.X + MazeWall03.Width + CORRIDOR_WIDTH;
            MazeWall04.Y = 0;
            MazeWall04.Width = WALL_WIDTH;
            MazeWall04.Height = MazeWall01.Y + MazeWall01.Height + CORRIDOR_WIDTH;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("pixel");
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, WallN, Color.Brown);
            spriteBatch.Draw(texture, WallS, Color.Brown);
            spriteBatch.Draw(texture, WallE, Color.Brown);
            spriteBatch.Draw(texture, WallW, Color.Brown);

            spriteBatch.Draw(texture, MazeWall01, Color.Brown);
            spriteBatch.Draw(texture, MazeWall02, Color.Brown);
            spriteBatch.Draw(texture, MazeWall03, Color.Brown);
            spriteBatch.Draw(texture, MazeWall04, Color.Brown);
        }
	}
}
