using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.IO;

namespace Steel_Era
{
    class Player : Microsoft.Xna.Framework.Game
    {

        public enum Direction
        {
            Up, Down, Left, Right, Non, A, Z
        };
        //FIELDS


        int Timer;
        int AnimationSpeed;
        Rectangle Hitbox;
        Rectangle Spritebox;
        Direction direction;
        bool IsGrounded;
        SpriteEffects Effect;
        int FrameLine;
        int FrameCol;
        int regard;
        int gravity;
        int JumpCeiling;
        int airSpeed;//, jumpTimer;
        


        //CONSTRUCTORS

        public Player()
        {
            this.Hitbox = new Rectangle(0, 0, 90, 180);
            this.Spritebox = new Rectangle(0, 0, 189, 180);
            this.FrameLine = 1;
            this.FrameCol = 1;
            this.IsGrounded = false;
            this.gravity = 15; // Vitesse de chute
            this.regard = 1; // Si regard = 1 les perso est tourné vers la droite sinon vers la gauche
            this.Timer = 0; // Intervalle entre 2 boucles d'animations
            this.AnimationSpeed = 7; // Vitesse d'animation
            this.direction = Direction.Non; //Position si aucun input
            this.JumpCeiling = Hitbox.Y;
            airSpeed = 20;
            //jumpTimer = 0;
        }

        //METHODS
        /*public bool IsOnGround()
        {
            if (Hitbox.Bottom <= Game1.screenHeight - 25)
            {
                return IsGrounded == true;
            }
            else
            {
                return IsGrounded == false;
            }
        }*/
        public void IsHorsLimiteLeft()
        {
            if (Hitbox.Left <= 0)
            {
                this.Hitbox.X = 0;
            }
        }
        public void RegardDirection()
        {
            if (this.regard == 1)
            {
                this.Effect = SpriteEffects.FlipHorizontally;
            }
        }
        public void AnimateRunLeft()
        {
            this.Timer++;
            if (this.Timer == this.AnimationSpeed)
            {
                this.Timer = 0;
                this.FrameCol++;
                if (this.FrameCol > 8)
                {
                    this.FrameCol = 1;
                    this.Timer = 0;
                }
            }
        }
        public void AnimateRunRight()
        {
            this.Timer++;
            if (this.Timer == this.AnimationSpeed)
            {
                this.Timer = 0;
                this.FrameCol++;
                if (this.FrameCol > 8)
                {
                    this.FrameCol = 1;
                    this.Timer = 0;
                }
            }
        }
        public void AnimateJump()
        {
            this.Timer++;
            this.AnimationSpeed = 9;
            if (this.Timer == this.AnimationSpeed)
            {
                this.Timer = 0;
                this.FrameCol++;
                if (this.FrameCol > 2)
                {
                    this.FrameCol = 2;
                    if (IsGrounded == true)//IsOnGround().Equals(true))
                    {
                        this.direction = Direction.Non;
                    }
                }
            }
            this.AnimationSpeed = 7;
        }
        public void AnimateCrouch()
        {
            this.AnimationSpeed = 2;
            this.Timer++;

            if (this.Timer == this.AnimationSpeed)
            {
                this.Timer = 0;
                this.FrameCol++;
                if (this.FrameCol > 3)
                {
                    this.FrameCol = 3;
                }
            }
            this.AnimationSpeed = 7;
        }
        public void AnimateAttackA()
        {
            this.AnimationSpeed = 7;
            this.Timer++;

            if (this.Timer == this.AnimationSpeed)
            {
                this.Timer = 0;
                this.FrameCol++;
                if (this.FrameCol > 4)
                {
                    this.FrameCol = 1;
                }
            }
            this.AnimationSpeed = 7;
        }


        //UPDATE & DRAW//


