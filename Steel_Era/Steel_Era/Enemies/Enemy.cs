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

        public Enemy(Texture2D tex, float x, float y, int hp, int dmg, float sp)
            : base(tex, x, y)
        {
            hitPoints = hp;
            damages = dmg;
            Speed = sp;

            this.hitbox = new Rectangle(0, 0, 90, 180);
            this.Spritebox = new Rectangle(0, 0, 189, 180);
            this.FrameLine = 1;
            this.FrameCol = 1;
            this.Timer = 0; // Intervalle entre 2 boucles d'animations
            this.AnimationSpeed = 5; // Vitesse d'animation
           
            
      
        }

        protected int hitPoints;
        protected int damages;
        protected Rectangle hitbox;
        Rectangle Spritebox;
        int FrameLine;
        int FrameCol;
        int Timer;
        int AnimationSpeed;
        Direction direction;

        public void MoveLeft()
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
        
        

        public Rectangle Hitbox // Récupère la position du joueur
        {
            get { return hitbox; }
            set { hitbox = value; }
        }

        public override void Update(GameTime gameTime)
        {
           
           

            if (Hitbox.X < hitbox.X)
            {
                this.hitbox.X = this.hitbox.X - 2;
                this.direction = Direction.Left;
                this.MoveLeft();
               
            }
            else
                if (Hitbox.X > hitbox.X)
                { 
                
                }
 

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            base.Draw(spriteBatch, gameTime);
        }
    }
}
