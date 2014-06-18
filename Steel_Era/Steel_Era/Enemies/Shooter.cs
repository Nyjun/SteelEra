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
    class Shooter : Enemy
    {
        public Shooter(float x, float y, Stages.Stage _stage)
            : base(ATexture.ShooterSprite, x, y, 1, 1, 1, _stage)
        {
            stage = _stage;
            this.FrameCol = 4;
            //this.Timer = 0; // Intervalle entre 2 boucles d'animations
            //this.AnimationSpeed = 5; // Vitesse d'animation

            Hitbox = new Rectangle((int)x, (int)y, 150, 150);
            Spritebox = new Rectangle((int)x, (int)y, 150, 150);
            damagebox = Rectangle.Empty;
            color = Color.White;

            Timing = 0;
            LoopTime = 256;
            Speed = 4;
            exists = true;
        }
        int FrameCol;
        //int Timer;
        int Timing;
        int LoopTime;
        //int AnimationSpeed;
        bool direction;
        SpriteEffects Effect;
        Color color;


        public void MoveLeft()
        {
            direction = false;
            Hitbox.X = Hitbox.X - (int)Speed;
            if (Hitbox.Left <= 0)
            {
                Hitbox.Location = new Point(0, Hitbox.Location.Y);
            }
        }
        public void MoveRight()
        {
            direction = true;
            Hitbox.X = Hitbox.X + (int)Speed;
        }

        void IA()
        {
            if (Menu.Freezed == false)
            {
                if (Timing < LoopTime / 2)
                {
                    MoveRight();
                }
                if (Timing >= LoopTime / 2)
                {
                    MoveLeft();
                }
                if (Timing == LoopTime)
                {
                    Timing = 0;
                }
                else
                {
                    Timing++;
                }
                DetectionPlayer();
            }
            
            if (IsGrounded == false)
            {
                Hitbox.Y += Physics.gravity;
            }
            Collisions();
            if (direction)
            {
                Effect = SpriteEffects.FlipHorizontally;
            }
            else
            {
                Effect = SpriteEffects.None;
            }
            
        }

        public override void Update(GameTime gameTime)
        {

            IA();
            if (hitPoints == 0)
                Delete();
        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            //spriteBatch.Draw(ATexture.Portrait, damagebox, Color.White);
            spriteBatch.Draw(Texture, Hitbox, new Rectangle((this.FrameCol - 1) * 110, 0, 110, 110),
                color, 0f, new Vector2(0, 0), this.Effect, 0f);
        }


        public void DetectionPlayer()
        {
            for (int i = 0; i < stage.lists.ListPlayers.Count; i++)
            {
                if (direction)
                {
                    if (stage.lists.ListPlayers.ElementAt(i).Hitbox.X > Hitbox.X + Hitbox.Width && stage.lists.ListPlayers.ElementAt(i).Hitbox.X < Hitbox.X + Hitbox.Width + 500)
                    {
                        Elements.Projectile p = new Elements.Projectile(ATexture.BossBullet, Hitbox.X + Hitbox.Width, Hitbox.Y, 1, direction, stage, true);
                        stage.lists.ListProjectiles.Add(p);
                        //color = Color.Green;
                    }
                }
                else
                {
                    if (stage.lists.ListPlayers.ElementAt(i).Hitbox.X < Hitbox.X && stage.lists.ListPlayers.ElementAt(i).Hitbox.X > Hitbox.X - 500)
                    {
                        Elements.Projectile p = new Elements.Projectile(ATexture.BossBullet, Hitbox.X + Hitbox.Width, Hitbox.Y, 1, direction, stage, true);
                        stage.lists.ListProjectiles.Add(p);
                        //color = Color.Red;
                    }
                }
            }
        }
    }
}
