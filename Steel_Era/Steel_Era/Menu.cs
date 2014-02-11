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
    class Menu
    {
        KeyboardState keyOState;
        int lastState;

        /// <summary>
        /// 1 : main menu.
        /// 2 : solo.
        /// 3 : multiplayer.
        /// 4 : options.
        /// </summary>
        public int State
        {
            get { return state; }
            set { state = value; }
        }
        private int state;


        /// <summary>
        /// Récupère ou définit le background du menu.
        /// </summary>
        public Sprite Background
        {
            get { return background; }
            set { background = value; }
        }
        private Sprite background;

        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; }
        }
        private bool isVisible;


        private Button button1 = new Button(ATexture.buttonOff, ATexture.buttonOn, Vector2.Zero, false, true);
        private Button button2 = new Button(ATexture.buttonOff, ATexture.buttonOn, Vector2.Zero, false, true);
        private Button button3 = new Button(ATexture.buttonOff, ATexture.buttonOn, Vector2.Zero, false, false);
        private Button button4 = new Button(ATexture.buttonOff, ATexture.buttonOn, Vector2.Zero, false, false);



        /// <summary>
        /// Initialise les variables du Sprite
        /// </summary>
        public virtual void Initialize()
        {
            lastState = 1;
            button1.Height = 128;
            button1.Width = 256;
            button2.Height = 128;
            button2.Width = 256;

            background = new Sprite(ATexture.forestTemple, false);

            state = 0;
        }

        /// <summary>
        /// Charge le background voulue grâce au ContentManager donné
        /// </summary>
        /// <param name="content">Le ContentManager qui chargera l'image</param>
        /// <param name="assetName">L'asset name de l'image à charger pour ce background</param>
        public void LoadContent(ContentManager content)
        {
            background.LoadContent(content, "forest_temple");
            button1.LoadContent(content, "Button_test_1_off", "Button_test_1_on");
            button2.LoadContent(content, "Button_test_1_off", "Button_test_1_on");
        }

        /// <summary>
        /// Permet de gérer les entrées du joueur
        /// </summary>
        /// <param name="keyboardState">L'état du clavier à tester</param>
        /// <param name="mouseState">L'état de la souris à tester</param>
        /// <param name="joueurNum">Le numéro du joueur qui doit être surveillé</param>
        public virtual void HandleInput(KeyboardState keyState, MouseState mouseState)
        {
            if(keyState.IsKeyDown(Keys.Escape) && keyOState.IsKeyUp(Keys.Escape))
            {
                if (state == 0)
                {
                    state = lastState;
                    lastState = state;
                }
                else
                    state = 0;
            }
            button1.HandleInput(keyState, mouseState);
            button2.HandleInput(keyState, mouseState);

            keyOState = keyState;
        }
        


        /// <summary>
        /// Met à jour les variables du sprite
        /// </summary>
        /// <param name="gameTime">Le GameTime associé à la frame</param>
        public virtual void Update(GameTime gameTime)
        {

            if (state == 1)
            {
                button1.Position = new Vector2(0*background.Width + button1.Width, 0*background.Height - 0*button1.Height);
                button1.IsVisible = true;
                button2.IsVisible = false;
                button2.Status = false;
                if (button1.Status == true)
                {
                    state = 2;
                }
            }
            if (state == 2)
            {
                button2.Position = new Vector2(0, 0 * background.Height - 0 * button2.Height);
                button1.IsVisible = false;
                button1.Status = false;
                button2.IsVisible = true;
                if (button2.Status == true)
                {
                    state = 1;
                }
            }
            if (state != 0)
                lastState = state;
        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime, Rectangle screenRectangle)
        {
            if (state != 0)
            {
                spriteBatch.Draw(background.Texture, screenRectangle, Color.White);
                button1.Draw(spriteBatch, gameTime);
                button2.Draw(spriteBatch, gameTime);
            }
        }

    }
}
