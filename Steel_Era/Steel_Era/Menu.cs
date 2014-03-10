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
        public bool quit;

        SoundEffect musicMenu;
        SoundEffectInstance musicMenuInst;
        private Cursor cursor;

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


        private Button button1 = new Button(ATexture.button2Off, ATexture.button2On, 0, 0, false, true, "Play");
        private Button button2 = new Button(ATexture.button2Off, ATexture.button2On, 0, 0, false, true, "Quit");
        private Button button3 = new Button(ATexture.button2Off, ATexture.button2On, 0, 0, false, false, "o");
        private Button button4 = new Button(ATexture.button2Off, ATexture.button2On, 0, 0, false, false, "o");



        /// <summary>
        /// Initialise les variables du Sprite
        /// </summary>
        public virtual void Initialize()
        {
            quit = false;
            lastState = 1;


            //background = new Sprite(ATexture.forestTemple, false, 0, 0);
            musicMenu = ATexture.musicMenu;
            musicMenuInst = musicMenu.CreateInstance();
            musicMenuInst.IsLooped = true;

            cursor = new Cursor(ATexture.cursor8x8, false, 0, 0);
            background = new Sprite(ATexture.BG_Main_Menu, false, 0, 0);

            state = 1;
        }

        /// <summary>
        /// Charge le background voulu grâce au ContentManager donné
        /// </summary>
        /// <param name="content">Le ContentManager qui chargera l'image</param>
        /// <param name="assetName">Assetname, le nom de l'image à charger pour ce background</param>
        public void LoadContent(ContentManager content)
        {
            background.LoadContent(content, "BG_Main_Menu");
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
            cursor.HandleInput(keyState, mouseState);
            if (keyState.IsKeyDown(Keys.Escape) && keyOState.IsKeyUp(Keys.Escape))
            {
                if (state == 0)
                {
                    state = lastState;
                    lastState = state;
                }
                else
                {
                    state = 0;
                    button1.HandleInput(keyState, mouseState);
                    button2.HandleInput(keyState, mouseState);
                }
            }
            if (state != 0)
            {
                button1.HandleInput(keyState, mouseState);
                button2.HandleInput(keyState, mouseState);
            }


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
                //button1.Position = new Vector2(Game1.screenWidth - button1.Width + 20,(Game1.screenHeight/2));//(background.Width - button1.Width, background.Height - button1.Height);
                button1.Text = "Play";
                button1.IsVisible = true;
                //button2.Position = new Vector2(Game1.screenWidth - button1.Width + 30, (Game1.screenHeight/2) + button1.Height + 5);
                button2.Text = "Quit";
                button2.IsVisible = true;
                button2.Status = false;
                if (button1.IsHighLighted)
                    button1.Position = new Vector2(Game1.screenWidth - button1.Width, (Game1.screenHeight / 2));
                else
                    button1.Position = new Vector2(Game1.screenWidth - button1.Width + 20, (Game1.screenHeight / 2));
                if (button2.IsHighLighted)
                    button2.Position = new Vector2(Game1.screenWidth - button1.Width + 5, (Game1.screenHeight / 2) + button1.Height + 5);
                else
                    button2.Position = new Vector2(Game1.screenWidth - button1.Width + 25, (Game1.screenHeight / 2) + button1.Height + 5);
                if (button1.Status == true)
                {
                    state = 0;
                    button1.Status = false;
                }
                if (button2.Status == true)
                {
                    quit = true;
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
            {
                lastState = state;
                musicMenuInst.Play();
            }
            else
            {
                musicMenuInst.Stop();
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime, Rectangle screenRectangle)
        {
            if (state != 0)
            {
                spriteBatch.Draw(background.Texture, screenRectangle, Color.White);
                button1.Draw(spriteBatch, gameTime);
                button2.Draw(spriteBatch, gameTime);

                cursor.Draw(spriteBatch, gameTime);
            }
        }

    }
}
