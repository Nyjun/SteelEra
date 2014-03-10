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
    class Button : Sprite
    {

        public Button(Texture2D tex1, Texture2D tex2, float x, float y, bool animated, bool visible, string _text)
            : base(tex1, animated, x, y)
        {
            Texture = tex1;
            texture2 = tex2;
            Position = new Vector2(x, y);
            text = _text;
        }

        /// <summary>
        /// Highlighted button texture.
        /// </summary>
        public Texture2D Texture2
        {
            get { return texture2; }
            set { texture2 = value; }
        }
        private Texture2D texture2;

        /// <summary>
        /// Text visible on the button.
        /// </summary>
        public string Text
        {
            get { return text; }
            set { text = value; }
        }
        private string text;

        /// <summary>
        /// Boutton pressed or not.
        /// </summary>
        public bool Status
        {
            get { return status; }
            set { status = value; }
        }
        private bool status;

        /// <summary>
        /// Boutton Highlighted or not.
        /// </summary>
        public bool IsHighLighted
        {
            get { return isHighLighted; }
        }
        private bool isHighLighted;

        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; }
        }
        private bool isVisible;

        /*/// <summary>
        /// Initialise les variables du Sprite
        /// </summary>
        public override void Initialize()
        {

            //Game1.ListSprite.Add
            isVisible = true;
            status = false;
        }*/





        /// <summary>
        /// Charge l'image voulue grâce au ContentManager donné
        /// </summary>
        /// <param name="content">Le ContentManager qui chargera l'image</param>
        /// <param name="assetName">L'asset name de l'image à charger pour ce Sprite</param>
        public virtual void LoadContent(ContentManager content, string assetName, string assetName2)
        {
            Texture = content.Load<Texture2D>(assetName);
            texture2 = content.Load<Texture2D>(assetName2);
        }

        /// <summary>
        /// Permet de gérer les entrées du joueur
        /// </summary>
        /// <param name="keyState">L'état du clavier à tester</param>
        /// <param name="mouseState">L'état de la souris à tester</param>
        /// <param name="joueurNum">Le numéro du joueur qui doit être surveillé</param>
        public override void HandleInput(KeyboardState keyState, MouseState mouseState)
        {
            if (mouseState.LeftButton == ButtonState.Pressed && mouseState.X > Position.X && mouseState.X < (Position.X + Width) && mouseState.Y > Position.Y && mouseState.Y < (Position.Y + Height) && isVisible == true)
            {
                status = true;
            }


            if (mouseState.X > Position.X && mouseState.X < (Position.X + Width) && mouseState.Y > Position.Y && mouseState.Y < (Position.Y + Height) )
            {
                isHighLighted = true;
            }
            else
            {
                isHighLighted = false;
            }


        }

        /// <summary>
        /// Met à jour les variables du sprite
        /// </summary>
        /// <param name="gameTime">Le GameTime associé à la frame</param>
        public override void Update(GameTime gameTime)
        {
            
            
        }

        /// <summary>
        /// Dessine le sprite en utilisant ses attributs et le spritebatch donné
        /// </summary>
        /// <param name="spriteBatch">Le spritebatch avec lequel dessiner</param>
        /// <param name="gameTime">Le GameTime de la frame</param>
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (status == false && isVisible == true)
            {
                if (isHighLighted == false)
                {
                    spriteBatch.Draw(Texture, Position, Color.White);
                    spriteBatch.DrawString(Fonts.Font1, text, new Vector2(Position.X + (Texture.Bounds.Width/2), Position.Y + (Texture.Bounds.Height/2)), Color.White);
                }
                else
                {
                    spriteBatch.Draw(Texture2, Position, Color.White);
                    spriteBatch.DrawString(Fonts.Font1, text, new Vector2(Position.X + (Texture.Bounds.Width / 2), Position.Y + (Texture.Bounds.Height / 2)), Color.White);//new Vector2(Center.X - ((4 * Width) / 5), Center.Y - ((4 * Height) / 5)), Color.White);
                }
            }
        }
    }
}
