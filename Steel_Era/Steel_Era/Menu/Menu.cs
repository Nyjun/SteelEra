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
        // MUSIQUE + BRUITAGES Xact method
        /*public AudioEngine audioEngine;
        public WaveBank waveBank;
        public SoundBank soundBank;
        public Cue currentSong;

        // Music volume.
        public static float musicVolume;*/


        KeyboardState keyOState;
        int lastState;

        private Cursor cursor;
        string menuSoundState;
        string menuDisplayState;

        //Son
        SoundEffect musicMenu;
        SoundEffectInstance musicMenuInst;
        int menuVolumeChangeBGM;
        float VolumeBGM; // Valeur en f 
        public static SoundEffect jump;
        public static SoundEffectInstance jumpInst;
        public static SoundEffect landing;
        public static SoundEffectInstance landingInst;
        public static SoundEffect attack1;
        public static SoundEffectInstance attack1Inst;
        int menuVolumeChangeSFX;
        float VolumeSFX;

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
        private Button button4 = new Button(ATexture.button2Off, ATexture.button2On, 0, 0, false, "o");
        private Button button5 = new Button(ATexture.button2Off, ATexture.button2On, 0, 0, false, "o");
        private Button button6 = new Button(ATexture.button2Off, ATexture.button2On, 0, 0, false, "o");
        private Button buttonVolume1 = new Button(ATexture.BoutonSound1, ATexture.BoutonSound1, 0, 0, false, " ");
        private Button buttonVolume2 = new Button(ATexture.BoutonSound2, ATexture.BoutonSound2, 0, 0, false, " ");
        private Button buttonVolume3 = new Button(ATexture.BoutonSound1, ATexture.BoutonSound1, 0, 0, false, " ");
        private Button buttonVolume4 = new Button(ATexture.BoutonSound2, ATexture.BoutonSound2, 0, 0, false, " ");



        /// <summary>
        /// Initialise les variables du Sprite
        /// </summary>
        public virtual void Initialize(Game1 game)
        {
            lastState = 1;

            menuSoundState = "on";
            menuDisplayState = "Windowed";
            menuVolumeChangeBGM = 50;
            menuVolumeChangeSFX = 50;
            //Son
            musicMenu = ATexture.musicMenu;
            musicMenuInst = musicMenu.CreateInstance();
            musicMenuInst.IsLooped = true;
            musicMenuInst.Volume = VolumeBGM;
            VolumeBGM = 0.5F;
            jump = ATexture.jump;
            jumpInst = jump.CreateInstance();
            jumpInst.Volume = VolumeSFX;
            landing = ATexture.landing;
            landingInst = landing.CreateInstance();
            landingInst.Volume = VolumeSFX;
            attack1 = ATexture.attack1;
            attack1Inst = attack1.CreateInstance();
            attack1Inst.Volume = VolumeSFX;
            VolumeSFX = 0.5F;




            // MUSIQUE + BRUITAGES Xact method
            /* audioEngine = new AudioEngine("Content/Menu/Music/MusicBG.xgs");
             waveBank = new WaveBank(audioEngine, "Content/Menu/Music/Wave Bank.xwb");
             soundBank = new SoundBank(audioEngine, "Content/Menu/Music/Sound Bank.xsb");
             currentSong = soundBank.GetCue("Menu");
             currentSong.Play();
             musicVolume = 1.0f;*/

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
                    button5.HandleInput(keyState, mouseState, cursor);
                    button6.HandleInput(keyState, mouseState, cursor);
                }

            }
            if (state != 0)
            {
                button1.HandleInput(keyState, mouseState, cursor);
                button2.HandleInput(keyState, mouseState, cursor);
                button3.HandleInput(keyState, mouseState, cursor);
                button4.HandleInput(keyState, mouseState, cursor);
                button5.HandleInput(keyState, mouseState, cursor);
                button6.HandleInput(keyState, mouseState, cursor);
                buttonVolume1.HandleInput(keyState, mouseState, cursor);
                buttonVolume2.HandleInput(keyState, mouseState, cursor);
                buttonVolume3.HandleInput(keyState, mouseState, cursor);
                buttonVolume4.HandleInput(keyState, mouseState, cursor);


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
                button4.IsVisible = false;
                button5.IsVisible = false;
                button6.IsVisible = false;
                buttonVolume1.IsVisible = false;
                buttonVolume2.IsVisible = false;
                buttonVolume3.IsVisible = false;
                buttonVolume4.IsVisible = false;


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
                button1.Text = "Sound  :  " + menuSoundState;
                button1.IsVisible = true;
                button2.Text = "Display  :  " + menuDisplayState;
                button2.IsVisible = true;
                button3.Text = "Return";
                button3.IsVisible = true;
                button4.Text = "BGM  Volume  :        " + menuVolumeChangeBGM;
                button4.IsVisible = true;
                button5.Text = "SFX  Volume  :        " + menuVolumeChangeSFX;
                button5.IsVisible = true;
                button6.Text = "Restore Defaults ";
                button6.IsVisible = true;
                buttonVolume1.IsVisible = true;
                buttonVolume2.IsVisible = true;
                buttonVolume3.IsVisible = true;
                buttonVolume4.IsVisible = true;

                //B1
                if (button1.IsHighLighted)
                    button1.Position = new Vector2(Game1.screenWidth - button1.Width, (Game1.screenHeight / 2));
                else
                    button1.Position = new Vector2(Game1.screenWidth - button1.Width + 20, (Game1.screenHeight / 2));
                //B2
                if (button2.IsHighLighted)
                    button2.Position = new Vector2(Game1.screenWidth - button1.Width + 15, (Game1.screenHeight / 2) + 3 * button1.Height + 15);
                else
                    button2.Position = new Vector2(Game1.screenWidth - button1.Width + 35, (Game1.screenHeight / 2) + 3 * button1.Height + 15);
                //B3
                if (button3.IsHighLighted)
                    button3.Position = new Vector2(Game1.screenWidth - button1.Width + 25, (Game1.screenHeight / 2) + 5 * button1.Height + 25);
                else
                    button3.Position = new Vector2(Game1.screenWidth - button1.Width + 45, (Game1.screenHeight / 2) + 5 * button1.Height + 25);
                //B4
                if (button4.IsHighLighted)
                {
                    button4.Position = new Vector2(Game1.screenWidth - button1.Width + 5, (Game1.screenHeight / 2) + button1.Height + 5);
                    buttonVolume1.Position = new Vector2(Game1.screenWidth - button1.Width + 170, (Game1.screenHeight / 2) + button1.Height + 9);
                    buttonVolume2.Position = new Vector2(Game1.screenWidth - button1.Width + 220, (Game1.screenHeight / 2) + button1.Height + 9);
                }
                else
                {
                    button4.Position = new Vector2(Game1.screenWidth - button1.Width + 25, (Game1.screenHeight / 2) + button1.Height + 5);
                    buttonVolume1.Position = new Vector2(Game1.screenWidth - button1.Width + 190, (Game1.screenHeight / 2) + button1.Height + 9);
                    buttonVolume2.Position = new Vector2(Game1.screenWidth - button1.Width + 240, (Game1.screenHeight / 2) + button1.Height + 9);
                }
                //B5
                if (button5.IsHighLighted)
                {
                    button5.Position = new Vector2(Game1.screenWidth - button1.Width + 10, (Game1.screenHeight / 2) + 2 * button1.Height + 10);
                    buttonVolume3.Position = new Vector2(Game1.screenWidth - button1.Width + 170, (Game1.screenHeight / 2) + 2 * button1.Height + 14);
                    buttonVolume4.Position = new Vector2(Game1.screenWidth - button1.Width + 220, (Game1.screenHeight / 2) + 2 * button1.Height + 14);
                }
                else
                {
                    button5.Position = new Vector2(Game1.screenWidth - button1.Width + 30, (Game1.screenHeight / 2) + 2 * button1.Height + 10);
                    buttonVolume3.Position = new Vector2(Game1.screenWidth - button1.Width + 190, (Game1.screenHeight / 2) + 2 * button1.Height + 14);
                    buttonVolume4.Position = new Vector2(Game1.screenWidth - button1.Width + 240, (Game1.screenHeight / 2) + 2 * button1.Height + 14);
                }
                //B6
                if (button6.IsHighLighted)
                    button6.Position = new Vector2(Game1.screenWidth - button1.Width + 20, (Game1.screenHeight / 2) + 4 * button1.Height + 20);
                else
                    button6.Position = new Vector2(Game1.screenWidth - button1.Width + 40, (Game1.screenHeight / 2) + 4 * button1.Height + 20);




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
                        musicMenuInst.Volume = VolumeBGM;
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

                if (buttonVolume1.Status == true)
                {

                    menuVolumeChangeBGM -= 10;
                    if (menuVolumeChangeBGM < 0 || menuVolumeChangeBGM == 0)
                    {
                        menuVolumeChangeBGM = 0;
                    }
                }
                if (buttonVolume2.Status == true)
                {
                    menuVolumeChangeBGM += 10;
                    if (menuVolumeChangeBGM > 100)
                    {
                        menuVolumeChangeBGM = 100;
                    }

                }
                switch (menuVolumeChangeBGM)
                {
                    case 0: VolumeBGM = 0F;
                        break;
                    case 10: VolumeBGM = 0.1F;
                        break;
                    case 20: VolumeBGM = 0.2F;
                        break;
                    case 30: VolumeBGM = 0.3F;
                        break;
                    case 40: VolumeBGM = 0.4F;
                        break;
                    case 50: VolumeBGM = 0.5F;
                        break;
                    case 60: VolumeBGM = 0.6F;
                        break;
                    case 70: VolumeBGM = 0.7F;
                        break;
                    case 80: VolumeBGM = 0.8F;
                        break;
                    case 90: VolumeBGM = 0.9F;
                        break;
                    case 100: VolumeBGM = 1F;
                        break;
                }

                if (buttonVolume3.Status == true)
                {
                    menuVolumeChangeSFX -= 10;
                    if (menuVolumeChangeSFX < 0 || menuVolumeChangeSFX == 0)
                    {
                        menuVolumeChangeSFX = 0;
                    }
                }
                if (buttonVolume4.Status == true)
                {
                    menuVolumeChangeSFX += 10;
                    if (menuVolumeChangeSFX > 100)
                    {
                        menuVolumeChangeSFX = 100;
                    }
                }
                switch (menuVolumeChangeSFX)
                {
                    case 0: VolumeSFX = 0F;
                        break;
                    case 10: VolumeSFX = 0.1F;
                        break;
                    case 20: VolumeSFX = 0.2F;
                        break;
                    case 30: VolumeSFX = 0.3F;
                        break;
                    case 40: VolumeSFX = 0.4F;
                        break;
                    case 50: VolumeSFX = 0.5F;
                        break;
                    case 60: VolumeSFX = 0.6F;
                        break;
                    case 70: VolumeSFX = 0.7F;
                        break;
                    case 80: VolumeSFX = 0.8F;
                        break;
                    case 90: VolumeSFX = 0.9F;
                        break;
                    case 100: VolumeSFX = 1F;
                        break;

                }
                if (button6.Status == true)
                {
                    button6.Status = false;
                    menuSoundState = "on";
                    musicMenuInst.Play();
                    menuVolumeChangeBGM = 50;
                    VolumeBGM = 0.5f;
                    musicMenuInst.Volume = VolumeBGM;
                    menuVolumeChangeSFX = 50;
                    VolumeSFX = 0.5f;
                    jumpInst.Volume = VolumeSFX;
                    landingInst.Volume = VolumeSFX;
                    attack1Inst.Volume = VolumeSFX;

                }
            }

            if (state != 0)
            {
                lastState = state;
                if (menuSoundState == "on")
                    musicMenuInst.Play();
                musicMenuInst.Volume = VolumeBGM;
            }
            else
            {
                musicMenuInst.Stop();
            }

            if (state == 0)
            {
                jumpInst.Volume = VolumeSFX;
                landingInst.Volume = VolumeSFX;
                attack1Inst.Volume = VolumeSFX;
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
                button4.Draw(spriteBatch, gameTime);
                button5.Draw(spriteBatch, gameTime);
                button6.Draw(spriteBatch, gameTime);
                buttonVolume1.Draw(spriteBatch, gameTime);
                buttonVolume2.Draw(spriteBatch, gameTime);
                buttonVolume3.Draw(spriteBatch, gameTime);
                buttonVolume4.Draw(spriteBatch, gameTime);

                cursor.Draw(spriteBatch, gameTime);
            }
        }

        //public void Quit (GameTime

    }
}
