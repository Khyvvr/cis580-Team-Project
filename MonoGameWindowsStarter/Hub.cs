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
    public class Hub
    {
        Game1 game;
        Texture2D cabinTexture;
        public BoundingRectangle CabinBounds;
        public Vector2 PlayerSpawn;

        public Hub(Game1 game)
        {
            this.game = game;
        }

        public void Initialize()
        {
            CabinBounds.Width = 234;
            CabinBounds.Height = 243;
            CabinBounds.X = 500;
            CabinBounds.Y = 300;

            PlayerSpawn.X = CabinBounds.X + ((CabinBounds.Width / 2) - 25);
            PlayerSpawn.Y = CabinBounds.Y + CabinBounds.Height + 20;
        }

        public void LoadContent(ContentManager content)
        {
            cabinTexture = content.Load<Texture2D>("cabin");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(cabinTexture, CabinBounds, Color.White);
        }
    }
}
