﻿using System;
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

        public Enemy(Texture2D tex, float x, float y, int hp, int dmg, float sp)
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


        public bool Killed()
        {
            return !exists;
        }

    }
}
