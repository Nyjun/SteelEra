using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Steel_Era
{
    class Projectile : Sprite
    {
        public enum Direction
        {
            up,
            down,
            right,
            left,
        }

        public Projectile(Texture2D tex, float _x, float _y, Direction _dir, int _lifespan)
            : base(tex, _x, _y)
        {
            dir = _dir;
            lifespan = _lifespan;
        }

        Direction dir;
        int lifespan;

        public override void Update(GameTime gameTime)
        {
            if (lifespan > 0)
                lifespan--;
            if (lifespan == 0)
                Delete();
            else
            {
                if (dir == Direction.left)
                    Hitbox.X = Hitbox.X - (int)Speed;
                if (dir == Direction.right)
                    Hitbox.X = Hitbox.X + (int)Speed;
            }
            base.Update(gameTime);
        }
        
    }
}
