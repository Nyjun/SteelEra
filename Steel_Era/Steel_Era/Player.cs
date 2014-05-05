using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.IO;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Steel_Era
{
    class Player : Microsoft.Xna.Framework.Game
    {
        public float bulletDelay;
        public List<Bullet> bulletList;

        public enum Direction
        {
            Up, Down, Left, Right, Non, A, Z, lA,
        };
        //FIELDS


        int Timer;
        int Temp;
        int AnimationSpeed;
        public static Rectangle Hitbox;
        public static Rectangle Spritebox;
        Direction direction;
        bool IsGrounded;
        SpriteEffects Effect;
        int FrameLine;
        int FrameCol;
        int regard;
        int gravity;
        int JumpCeiling;
        int airSpeed;//, jumpTimer;
        int crouchHeight;
        int height;



        //CONSTRUCTORS

        public Player()
        {
            Hitbox = new Rectangle(0, 0, 87, 170);
            Spritebox = new Rectangle(0, 0, 175, 175);
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
            height = Spritebox.Height;
            crouchHeight = (2 * Spritebox.Height) / 3;
            //jumpTimer = 0;

            bulletList = new List<Bullet>();
            bulletDelay = 30;
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
                Hitbox.X = 0;
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

                    Menu.jumpInst.Play();
                    if (IsGrounded == true)//IsOnGround().Equals(true))
                    {
                        this.direction = Direction.Non;
                        Menu.landingInst.Play();
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
                if (this.FrameCol == 2)
                {
                    Menu.attack1Inst.Play();
                }
                if (this.FrameCol > 4)
                {
                    this.FrameCol = 1;
                    HUD.Mana = HUD.Mana - 1;
                }
            }
            this.AnimationSpeed = 7;  
        }
        public void AnimateAttackZ()
        {
            this.AnimationSpeed = 7;
            this.Timer++;
            if (this.Timer == this.AnimationSpeed)
            {
                this.Timer = 0;
                this.FrameCol++;
                if (this.FrameCol == 4)
                {
                    Menu.attack1Inst.Play();
                }
                if (this.FrameCol > 8)
                {
                    this.FrameCol = 1;
                }
            }
            this.AnimationSpeed = 7;
        }

        public void AnimateAttacklA()
        {
            this.AnimationSpeed = 10;
            this.Timer++;
            if (this.Timer == this.AnimationSpeed)
            {
                this.Timer = 0;
                this.FrameCol++;
                if (this.FrameCol > 3)
                {
                    this.FrameCol = 1;
                    Menu.attack1Inst.Play();
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
                Shoot();                

            }
            else
            {
                this.direction = Direction.Non;
            }
            UpdateBullets();
            //Attaque Z
            if (keyboard.IsKeyDown(Keys.Z))
            {

                this.direction = Direction.Z;
                this.AnimateAttackZ();
            }


            //Attaque E
            if (keyboard.IsKeyDown(Keys.E))
            {

                this.direction = Direction.lA;
                this.AnimateAttacklA();
            }

            // MOUVEMENT SPEED/DIRECTION
            if (keyboard.IsKeyDown(Keys.Up))
            {
                if (Hitbox.Y > JumpCeiling)
                    Hitbox.Y -= airSpeed;
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
                    Hitbox.X = Hitbox.X - 10;
                    this.IsHorsLimiteLeft();

                }
                if (keyboard.IsKeyDown(Keys.Right))
                {
                    this.Effect = SpriteEffects.FlipHorizontally;
                    Hitbox.X = Hitbox.X + 10;
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
                Hitbox = new Rectangle(Hitbox.Location.X, Hitbox.Location.Y, Hitbox.Width, crouchHeight);
                this.direction = Direction.Down;
                this.AnimateCrouch();
            }
            if (keyboard.IsKeyUp(Keys.Down))
            {
                Hitbox = new Rectangle(Hitbox.Location.X, Hitbox.Location.Y, Hitbox.Width, height);
            }
            if (keyboard.IsKeyDown(Keys.Left) && keyboard.IsKeyUp(Keys.Down) && keyboard.IsKeyUp(Keys.Up))
            {
                Hitbox.X -= 10;
                this.direction = Direction.Left;
                this.AnimateRunLeft();
                this.regard = 0;
                this.IsHorsLimiteLeft();
                if (keyboard.IsKeyDown(Keys.Right) && keyboard.IsKeyDown(Keys.Left))
                {
                    this.FrameLine = 1;
                    this.FrameCol = 1;
                    this.Timer = 0;
                }
            }
            if (keyboard.IsKeyDown(Keys.Right) && keyboard.IsKeyUp(Keys.Down) && keyboard.IsKeyUp(Keys.Up))
            {
                Hitbox.X = Hitbox.X + 10;
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
            if (keyboard.IsKeyUp(Keys.Up) && keyboard.IsKeyUp(Keys.Down) && keyboard.IsKeyUp(Keys.Right) && keyboard.IsKeyUp(Keys.Left) && keyboard.IsKeyUp(Keys.A) && keyboard.IsKeyUp(Keys.Z) && (keyboard.IsKeyUp(Keys.E)))
            {
                //if (IsGrounded == true)//IsOnGround().Equals(true))
                //{
                this.FrameLine = 1;
                this.FrameCol = 1;
                this.Timer = 0;
                //}
            }


            // MOUVEMENT ANIMATIONS + SON


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
                    Menu.run_groundInst.Play();
                    break;
                case Direction.Right: this.FrameLine = 2;
                    this.Effect = SpriteEffects.FlipHorizontally;
                    Menu.run_groundInst.Play();
                    break;
                case Direction.A: this.FrameLine = 4;
                    this.RegardDirection();
                    break;
                case Direction.Z: this.FrameLine = 7;
                    this.RegardDirection();
                    break;
                case Direction.lA: this.FrameLine = 6;
                    this.RegardDirection();
                    break;
                case Direction.Non: this.FrameLine = 1;
                    this.RegardDirection();
                    Menu.run_groundInst.Stop();
                    break;
            }



            Collisions();
            Spritebox.Location = new Point(Hitbox.Center.X - (Spritebox.Width / 2), Hitbox.Center.Y - (Spritebox.Height / 2));
        }
        public void Draw(SpriteBatch spriteBatch)
        {

            //spriteBatch.Draw(ATexture.cursor8x8, Hitbox, Color.White);
            spriteBatch.Draw(ATexture.Crow, Spritebox, new Rectangle((this.FrameCol - 1) * 175, (this.FrameLine - 1) * 175, 175, 175),
                Color.White, 0f, new Vector2(0, 0), this.Effect, 0f);
            foreach (Bullet b in bulletList)
            {
                b.Draw(spriteBatch);
            }
        }

        //Shoot Method
        public void Shoot()
        {
            Temp = regard;
            //Shoot only if delay reset
            if (bulletDelay >= 0)
            {
                bulletDelay--;
            }
            //If bulletDelay = 0, create new bullet, make it visible
            if (bulletDelay <= 0)
            {                
                if (regard == 1)
                {
                    Bullet newBullet = new Bullet(ATexture.bullet);
                    newBullet.position = new Vector2(Spritebox.X + 32 / 2, Spritebox.Y);
                    newBullet.IsVisible = true;
                    if (bulletList.Count() < 2)
                    {
                        bulletList.Add(newBullet);
                    }
                }
                if (regard == 0)
                {
                    Bullet newBullet = new Bullet(ATexture.bulletR);
                    newBullet.position = new Vector2(Spritebox.X + 32 / 2, Spritebox.Y);
                    newBullet.IsVisible = true;
                    if (bulletList.Count() < 1)
                    {
                        bulletList.Add(newBullet);
                    }
                }

            }
            //Reset bulletDelay
            if (bulletDelay == 0)
            {
                bulletDelay = 30;
            }
        }
        //Update bullets
        public void UpdateBullets()
        {
            foreach (Bullet b in bulletList)
            {
                if (Temp == 0)
                {
                    b.position.X = b.position.X - b.speed;

                    if (b.position.X <= Spritebox.X - 900)
                    {
                        b.IsVisible = false;
                    }
                }
                if (Temp == 1)
                {
                    b.position.X = b.position.X + b.speed;

                    if (b.position.X >= Spritebox.X + 900)
                    {
                        b.IsVisible = false;
                    }
                }
            }

            for (int i = 0; i < bulletList.Count; i++)
            {
                if (!bulletList[i].IsVisible)
                {
                    bulletList.RemoveAt(i);
                    i--;
                }
            }
        }

        //Collision
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
