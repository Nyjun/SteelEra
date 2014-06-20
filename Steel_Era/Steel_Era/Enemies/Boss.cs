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
        public List<Rectangle> listCanon;
        Color color;
        int damageTimer;
        public static bool lockCamera;
        public static int HpBoss;
        int FrameCol;
        int Timer;
        Vector2 Pos;
        bool Shooting1, Shooting2, Shooting3;
        Rectangle HitboxCanon;
        Rectangle HitboxSalve1, HitboxSalve2, HitboxSalve3;
        Rectangle HitboxPilon1, HitboxPilon2, HitboxPilon3;
        //int Timing;
        //int LoopTime;
        //int AnimationSpeed;
        //bool direction;
        SpriteEffects Effect;
        Vector2 direction;
        public static SoundEffect MultiShot, BigShot, Pilon;
        public static SoundEffectInstance MultiShotInst, BigShotInst, PilonInst;

        public Boss(float x, float y, Stages.Stage _stage)
            : base(ATexture.Boss, x, y, HpBoss, 1, 1, _stage)
        {
            listCanon = new List<Rectangle>();
            direction = new Vector2(-18, -18);
            
            stage = _stage;
            this.FrameCol = 0;
            this.Timer = 0; // Intervalle entre 2 boucles d'animations
            //AnimationSpeed = 5; // Vitesse d'animation
            lockCamera = false;
            Effect = new SpriteEffects();
            Hitbox = new Rectangle((int)x, (int)y, 350, 350);
            Spritebox = new Rectangle((int)x, (int)y, 350, 350);
            damagebox = new Rectangle((int)x + 17, (int)y, 300, 300);
            if (Menu.lvl_selected == 1)
            {
                Pos = new Vector2(8000, 350);
                HitboxSalve1 = new Rectangle(7950, 500, 100, 100);
                HitboxSalve2 = new Rectangle(7950, 350, 100, 100);
                HitboxSalve3 = new Rectangle(7950, 200, 100, 100);
                HitboxCanon = new Rectangle(7950, 500, 100, 100);

                HitboxPilon1 = new Rectangle(7175, 0, 100, 100);
                HitboxPilon2 = new Rectangle(7450, 0, 100, 100);
                HitboxPilon3 = new Rectangle(7725, 0, 100, 100);
            }
            if (Menu.lvl_selected == 2)
            {
                Pos = new Vector2(8000+2500, 350);
                HitboxSalve1 = new Rectangle(7950+2500, 500, 100, 100);
                HitboxSalve2 = new Rectangle(7950+2500, 350, 100, 100);
                HitboxSalve3 = new Rectangle(7950+2500, 200, 100, 100);
                HitboxCanon = new Rectangle(7950+2500, 500, 100, 100);

                HitboxPilon1 = new Rectangle(7175+2500, 0, 100, 100);
                HitboxPilon2 = new Rectangle(7450+2500, 0, 100, 100);
                HitboxPilon3 = new Rectangle(7725+2500, 0, 100, 100);
            }

            //Sound
            MultiShot = ATexture.Attack1;
            MultiShotInst = MultiShot.CreateInstance();
            MultiShotInst.Volume = Menu.VolumeSFX;

            BigShot = ATexture.Attack2;
            BigShotInst = BigShot.CreateInstance();
            BigShotInst.Volume = Menu.VolumeSFX;

            Pilon = ATexture.Attack3;
            PilonInst = Pilon.CreateInstance();
            PilonInst.Volume = Menu.VolumeSFX;


            //Attacks Initial Positions
            
            listCanon.Add(HitboxSalve1);
            listCanon.Add(HitboxSalve2);
            listCanon.Add(HitboxSalve3);
            listCanon.Add(HitboxCanon);
            listCanon.Add(HitboxPilon1);
            listCanon.Add(HitboxPilon2);
            listCanon.Add(HitboxPilon3);
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
            if (Timer > 200 && Timer <= 360)
            {
                Attack1();
                if (Timer == 201 || Timer == 300)
                {
                    MultiShotInst.Play();
                }
                
            }
            if (Timer > 600 && Timer <= 1500)
            {
                if (Timer == 601)
                {
                    BigShotInst.Play();
                }
                Attack2();
                
            }
            if (Timer > 1600 && Timer <= 1800)
            {
                Attack1();
                if (Timer == 1601)
                {
                    MultiShotInst.Play();
                }
            }

            if (Timer > 1900 && Timer <= 2750)
            {
                if (Timer == 1901 || Timer == 2251 || Timer == 2501)
                {
                    PilonInst.Play();
                }
                Attack3();
                
            }
            if (Timer > 2750 && Timer <= 3500)
            {
                if (Timer == 2751)
                {
                    BigShotInst.Play();
                }
                Attack2();

            }
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
            Shooting2 = false;
            Shooting3 = false;

            HitboxSalve1.X -= 16;
            HitboxSalve3.X -= 16;
            if (Timer > 280 && Timer <= 360 || Timer > 1600 && Timer <= 1800)
            {
                HitboxSalve2.X -= 16;
            }

        }
        void Attack2()
        {
            if (Menu.lvl_selected == 1)
            {
                HitboxSalve1 = new Rectangle(7950, 500, 100, 100);
                HitboxSalve2 = new Rectangle(7950, 350, 100, 100);
                HitboxSalve3 = new Rectangle(7950, 200, 100, 100);
            }
            if (Menu.lvl_selected == 2)
            {
                HitboxSalve1 = new Rectangle(7950+2500, 500, 100, 100);
                HitboxSalve2 = new Rectangle(7950+2500, 350, 100, 100);
                HitboxSalve3 = new Rectangle(7950+2500, 200, 100, 100);
            }
                Shooting3 = false;
                Shooting1 = false;
                Shooting2 = true;
            
            if (Timer <= 1500)
            {
                if ((HitboxCanon.Y <= 0 && direction.Y < 0)
                    || (HitboxCanon.Y > Game1.screenHeight - 97 - HitboxCanon.Height && direction.Y > 0))
                {
                    direction = new Vector2(direction.X, -direction.Y);
                    //HitboxCanon.X -= 5;
                    //HitboxCanon.Y += 5;
                }
                if ((HitboxCanon.X <= 7000+2500 && direction.X < 0)
                    || (HitboxCanon.X > 8100+2500 - HitboxCanon.Width && direction.X > 0))
                {
                    direction = new Vector2(-direction.X, direction.Y);
                    //HitboxCanon.X += 5;
                    //HitboxCanon.Y -= 5;
                }
            }
            Pos += direction;
            HitboxCanon.X = (int)Pos.X;
            HitboxCanon.Y = (int)Pos.Y;

        }
        void Attack3()
        {
            Shooting3 = true;
            Shooting1 = false;
            Shooting2 = false;
            if (Timer > 1900 && Timer <= 2250)
            {
                HitboxPilon2.Y += 14;
            }
            if (Timer > 2250 && Timer <= 2500)
            {
                HitboxPilon1.Y += 14;
            }
            if (Timer > 2500 && Timer <= 2750)
            {
                HitboxPilon3.Y += 14;
            }
            HitboxCanon = new Rectangle(7950, 500, 100, 100);
        }
        public void DamageToHero()
        {
            for (int i = 0; i < listCanon.Count; i++)
            {
                if (Stages.Stage1.player.Hitbox.Intersects(listCanon.ElementAt(i)))
                {
                    if (damageTimer > 0)
                    {
                        damageTimer--;
                        color = Color.White;
                    }
                    else
                    {
                        if (HUD.HP > 1)
                            HUD.HP -= 1;
                        else
                            HUD.HP = 0;
                        damageTimer = 20;
                        color = Color.Red;
                    }
                }
            }
        }
        public override void Update(GameTime gameTime)
        {
            if (Menu.Freezed != true)
            {
                IABoss();
                DamageToHero();
                if (hitPoints == 0)
                    Delete();
                if (lockCamera == true)
                {
                    Timer = Timer + 1;
                }
            }
        }
        /*public static void BossPhase()
        {
            lockCamera = true;
        }*/

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            //spriteBatch.Draw(ATexture.Portrait, damagebox, Color.White);
            spriteBatch.Draw(Texture, Hitbox, new Rectangle(FrameCol * 350, 350, 272, 330),
                Color.White, 0f, new Vector2(0, 0), this.Effect, 0f);

            //Attack
            if (Shooting1 == true)
            {
                spriteBatch.Draw(ATexture.BossBullet, HitboxSalve1, Color.White);
                spriteBatch.Draw(ATexture.BossBullet, HitboxSalve3, Color.White);

            }
            if (Shooting1 == true && Timer > 280 && Timer <= 360 || Shooting1 == true && Timer > 1600 && Timer <= 1800)
            {
                spriteBatch.Draw(ATexture.BossBullet, HitboxSalve2, Color.White);
            }
            if (Shooting2 == true && Timer > 600 && Timer <= 1500 || Timer > 2750 && Timer <= 3500)
            {
                spriteBatch.Draw(ATexture.BossBullet, HitboxCanon, Color.White);
            }
            if (Shooting3 == true)
            {
                if (Timer > 2250 && Timer <= 2500)
                {
                    spriteBatch.Draw(ATexture.BossBullet, HitboxPilon1, Color.White);
                }
                if (Timer > 1900 && Timer <= 2250)
                {
                    spriteBatch.Draw(ATexture.BossBullet, HitboxPilon2, Color.White);
                }
                if (Timer > 2500 && Timer <= 2750)
                {
                    spriteBatch.Draw(ATexture.BossBullet, HitboxPilon3, Color.White);
                }
            }

        }

    }

}
