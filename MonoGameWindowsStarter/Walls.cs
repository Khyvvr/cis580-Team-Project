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

        BoundingRectangle wallN;
        BoundingRectangle wallS;
        BoundingRectangle wallE;
        BoundingRectangle wallW;

        public Walls(Game1 game)
        {
            this.game = game;
        }

        public void Initialize()
        {
            wallN.X = -50;
            wallN.Y = -50;
            wallN.Width = 1850;
            wallN.Height = 50;

            wallS.X = -50;
            wallS.Y = 1000;
            wallS.Width = 1850;
            wallS.Height = 50;

            wallE.X = 1750;
            wallE.Y = 0;
            wallE.Width = 50;
            wallE.Height = 1000;

            wallW.X = -50;
            wallW.Y = 0;
            wallW.Width = 50;
            wallW.Height = 1000;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("pixel");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, wallN, Color.Brown);
            spriteBatch.Draw(texture, wallS, Color.Brown);
            spriteBatch.Draw(texture, wallE, Color.Brown);
            spriteBatch.Draw(texture, wallW, Color.Brown);
        }
	}
}
