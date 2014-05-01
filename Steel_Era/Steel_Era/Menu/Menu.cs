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

        SoundEffect musicMenu;
        SoundEffectInstance musicMenuInst;
        private Cursor cursor;
        string menuSoundState;
        string menuDisplayState;

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


        private Button button1 = new Button(ATexture.button2Off, ATexture.button2On, 0, 0, true, "Play");
        private Button button2 = new Button(ATexture.button2Off, ATexture.button2On, 0, 0, true, "Quit");
        private Button button3 = new Button(ATexture.button2Off, ATexture.button2On, 0, 0, false, "o");
        private Button button4 = new Button(ATexture.button2Off, ATexture.button2On, 0, 0,  false, "o");


        

        /// <summary>
        /// Initialise les variables du Sprite
        /// </summary>
        public virtual void Initialize(Game1 game)
        {
            lastState = 1;
            musicMenu = ATexture.musicMenu;
            musicMenuInst = musicMenu.CreateInstance();
            musicMenuInst.IsLooped = true;
            menuSoundState = "on";
            menuDisplayState = "Windowed";

            cursor = new Cursor(ATexture.cursor8x8, game);
            background = new Sprite(ATexture.BG_Main_Menu, 0, 0);

            state = 1;
        }


        /// <summary>
        /// Permet de gérer les entrées du joueur
        /// </summary>
        /// <param name="keyboardState">L'état du clavier à tester</param>
        /// <param name="mouseState">L'état de la souris à tester</param>
        /// <param name="joueurNum">Le numéro du joueur qui doit être surveillé</param>
        public virtual void HandleInput(KeyboardState keyState, MouseState mouseState, Game1 game)
        {
            cursor.HandleInput(keyState, mouseState, game);
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
                    button1.HandleInput(keyState, mouseState, cursor);
                    button2.HandleInput(keyState, mouseState, cursor);
                    button3.HandleInput(keyState, mouseState, cursor);
                    button4.HandleInput(keyState, mouseState, cursor);
                }
            }
            if (state != 0)
            {
                button1.HandleInput(keyState, mouseState, cursor);
                button2.HandleInput(keyState, mouseState, cursor);
                button3.HandleInput(keyState, mouseState, cursor);
                button4.HandleInput(keyState, mouseState, cursor);
            }


            keyOState = keyState;
        }
        


        /// <summary>
        /// Met à jour les variables du sprite
        /// </summary>
        /// <param name="gameTime">Le GameTime associé à la frame</param>
        public virtual void Update(GameTime gameTime, Game1 game, KeyboardState keyState, MouseState mouseState)
        {

            this.HandleInput(keyState, mouseState, game);
            if (state == 1)
            {
                button1.Text = "Play";
                button1.IsVisible = true;
                button2.Text = "Options";
                button2.IsVisible = true;
                button3.Text = "Quit";
                button3.IsVisible = true;
                //B1
                if (button1.IsHighLighted)
                    button1.Position = new Vector2(Game1.screenWidth - button1.Width, (Game1.screenHeight / 2));
                else
                    button1.Position = new Vector2(Game1.screenWidth - button1.Width + 20, (Game1.screenHeight / 2));
                //B2
                if (button2.IsHighLighted)
                    button2.Position = new Vector2(Game1.screenWidth - button1.Width + 5, (Game1.screenHeight / 2) + button1.Height + 5);
                else
                    button2.Position = new Vector2(Game1.screenWidth - button1.Width + 25, (Game1.screenHeight / 2) + button1.Height + 5);
                //B3
                if (button3.IsHighLighted)
                    button3.Position = new Vector2(Game1.screenWidth - button1.Width + 10, (Game1.screenHeight / 2) + 2*button1.Height + 10);
                else
                    button3.Position = new Vector2(Game1.screenWidth - button1.Width + 30, (Game1.screenHeight / 2) + 2*button1.Height + 10);
                

                if (button1.Status == true)
                {
                    state = 0;
                    button1.Status = false;
                }
                if (button2.Status == true)
                {
                    state = 2;
                    button2.Status = false;
                }
                if (button3.Status == true)
                {
                    game.Exit();
                    button3.Status = false;
                }
            }
            if (state == 2)
            {
                button1.Text = "Sound : " + menuSoundState;
                button1.IsVisible = true;
                button2.Text = "Display : " + menuDisplayState;
                button2.IsVisible = true;
                button3.Text = "Return";
                button3.IsVisible = true;
                
                //B1
                if (button1.IsHighLighted)
                    button1.Position = new Vector2(Game1.screenWidth - button1.Width, (Game1.screenHeight / 2));
                else
                    button1.Position = new Vector2(Game1.screenWidth - button1.Width + 20, (Game1.screenHeight / 2));
                //B2
                if (button2.IsHighLighted)
                    button2.Position = new Vector2(Game1.screenWidth - button1.Width + 5, (Game1.screenHeight / 2) + button1.Height + 5);
                else
                    button2.Position = new Vector2(Game1.screenWidth - button1.Width + 25, (Game1.screenHeight / 2) + button1.Height + 5);
                //B3
                if (button3.IsHighLighted)
                    button3.Position = new Vector2(Game1.screenWidth - button1.Width + 10, (Game1.screenHeight / 2) + 2 * button1.Height + 10);
                else
                    button3.Position = new Vector2(Game1.screenWidth - button1.Width + 30, (Game1.screenHeight / 2) + 2 * button1.Height + 10);
                if (button1.Status == true)
                {
                    button1.Status = false;
                    if (menuSoundState == "on")
                    {
                        menuSoundState = "off";
                        musicMenuInst.Stop();
                        button1.oldStatus = button1.Status;
                    }
                    else
                    {
                        menuSoundState = "on";
                        musicMenuInst.Play();
                        button1.oldStatus = button1.Status;
                    }
                    
                }
                if (button2.Status == true)
                {
                    button2.Status = false;
                    if (menuDisplayState == "Windowed")
                    {
                        menuDisplayState = "Full Screen";
                        game.graphics.ToggleFullScreen();
                        button2.oldStatus = button2.Status;
                    }
                    else
                    {
                        menuDisplayState = "Windowed";
                        game.graphics.ToggleFullScreen();
                        button2.oldStatus = button2.Status;
                    }

                }
                if (button3.Status == true)
                {
                    button3.Status = false;
                    state = 1;
                    
                }
            }
            if (state != 0)
            {
                lastState = state;
                if (menuSoundState == "on")
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
                button3.Draw(spriteBatch, gameTime);

                cursor.Draw(spriteBatch, gameTime);
            }
        }

        //public void Quit (GameTime

    }
}
