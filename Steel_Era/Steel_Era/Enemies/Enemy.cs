using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.IO;

namespace Steel_Era
{
    abstract class Enemy : Sprite
    {
        public Enemy(Texture2D tex, float x, float y, int hp, int dmg, float sp)
            : base(tex, x, y)
        {
            hitPoints = hp;
            damages = dmg;
            Speed = sp;
        }

        protected int hitPoints;
        protected int damages;
        protected Rectangle hitbox;

        public override void Update(GameTime gameTime)
        {


            base.Update(gameTime);
        }
    }
}
