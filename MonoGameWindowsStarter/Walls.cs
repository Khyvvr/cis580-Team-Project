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

        public BoundingRectangle WallN;
        public BoundingRectangle WallS;
        public BoundingRectangle WallE;
        public BoundingRectangle WallW;

        public Walls(Game1 game)
        {
            this.game = game;
        }

        public void Initialize()
        {
            WallN.X = -50;
            WallN.Y = -50;
            WallN.Width = 2050;
            WallN.Height = 50;

            WallS.X = -50;
            WallS.Y = 1950;
            WallS.Width = 2050;
            WallS.Height = 50;

            WallE.X = 1950;
            WallE.Y = 0;
            WallE.Width = 50;
            WallE.Height = 1950;

            WallW.X = -50;
            WallW.Y = 0;
            WallW.Width = 50;
            WallW.Height = 1950;
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
        }
	}
}
