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
    class Roller : Enemy
    {
        public Roller(float x, float y, Stages.Stage _stage)
            : base(ATexture.RollerSprite, x, y, 1, 1, 1)
        {
            stage = _stage;
            this.FrameCol = 4;
            this.Timer = 0; // Intervalle entre 2 boucles d'animations
            this.AnimationSpeed = 5; // Vitesse d'animation

            Hitbox = new Rectangle((int)x, (int)y, 150, 150);
            Spritebox = new Rectangle((int)x, (int)y, 150, 150);
            damagebox = new Rectangle((int)x + 17, (int)y, 80, 15);

            Timing = 0;
            LoopTime = 256;
            Speed = 4;
            exists = true;
        }
        int FrameCol;
        int Timer;
        int Timing;
        int LoopTime;
        int AnimationSpeed;
        bool direction;
        SpriteEffects Effect;
        Stages.Stage stage;
        


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
            }

            if (IsGrounded == false)//IsOnGround().Equals(false))
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
            damagebox.X = Hitbox.X + 17;
            damagebox.Y = Hitbox.Y;
        }


       

        public override void Update(GameTime gameTime)
        {

            IA();

        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            //spriteBatch.Draw(ATexture.Portrait, damagebox, Color.White);
            spriteBatch.Draw(ATexture.RollerSprite, Hitbox, new Rectangle((this.FrameCol - 1) * 110, 0, 110, 110),
                Color.White, 0f, new Vector2(0, 0), this.Effect, 0f);
        }

        protected void Collisions()
        {
            Rectangle h;
            Vector2 pos = new Vector2(Hitbox.Location.X, Hitbox.Location.Y);
            for (int i = 0; i < stage.lists.ListObstacle.Count; i++)
            {
                if (Hitbox.Intersects(stage.lists.ListObstacle.ElementAt(i).Hitbox))
                {
                    h = stage.lists.ListObstacle.ElementAt(i).Hitbox;
                    if (Hitbox.Bottom > h.Bottom && Hitbox.Top < h.Top)
                    {
                        if (Hitbox.Right > h.Left && Hitbox.Left < h.Left)
                        {
                            pos = new Vector2(pos.X - (Hitbox.Right - h.Left), pos.Y);
                        }
                        else
                        {
                            if (Hitbox.Left < h.Right && Hitbox.Right > h.Right)
                            {
                                pos = new Vector2(pos.X + (h.Right - Hitbox.Left), pos.Y);
                            }
                            else
                            {
                                if (Hitbox.Left > h.Left && Hitbox.Right < h.Right)
                                {
                                    pos = new Vector2(pos.X, h.Top - Hitbox.Height);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (Hitbox.Right > h.Left && Hitbox.Left < h.Left && (Hitbox.Bottom < h.Top || Hitbox.Top > h.Bottom))
                        {
                            pos = new Vector2(pos.X - (Hitbox.Right - h.Left), pos.Y);
                        }
                        if (Hitbox.Left < h.Right && Hitbox.Right > h.Right && (Hitbox.Bottom < h.Top || Hitbox.Top > h.Bottom))
                        {
                            pos = new Vector2(pos.X + (h.Right - Hitbox.Left), pos.Y);
                        }
                        if (Hitbox.Bottom > h.Top && Hitbox.Top < h.Top)
                        {
                            pos = new Vector2(pos.X, pos.Y - (Hitbox.Bottom - h.Top));
                            IsGrounded = true;
                        }
                        else if (Hitbox.Bottom < h.Top && Hitbox.Top < h.Top)
                        {
                            IsGrounded = false;
                        }
                        if (Hitbox.Top < h.Bottom && Hitbox.Bottom > h.Bottom)
                        {
                            pos = new Vector2(pos.X, pos.Y + (h.Bottom - Hitbox.Top));
                        }
                    }

                }
                if ((int)pos.X == Hitbox.Location.X && (int)pos.Y == Hitbox.Location.Y)
                {
                    IsGrounded = false;
                }
            }
            Hitbox.Location = new Point((int)pos.X, (int)pos.Y);
        }
    }
}
