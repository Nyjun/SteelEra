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
            Up, Down, Left, Right, Non, A
        };
        //FIELDS


        int Timer;
        int AnimationSpeed;
        Rectangle Hitbox;
        Direction direction;
        bool IsGrounded;
        SpriteEffects Effect;
        int FrameLine;
        int FrameCol;
        int regard;
        int gravity;


        //CONSTRUCTORS

        public Player()
        {
            this.Hitbox = new Rectangle(0, 0, 236, 225);
            this.FrameLine = 1;
            this.FrameCol = 1;
            this.IsGrounded = false;
            this.gravity = 15; // Vitesse de chute
            this.regard = 1; // Si regard = 1 les perso est tourné vers la droite sinon vers la gauche
            this.Timer = 0; // Intervalle entre 2 boucles d'animations
            this.AnimationSpeed = 7; // Vitesse d'animation
            this.direction = Direction.Non; //Position si aucun input
        }

        //METHODS
        public bool IsOnGround()
        {
            if (Hitbox.Bottom <= Game1.screenHeight - 225)
            {
                return IsGrounded == true;
            }
            else
            {
                return IsGrounded == false;
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
                    if (IsOnGround().Equals(true))
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
        public void AnimateAttack()
        {
            this.AnimationSpeed = 7;
            this.Timer++;

            if (this.Timer == this.AnimationSpeed)
            {
                this.Timer = 0;
                this.FrameCol++;
                if (this.FrameCol > 8)
                {
                    this.FrameCol = 2;
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
                this.AnimateAttack();
            }
            else
            {
                this.direction = Direction.Non;
            }

            // MOUVEMENT SPEED/DIRECTION
            if (keyboard.IsKeyDown(Keys.Up))
            {
                this.Hitbox.Y -= 20;
                this.direction = Direction.Up;
                this.AnimateJump();
                if (keyboard.IsKeyDown(Keys.Left))
                {
                    this.Hitbox.X = this.Hitbox.X - 10;
                }
                if (keyboard.IsKeyDown(Keys.Right))
                {
                    this.Effect = SpriteEffects.FlipHorizontally;
                    this.Hitbox.X = this.Hitbox.X + 10;
                }
            }
            else
            {
                if (IsOnGround().Equals(false))
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
            }
            if (keyboard.IsKeyDown(Keys.Right) && keyboard.IsKeyUp(Keys.Down) && keyboard.IsKeyUp(Keys.Up))
            {
                this.Hitbox.X = this.Hitbox.X + 10;
                this.direction = Direction.Right;
                this.AnimateRunRight();
                this.regard = 1;

            }

            if (keyboard.IsKeyUp(Keys.Up) && keyboard.IsKeyUp(Keys.Down) && keyboard.IsKeyUp(Keys.Right) && keyboard.IsKeyUp(Keys.Left) && keyboard.IsKeyUp(Keys.A))
            {
                this.FrameLine = 1;
                this.FrameCol = 1;
                this.Timer = 0;
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
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(ATexture.Crow, this.Hitbox, new Rectangle((this.FrameCol - 1) * 236, (this.FrameLine - 1) * 225, 236, 225),
                Color.White, 0f, new Vector2(0, -200), this.Effect, 0f);
        }

    }
}
