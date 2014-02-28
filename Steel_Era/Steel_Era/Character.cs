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
        public Character(Texture2D _tex, float x, float y, string _ID, bool _player, float _mass)
            : base(_tex, true, x, y)
        {
            ID = _ID;
            Mass = _mass;
            Weight = new Vector2(0f, 9.81f * _mass);
        }


        /// <summary>
        /// Met à jour les variables du character
        /// </summary>
        /// <param name="gameTime">Le GameTime associé à la frame</param>
        public override void Update(GameTime gameTime)
        {
            
            

            //Modification de la position.
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



            Position = new Vector2(Position.X + Speed.X, Position.Y + Speed.Y);
            hitBox.Location = new Point((int)Position.X, (int)Position.Y);
            Collisions();
            
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
            if (keyboardState.IsKeyDown(Keys.Up) || keyboardState.IsKeyDown(Keys.Down))
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
            }

        }
    }
}
