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

namespace Steel_Era
{
    abstract class Enemy : Sprite
    {
        public enum Direction
        {
            Left, Right, Non
        }
        public static int HpDifficult;
        public Enemy(Texture2D tex, float x, float y, int hp, int dmg, float sp, Stages.Stage stage)
            : base(tex, x, y)
        {
            hitPoints = hp;
            damages = dmg;
            Speed = sp;

            IsGrounded = false;
        }

        public int hitPoints;
        public int damages;
        protected Rectangle Spritebox;
        public Rectangle damagebox;
        public bool IsGrounded;
        protected Stages.Stage stage;


        public bool Killed()
        {
            return !exists;
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
