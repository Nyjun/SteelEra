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


    class Sprite
    {
        public Sprite(Texture2D tex, float _x, float _y)
        {
            texture = tex;
            x = _x;
            y = _y;
            width = tex.Bounds.Width;
            height = tex.Bounds.Height;
            hitBox = new Rectangle((int)pos.X, (int)pos.Y, (int)width, (int)height);
        }
        protected Vector2 oldPos;
        protected float x;
        protected float y;
        ///////////////////////////////
        //Caracteristiques de l'image//
        ///////////////////////////////
        /// <summary>
        /// Récupère ou définit l'image du sprite.
        /// </summary>
        public Texture2D Texture
        {
            get { return texture; }
            set { texture = value; }
        }
        private Texture2D texture;
        /// <summary>
        /// Hauteur de l'image du sprite.
        /// </summary>
        public float Height
        {
            get { return height; }
            set { height = value; }
        }
        private float height;
        /// <summary>
        /// Largeur de l'image du sprite.
        /// </summary>
        public float Width
        {
            get { return width; }
            set { width = value; }
        }
        private float width;
        /// <summary>
        /// Position du coin haut-gauche de l'image du sprite.
        /// </summary>
        public Vector2 Position
        {
            get { return pos; }
            set { pos = value; }
        }
        private Vector2 pos;



        ///////////////////////////////////////
        //Caracteristiques de l'objet in-game//
        ///////////////////////////////////////

        /// <summary>
        /// ID du sprite.
        /// </summary>
        public string ID
        {
            get { return id; }
            set { id = value; }
        }
        private string id;
        /// <summary>
        /// HitBox du sprite.
        /// </summary>
        public Rectangle hitBox;/*
        {
            get { return hitBox; }
            set { hitBox = value; }
        }
        private Rectangle hitBox;*/

        protected Vector2 Center
        {
            get { return center; }
            set { center = value; }
        }
        private Vector2 center;




        //////////////////////////////////////////
        //Caracteristiques physiques de l'objet.//
        //////////////////////////////////////////

        /// <summary>
        /// Masse de l'objet.
        /// </summary>
        public float Mass
        {
            get { return mass; }
            set { mass = value; }
        }
        private float mass;
        /// <summary>
        /// Poids de l'objet.
        /// </summary>
        public Vector2 Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        private Vector2 weight;

        /// <summary>
        /// Vitesse de l'objet.
        /// </summary>
        public float Speed
        {
            get { return speed; }
            set { speed = value; }
        }
        private float speed;








        /// <summary>
        /// Initialise les variables du Sprite
        /// </summary>
        public virtual void Initialize()
        {

            //Game1.ListSprite.Add
            height = texture.Bounds.Height;
            width = texture.Bounds.Width;
            pos = new Vector2(x, y);
            
            center = new Vector2(hitBox.Center.X, hitBox.Center.Y);//new Vector2(pos.X + (width / 2), pos.Y + (height / 2));
        }

        /// <summary>
        /// Charge l'image voulue grâce au ContentManager donné
        /// </summary>
        /// <param name="content">Le ContentManager qui chargera l'image</param>
        /// <param name="assetName">L'asset name de l'image à charger pour ce Sprite</param>
        public virtual void LoadContent(ContentManager content, string assetName)
        {

            //texture = content.Load<Texture2D>(assetName);
        }

        /// <summary>
        /// Met à jour les variables du sprite
        /// </summary>
        /// <param name="gameTime">Le GameTime associé à la frame</param>
        public virtual void Update(GameTime gameTime)
        {
            

            //Modification de la position.


            oldPos = pos;
            //pos_s += dir * speed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        }

        /// <summary>
        /// Permet de gérer les entrées du joueur
        /// </summary>
        /// <param name="keyboardState">L'état du clavier à tester</param>
        /// <param name="mouseState">L'état de la souris à tester</param>
        /// <param name="joueurNum">Le numéro du joueur qui doit être surveillé</param>
        public virtual void HandleInput(KeyboardState keyboardState, MouseState mouseState)
        {
        }

        /// <summary>
        /// Dessine le sprite en utilisant ses attributs et le spritebatch donné
        /// </summary>
        /// <param name="spriteBatch">Le spritebatch avec lequel dessiner</param>
        /// <param name="gameTime">Le GameTime de la frame</param>
        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {

            spriteBatch.Draw(texture, pos, Color.White);

        }

        protected void Collisions()
        {
            Rectangle h;
            for (int i = 0; i < Physics.ListObstacle.Count; i++)
            {
                if (hitBox.Intersects(Physics.ListObstacle.ElementAt(i).hitBox))
                {
                    h = Physics.ListObstacle.ElementAt(i).hitBox;
                    if (hitBox.Bottom > h.Bottom && hitBox.Top < h.Top)
                    {
                        if (hitBox.Right > h.Left && hitBox.Left < h.Left)
                        {
                            pos = new Vector2(pos.X - (hitBox.Right - h.Left), pos.Y);
                        }
                        else
                        {
                            if (hitBox.Left < h.Right && hitBox.Right > h.Right)
                            {
                                pos = new Vector2(pos.X + (h.Right - hitBox.Left), pos.Y);
                            }
                            else
                            {
                                if (hitBox.Left > h.Left && hitBox.Right < h.Right)
                                {
                                    pos = new Vector2(pos.X, h.Top - hitBox.Height);
                                }
                            }
                        }
                    }
                    else
                    {
                        if (hitBox.Right > h.Left && hitBox.Left < h.Left && (hitBox.Bottom < h.Top || hitBox.Top > h.Bottom))
                        {
                            pos = new Vector2(pos.X - (hitBox.Right - h.Left), pos.Y);
                        }
                        if (hitBox.Left < h.Right && hitBox.Right > h.Right && (hitBox.Bottom < h.Top || hitBox.Top > h.Bottom))
                        {
                            pos = new Vector2(pos.X + (h.Right - hitBox.Left), pos.Y);
                        }
                        if (hitBox.Bottom > h.Top && hitBox.Top < h.Top)
                        {
                            pos = new Vector2(pos.X, pos.Y - (hitBox.Bottom - h.Top));
                        }
                        if (hitBox.Top < h.Bottom && hitBox.Bottom > h.Bottom)
                        {
                            pos = new Vector2(pos.X, pos.Y + (h.Bottom - hitBox.Top));
                        }
                    }

                }
            }
        }
    }
}
