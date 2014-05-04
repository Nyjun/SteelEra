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

        public Button(Texture2D tex1, Texture2D tex2, float x, float y, bool visible, string _text)
            : base(tex1, x, y)
        {
            Texture = tex1;
            texture2 = tex2;
            Position = new Vector2(x, y);
            text = _text;
        }

        MouseState oldMouse;
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
        public bool oldStatus;

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





        /// <summary>
        /// Permet de gérer les entrées du joueur
        /// </summary>
        /// <param name="keyState">L'état du clavier à tester</param>
        /// <param name="mouseState">L'état de la souris à tester</param>
        /// <param name="joueurNum">Le numéro du joueur qui doit être surveillé</param>
        public void HandleInput(KeyboardState keyState, MouseState mouseState, Cursor cursor)
        {
            if (mouseState.LeftButton == ButtonState.Pressed && cursor.Position.X > Position.X && cursor.Position.X < (Position.X + Width) && cursor.Position.Y > Position.Y && cursor.Position.Y < (Position.Y + Height) && isVisible == true && oldMouse.LeftButton == ButtonState.Released)
            {
                status = true;
            }
            else
            {
                status = false;
            }


            if (cursor.Position.X > Position.X && cursor.Position.X < (Position.X + Width) && cursor.Position.Y > Position.Y && cursor.Position.Y < (Position.Y + Height))
            {
                isHighLighted = true;
            }
            else
            {
                isHighLighted = false;
            }
            oldMouse = mouseState;
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
                    spriteBatch.DrawString(Fonts.Font1, text, new Vector2(Position.X + (Texture.Bounds.Width / 5), Position.Y + (Texture.Bounds.Height / 10)), Color.White);
                }
                else
                {
                    spriteBatch.Draw(Texture2, Position, Color.White);
                    spriteBatch.DrawString(Fonts.Font1, text, new Vector2(Position.X + (Texture.Bounds.Width / 5), Position.Y + (Texture.Bounds.Height / 10)), Color.White);//new Vector2(Center.X - ((4 * Width) / 5), Center.Y - ((4 * Height) / 5)), Color.White);
                }
            }
        }
    }
}
