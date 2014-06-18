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

namespace Steel_Era.Elements
{
    class Projectile : Sprite
    {
        public Projectile(Texture2D tex, float _x, float _y, int dmg, bool dir, Stages.Stage sta, bool e)
            : base (tex, _x, _y)
        {
            direction = dir;
            damages = dmg;
            timer = 200;
            stage = sta;
            Speed = 1;
            enemy = e;
        }
        bool direction, enemy;
        int damages, timer;
        Stages.Stage stage;


        public void Update()
        {
            if (direction)
            {
                //Hitbox.X += (int)Speed;
            }
            else
            {
                //Hitbox.X -= (int)Speed;
            }
            timer--;
            //if (timer < 1)
            //    Used();
            CollisionSprites();
            if (enemy)
                CollisionPlayer();
            else
                CollisionEnemies();
        }
        
        public void CollisionSprites()
        {
            for (int i = 0; i < stage.lists.ListObstacle.Count; i++)
            {
                if (Hitbox.Intersects(stage.lists.ListObstacle.ElementAt(i).Hitbox))
                {
                    Used();
                }
            }
        }
        public void CollisionPlayer()
        {
            for (int i = 0; i < stage.lists.ListPlayers.Count; i++)
            {
                if (Hitbox.Intersects(stage.lists.ListPlayers.ElementAt(i).Hitbox))
                {
                    HUD.HP -= damages;
                    //Used();
                }
            }
        }
        public void CollisionEnemies()
        {
            for (int i = 0; i < stage.lists.ListEnemies.Count; i++)
            {
                if (Hitbox.Intersects(stage.lists.ListEnemies.ElementAt(i).Hitbox))
                {
                    stage.lists.ListEnemies.ElementAt(i).hitPoints -= damages;
                    //Used();
                }
            }
        }

        public override void Draw(SpriteBatch sb, GameTime gt)
        {
            sb.Draw(Texture, Hitbox, Color.White);
            base.Draw(sb, gt);
        }
    }
}
