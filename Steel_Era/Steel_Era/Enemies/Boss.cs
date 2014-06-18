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

            Effect = new SpriteEffects();
            Hitbox = new Rectangle((int)x, (int)y, 272, 350);
            Spritebox = new Rectangle((int)x, (int)y, 272, 330);
            damagebox = new Rectangle((int)x + 17, (int)y, 80, 15);

            //Timing = 0;
            //LoopTime = 256;
            Speed = 4;
            exists = true;
        }
        void IABoss()
        {
            if (IsGrounded == false)//IsOnGround().Equals(false))
            {
                Hitbox.Y += Physics.gravity;
            }
            Collisions();
            /*if (direction)
            {
                Effect = SpriteEffects.FlipHorizontally;
            }
            else
            {
                Effect = SpriteEffects.None;
            }*/
            damagebox.X = Hitbox.X + 17;
            damagebox.Y = Hitbox.Y;
        }

        public override void Update(GameTime gameTime)
        {
            IABoss();
            if (hitPoints == 0)
                Delete();
            Timer = Timer + 1;
        }
       /* public static void BossPhase()
        {
            lockCamera = true;
        }*/

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            //spriteBatch.Draw(ATexture.Portrait, damagebox, Color.White);
            spriteBatch.Draw(Texture, Hitbox, new Rectangle(FrameCol * 272, 330, 272, 330),
                Color.White, 0f, new Vector2(0, 0), this.Effect, 0f);
        }

    }
    
}
