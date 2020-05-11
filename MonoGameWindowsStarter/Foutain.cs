using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MonoGameWindowsStarter
{
    public class Foutain
    {
        Game1 game;
        Texture2D foutainTexture;
        public BoundingRectangle foutainBounds;
        public Vector2 PlayerSpawn;

        public Foutain(Game1 game)
        {
            this.game = game;
        }

        public void Initialize()
        {
            foutainBounds.Width = 150;
            foutainBounds.Height = 150;
            foutainBounds.X = 800;
            foutainBounds.Y = 800;
        }

        public void LoadContent(ContentManager content)
        {
            foutainTexture = content.Load<Texture2D>("foutain");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(foutainTexture, foutainBounds, Color.White);
        }
    }
}
