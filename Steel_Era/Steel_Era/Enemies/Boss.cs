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

namespace Steel_Era.Enemies
{
    class Boss : Enemy
    {

        public static bool lockCamera;
        public static int HpBoss;
        int FrameCol;
        int Timer;
        bool Shooting1, Shooting2, Shooting3;
        Rectangle HitboxCanon;
        Rectangle HitboxSalve1, HitboxSalve2, HitboxSalve3;
        Rectangle HitboxPilon1, HitboxPilon2, HitboxPilon3;
        //int Timing;
        //int LoopTime;
        //int AnimationSpeed;
        //bool direction;
        SpriteEffects Effect;


        public Boss(float x, float y, Stages.Stage _stage)
            : base(ATexture.Boss, x, y, HpBoss, 1, 1, _stage)
        {
            stage = _stage;
            this.FrameCol = 0;
            this.Timer = 0; // Intervalle entre 2 boucles d'animations
            //AnimationSpeed = 5; // Vitesse d'animation
            lockCamera = false;
            Effect = new SpriteEffects();
            Hitbox = new Rectangle((int)x, (int)y, 272, 350);
            Spritebox = new Rectangle((int)x, (int)y, 272, 330);
            damagebox = new Rectangle((int)x + 17, (int)y, 80, 15);

            //Attacks Initial Positions
            HitboxSalve1 = new Rectangle(8000, 500, 60, 60);


            //Timing = 0;
            //LoopTime = 256;
            Speed = 4;
            exists = true;
            Shooting1 = false;
            Shooting2 = false;
            Shooting3 = false;
        }
        void IABoss()
        {
            if (IsGrounded == false)//IsOnGround().Equals(false))
            {
                Hitbox.Y += Physics.gravity;
            }
            Collisions();
            if (Timer == 500)
            {
                Attack1();
            }
            if (Timer == 2500)
            {
                Attack2();
            }
            if (Timer == 5000)
            {
                //Attack3();
            }

            /*if (Timer == 7500)
            {
                
            }*/
            else
            {
                Effect = SpriteEffects.None;
            }
            damagebox.X = Hitbox.X + 17;
            damagebox.Y = Hitbox.Y;
        }
        void Attack1()
        {
            Shooting1 = true;


        }
        void Attack2()
        {
            Shooting1 = false;

        }
        public override void Update(GameTime gameTime)
        {
            IABoss();
            if (hitPoints == 0)
                Delete();
            if (lockCamera == true)
            {
                Timer = Timer + 1;
            }
        }
        /*public static void BossPhase()
        {
            lockCamera = true;
        }*/

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            //spriteBatch.Draw(ATexture.Portrait, damagebox, Color.White);
            spriteBatch.Draw(Texture, Hitbox, new Rectangle(FrameCol * 272, 330, 272, 330),
                Color.White, 0f, new Vector2(0, 0), this.Effect, 0f);
            if (Shooting1 == true)
            {
                spriteBatch.Draw(ATexture.BossBullet, HitboxSalve1, Color.White);
                spriteBatch.Draw(ATexture.BossBullet, HitboxSalve3, Color.White);
            }
            if (Shooting1 == true && Timer == 800)
            {
                spriteBatch.Draw(ATexture.BossBullet, HitboxSalve2, Color.White);
            }

        }

    }

}
