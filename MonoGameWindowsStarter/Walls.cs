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

        public BoundingRectangle WallN;
        public BoundingRectangle WallS;
        public BoundingRectangle WallE;
        public BoundingRectangle WallW;

        public BoundingRectangle MazeWall01;
        public BoundingRectangle MazeWall02;

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

            MazeWall01.X = 100;
            MazeWall01.Y = 230;
            MazeWall01.Width = 400;
            MazeWall01.Height = WALL_WIDTH;

            MazeWall02.X = 300;
            MazeWall02.Y = 0;
            MazeWall02.Width = WALL_WIDTH;
            MazeWall02.Height = 100;
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

            spriteBatch.Draw(texture, MazeWall01, Color.Red);
            spriteBatch.Draw(texture, MazeWall02, Color.Red);
        }
	}
}
