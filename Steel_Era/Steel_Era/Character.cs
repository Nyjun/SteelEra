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

namespace Steel_Era
{
    class Character : Sprite
    {
        public Character(Texture2D _tex, float x, float y, string _ID, bool _player/*, float _mass*/)
            : base(_tex, true, x, y)
        {
            ID = _ID;
            //Mass = _mass;
            //Weight = new Vector2(0f, 9.81f * _mass);
            this.FrameLine = 1;
            this.FrameCol = 1;
            this.IsGrounded = false;
            this.gravity = 15; // Vitesse de chute
            this.regard = 1; // Si regard = 1 les perso est tourné vers la droite sinon vers la gauche
            this.Timer = 0; // Intervalle entre 2 boucles d'animations
            this.AnimationSpeed = 7; // Vitesse d'animation
            this.direction = Direction.Non; //Position si aucun input
        }



        public enum Direction
        {
            Up, Down, Left, Right, Non, A
        };
        //FIELDS


        int Timer;
        int AnimationSpeed;
        Direction direction;
        bool IsGrounded;
        SpriteEffects Effect;
        int FrameLine;
        int FrameCol;
        int regard;
        int gravity;

        //METHODS
        public bool IsOnGround()
        {
            if (hitBox.Bottom <= Game1.screenHeight - 225)
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



        /// <summary>
        /// Met à jour les variables du character
        /// </summary>
        /// <param name="gameTime">Le GameTime associé à la frame</param>
        public override void Update(GameTime gameTime)
        {
            
            

            /*//Modification de la position.
            if (Speed.X != 0)
            {
                if (Speed.X > 0)
                {
                    Speed = new Vector2(Speed.X - 0.1f, Speed.Y);
                }
                else
                {
                    Speed = new Vector2(Speed.X + 0.1f, Speed.Y);
                }
            }
            if (Speed.Y != 0)
            {
                if (Speed.Y > 0)
                {
                    Speed = new Vector2(Speed.X, Speed.Y - 0.1f);
                }
                else
                {
                    Speed = new Vector2(Speed.X, Speed.Y + 0.1f);
                }
            }

            if (Speed.X > 2)
                Speed = new Vector2(2, Speed.Y);
            if (Speed.Y > 2)
                Speed = new Vector2(Speed.X, 2);
            */


            /*Position = new Vector2(Position.X + Speed.X, Position.Y + Speed.Y);
            hitBox.Location = new Point((int)Position.X, (int)Position.Y);*/
            Collisions();
            if (IsGrounded == false)
            {
                hitBox.Y += gravity;
            }
            oldPos = Position;
            //pos_s += dir * speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }

        /// <summary>
        /// Permet de gérer les entrées du joueur
        /// </summary>
        /// <param name="keyboardState">L'état du clavier à tester</param>
        /// <param name="mouseState">L'état de la souris à tester</param>
        /// <param name="joueurNum">Le numéro du joueur qui doit être surveillé</param>
        public override void HandleInput(KeyboardState keyboardState, MouseState mouseState)
        {
            /*if (keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.Down))
            {
                if (keyboardState.IsKeyDown(Keys.Up))
                {
                    if (keyboardState.IsKeyDown(Keys.Right))
                    {
                        Speed = new Vector2(Speed.X + Acc.X, Speed.Y);
                    }
                    if (keyboardState.IsKeyDown(Keys.Left))
                    {
                        Speed = new Vector2(Speed.X - Acc.X, Speed.Y);
                    }
                    Speed = new Vector2(Speed.X, Speed.Y - Acc.Y);
                }
                if (keyboardState.IsKeyDown(Keys.Down))
                {
                    if (keyboardState.IsKeyDown(Keys.Right))
                    {
                        Speed = new Vector2(Speed.X + Acc.X, Speed.Y);
                    }
                    if (keyboardState.IsKeyDown(Keys.Left))
                    {
                        Speed = new Vector2(Speed.X - Acc.X, Speed.Y);
                    }
                    Speed = new Vector2(Speed.X, Speed.Y + Acc.Y);
                }
            }
            else
            {
                if (keyboardState.IsKeyDown(Keys.Right))
                {
                    Speed = new Vector2(Speed.X + Acc.X, Speed.Y);
                }
                if (keyboardState.IsKeyDown(Keys.Left))
                {
                    Speed = new Vector2(Speed.X - Acc.X, Speed.Y);
                }
            }*/

            //Attaques

            if (keyboardState.IsKeyDown(Keys.A))
            {

                this.direction = Direction.A;
                this.AnimateAttack();
            }
            else
            {
                this.direction = Direction.Non;
            }

            // MOUVEMENT SPEED/DIRECTION
            if (keyboardState.IsKeyDown(Keys.Up))
            {
                this.hitBox.Y -= 20;
                this.direction = Direction.Up;
                this.AnimateJump();
                if (keyboardState.IsKeyDown(Keys.Left))
                {
                    this.hitBox.X = this.hitBox.X - 10;
                }
                if (keyboardState.IsKeyDown(Keys.Right))
                {
                    this.Effect = SpriteEffects.FlipHorizontally;
                    this.hitBox.X = this.hitBox.X + 10;
                }
            }
            else
            {
                if (IsOnGround().Equals(false))
                {
                    hitBox.Y += gravity;
                }
            }
            if (keyboardState.IsKeyDown(Keys.Down))
            {
                //this.Hitbox.Y += 5;
                this.direction = Direction.Down;
                this.AnimateCrouch();
            }
            if (keyboardState.IsKeyDown(Keys.Left) && keyboardState.IsKeyUp(Keys.Down) && keyboardState.IsKeyUp(Keys.Up))
            {
                this.hitBox.X -= 10;
                this.direction = Direction.Left;
                this.AnimateRunLeft();
                this.regard = 0;
            }
            if (keyboardState.IsKeyDown(Keys.Right) && keyboardState.IsKeyUp(Keys.Down) && keyboardState.IsKeyUp(Keys.Up))
            {
                this.hitBox.X = this.hitBox.X + 10;
                this.direction = Direction.Right;
                this.AnimateRunRight();
                this.regard = 1;

            }

            if (keyboardState.IsKeyUp(Keys.Up) && keyboardState.IsKeyUp(Keys.Down) && keyboardState.IsKeyUp(Keys.Right) && keyboardState.IsKeyUp(Keys.Left) && keyboardState.IsKeyUp(Keys.A))
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
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(ATexture.cursor8x8, hitBox, Color.Red);
            spriteBatch.Draw(ATexture.Crow, this.hitBox, new Rectangle((this.FrameCol - 1) * 189, (this.FrameLine - 1) * 180, 189, 180),
                Color.White, 0f, new Vector2(0, -200), this.Effect, 0f);
        }
    }
}