        public void Update(MouseState mouse, KeyboardState keyboard)
        {

            //Attaques

            if (keyboard.IsKeyDown(Keys.A))
            {

                this.direction = Direction.A;
                this.AnimateAttackA();
            }
            else
            {
                this.direction = Direction.Non;
            }

            // MOUVEMENT SPEED/DIRECTION
            if (keyboard.IsKeyDown(Keys.Up))
            {
                if (this.Hitbox.Y > JumpCeiling)
                    this.Hitbox.Y -= airSpeed;
                if (IsGrounded == true)
                {
                    airSpeed = 20;
                }
                else
                {
                    //if (airSpeed > 0)
                        airSpeed -= 1;
                }
                this.direction = Direction.Up;
                this.AnimateJump();
                if (keyboard.IsKeyDown(Keys.Left))
                {
                    this.Hitbox.X = this.Hitbox.X - 10;
                    this.IsHorsLimiteLeft();
                }
                if (keyboard.IsKeyDown(Keys.Right))
                {
                    this.Effect = SpriteEffects.FlipHorizontally;
                    this.Hitbox.X = this.Hitbox.X + 10;
                }
            }
            else
            {
                if (IsGrounded == false)//IsOnGround().Equals(false))
                {
                    Hitbox.Y += gravity;
                }
            }
            if (keyboard.IsKeyDown(Keys.Down))
            {
                //this.Hitbox.Y += 5;
                this.direction = Direction.Down;
                this.AnimateCrouch();
            }
            if (keyboard.IsKeyDown(Keys.Left) && keyboard.IsKeyUp(Keys.Down) && keyboard.IsKeyUp(Keys.Up))
            {
                this.Hitbox.X -= 10;
                this.direction = Direction.Left;
                this.AnimateRunLeft();
                this.regard = 0;
                this.IsHorsLimiteLeft();
                if (keyboard.IsKeyDown(Keys.Right)&&keyboard.IsKeyDown(Keys.Left))
                {
                    this.FrameLine = 1;
                    this.FrameCol = 1;
                    this.Timer = 0;     
                }
            }
            if (keyboard.IsKeyDown(Keys.Right) && keyboard.IsKeyUp(Keys.Down) && keyboard.IsKeyUp(Keys.Up))
            {
                this.Hitbox.X = this.Hitbox.X + 10;
                this.direction = Direction.Right;
                this.AnimateRunRight();
                this.regard = 1;
                if (keyboard.IsKeyDown(Keys.Left) && keyboard.IsKeyDown(Keys.Right))
                {
                    this.FrameLine = 1;
                    this.FrameCol = 1;
                    this.Timer = 0;
                }
            }
            if (keyboard.IsKeyUp(Keys.Up) && keyboard.IsKeyUp(Keys.Down) && keyboard.IsKeyUp(Keys.Right) && keyboard.IsKeyUp(Keys.Left) && keyboard.IsKeyUp(Keys.A))
            {
                if (IsGrounded == true)//IsOnGround().Equals(true))
                {
                this.FrameLine = 1;
                this.FrameCol = 1;
                this.Timer = 0;
                }
            }


            // MOUVEMENT ANIMATIONS


            switch (this.direction)
            {
                case Direction.Up: this.FrameLine = 5;
                    this.RegardDirection();
                    break;
                case Direction.Down: this.FrameLine = 3;
                    this.RegardDirection();
                    break;
                case Direction.Left: this.FrameLine = 2;
                    this.Effect = SpriteEffects.None;

                    break;
                case Direction.Right: this.FrameLine = 2;
                    this.Effect = SpriteEffects.FlipHorizontally;
                    break;
                case Direction.A: this.FrameLine = 4;
                    this.RegardDirection();
                    break;
                case Direction.Non: this.FrameLine = 1;
                    this.RegardDirection();
                    break;
            }
            Collisions();
            Spritebox.Location = new Point(Hitbox.Center.X - (Spritebox.Width / 2), Hitbox.Center.Y - (Spritebox.Height / 2));
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            
            //spriteBatch.Draw(ATexture.Crow, this.Hitbox, new Rectangle((this.FrameCol - 1) * 189, (this.FrameLine - 1) * 180, 189, 180),
            //    Color.White, 0f, new Vector2(0, -200), this.Effect, 0f);
            spriteBatch.Draw(ATexture.Crow, this.Spritebox, new Rectangle((this.FrameCol - 1) * 189, (this.FrameLine - 1) * 180, 189, 180),
                Color.White, 0f, new Vector2(0, 0), this.Effect, 0f);
        }



        protected void Collisions()
        {
            Rectangle h;
            Vector2 pos = new Vector2(Hitbox.Location.X, Hitbox.Location.Y);
            for (int i = 0; i < Physics.ListObstacle.Count; i++)
            {
                if (Hitbox.Intersects(Physics.ListObstacle.ElementAt(i).hitBox))
                {
                    h = Physics.ListObstacle.ElementAt(i).hitBox;
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
