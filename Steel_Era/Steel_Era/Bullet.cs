﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace Steel_Era
{
    class Bullet
    {
        //public Rectangle boundingBox;
        public Texture2D texture;
        //public Vector2 origin;
        public Vector2 position;
        public bool IsVisible;
        public float speed;
        public Rectangle hitbox;

        //Constructor
        public Bullet(Texture2D newTexture)
        {
            speed = 20;
            texture = newTexture;
            IsVisible = false;

        }

        //Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            if (HUD.Mana >= 0)
            {
                spriteBatch.Draw(texture, position, Color.White);
            }
        }
    }
}
