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
            : base(ATexture.ShooterSheet, x, y, 1, 1, 1, _stage)
        {
            stage = _stage;
            this.FrameCol = 4;
            this.Timer = 0; // Intervalle entre 2 boucles d'animations
            this.AnimationSpeed = 5; // Vitesse d'animation

            prTimer = 0;

            Hitbox = new Rectangle((int)x, (int)y, 150, 150);
            Spritebox = new Rectangle((int)x, (int)y, 150, 150);
            damagebox = Rectangle.Empty;
            color = Color.White;

            Timing = 0;
            LoopTime = 256;
            Speed = 4;
            prSpeed = 15;
            exists = true;
            hit = false;

        }
        int FrameCol;
        int Timer, prDir, prTimer, prSpeed;
        int Timing;
        int LoopTime;
        int AnimationSpeed;
        bool direction, hit;
        SpriteEffects Effect;
        Color color;


        public void MoveLeft()
        {
            this.Timer++;
            if (this.Timer == this.AnimationSpeed)
            {
                this.Timer = 0;
                this.FrameCol++;
                if (this.FrameCol > 8)
                {
                    this.FrameCol = 4;
                    this.Timer = 0;
                }
            }
            direction = false;
            Hitbox.X = Hitbox.X - (int)Speed;
            if (Hitbox.Left <= 0)
            {
                Hitbox.Location = new Point(0, Hitbox.Location.Y);
            }
        }
        public void MoveRight()
        {
            this.Timer++;
            if (this.Timer == this.AnimationSpeed)
            {
                this.Timer = 0;
                this.FrameCol++;
                if (this.FrameCol > 8)
                {
                    this.FrameCol = 4;
                    this.Timer = 0;
                }
            }
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
            if (prTimer > 0)
            {
                prTimer--;
                damagebox.X = damagebox.X + (prDir * prSpeed);
                foreach (Player p in stage.lists.ListPlayers)
                {
                    hit = (hit || (damagebox.Intersects(p.Hitbox)));
                }
            }
            else
                damagebox = Rectangle.Empty;
            
            if (prTimer == 0)
                IA();
            
            if (hitPoints == 0)
                Delete();
        }
        public override void Draw(SpriteBatch sb, GameTime gt)
        {
            //spriteBatch.Draw(ATexture.Portrait, damagebox, Color.White);
            sb.Draw(Texture, Hitbox, new Rectangle((this.FrameCol - 1) * 110, 0, 110, 110),
                color, 0f, new Vector2(0, 0), this.Effect, 0f);
            if (damagebox != Rectangle.Empty)
                sb.Draw(ATexture.BossBullet, damagebox, Color.Black);
        }


        public void DetectionPlayer()
        {
            for (int i = 0; i < stage.lists.ListPlayers.Count; i++)
            {
                if (direction)
                {
                    if (prTimer == 0 && stage.lists.ListPlayers.ElementAt(i).Hitbox.X > Hitbox.X + Hitbox.Width && stage.lists.ListPlayers.ElementAt(i).Hitbox.X < Hitbox.X + Hitbox.Width + 500)
                    {
                        prDir = 1;
                        damagebox = new Rectangle(Hitbox.X + Hitbox.Width - 10, Hitbox.Y + 12, 25, 20); 
                        prTimer = 200;

                        //color = Color.Green;
                    }
                }
                else
                {
                    if (prTimer == 0 && stage.lists.ListPlayers.ElementAt(i).Hitbox.X < Hitbox.X && stage.lists.ListPlayers.ElementAt(i).Hitbox.X > Hitbox.X - 500)
                    {
                        prDir = -1;
                        damagebox = new Rectangle(Hitbox.X, Hitbox.Y + 12, 25, 20); 
                        prTimer = 200;
                        //color = Color.Red;
                    }
                }
            }
        }


    }
}
