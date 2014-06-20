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
        public Menu(Stages.Stage1 _stage1, Stages.Stage2 _stage2)
        {
            stage1 = _stage1;
            stage2 = _stage2;
        }

        Stages.Stage1 stage1;
        Stages.Stage2 stage2;
        public static int lvl_selected;
        bool Drawmessage;
        public static bool MultiOn;

        KeyboardState keyOState;
        int lastState;
        int Timer;
        bool playIntro;

        private Cursor cursor;
        string menuSoundState;
        string menuDisplayState;
        public static bool Freezed;
        public static int selected;

        //Son
        SoundEffect musicMenu;
        SoundEffectInstance musicMenuInst;
        SoundEffect gameMusic;
        SoundEffectInstance gameMusicInst;
        SoundEffect music_project;
        SoundEffectInstance music_projectInst;
        int menuVolumeChangeBGM;
        float VolumeBGM; // Valeur en f 
        public static SoundEffect jump;
        public static SoundEffectInstance jumpInst;
        public static SoundEffect landing;
        public static SoundEffectInstance landingInst;
        public static SoundEffect attack1;
        public static SoundEffectInstance attack1Inst;
        public static SoundEffect run_ground;
        public static SoundEffectInstance run_groundInst;
        public static SoundEffect mouse_enter;
        public static SoundEffectInstance mouse_enterInst;
        public static SoundEffect voice_dead;
        public static SoundEffectInstance voice_deadInst;
        public static SoundEffect get_item;
        public static SoundEffectInstance get_itemInst;
        int menuVolumeChangeSFX;
        public static float VolumeSFX;


        //VIDEO 

        Video Intro;
        VideoPlayer videoPlayer = new VideoPlayer();
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
        private Sprite backgroundPause;
        private Sprite backgroundGO;

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
        private Button button7 = new Button(ATexture.button2Off, ATexture.button2On, 0, 0, false, "o");
        private Button buttonVolume1 = new Button(ATexture.BoutonSound1, ATexture.BoutonSound1, 0, 0, false, " ");
        private Button buttonVolume2 = new Button(ATexture.BoutonSound2, ATexture.BoutonSound2, 0, 0, false, " ");
        private Button buttonVolume3 = new Button(ATexture.BoutonSound1, ATexture.BoutonSound1, 0, 0, false, " ");
        private Button buttonVolume4 = new Button(ATexture.BoutonSound2, ATexture.BoutonSound2, 0, 0, false, " ");



        /// <summary>
        /// Initialise les variables du Sprite
        /// </summary>
        public virtual void Initialize(Game1 _game)
        {
            lastState = 1;
            //VIDEO 
          
            Intro = ATexture.Intro;
            if (state != 7)
            {
                Timer = 0;
                Freezed = false;
                playIntro = true;
                lvl_selected = 0;
                Drawmessage = false;
                menuSoundState = "on";
                menuDisplayState = "Windowed";
                menuVolumeChangeBGM = 70;
                menuVolumeChangeSFX = 30;
                selected = 0;
                
                state = 1;
                //Son
                musicMenu = ATexture.musicMenu;
                musicMenuInst = musicMenu.CreateInstance();
                musicMenuInst.IsLooped = true;
                gameMusic = ATexture.gameMusic;
                gameMusicInst = gameMusic.CreateInstance();
                gameMusicInst.IsLooped = true;
                music_project = ATexture.music_project;
                music_projectInst = music_project.CreateInstance();
                music_projectInst.IsLooped = true;
                gameMusicInst.Volume = VolumeBGM;
                VolumeBGM = 0.7F;
                jump = ATexture.jump;
                jumpInst = jump.CreateInstance();
                jumpInst.Volume = VolumeSFX;
                landing = ATexture.landing;
                landingInst = landing.CreateInstance();
                landingInst.Volume = VolumeSFX;
                attack1 = ATexture.attack1;
                attack1Inst = attack1.CreateInstance();
                attack1Inst.Volume = VolumeSFX;
                run_ground = ATexture.run_ground;
                run_groundInst = run_ground.CreateInstance();
                run_groundInst.Volume = VolumeSFX;
                voice_dead = ATexture.voice_dead;
                voice_deadInst = voice_dead.CreateInstance();
                voice_deadInst.Volume = VolumeSFX;
                get_item = ATexture.get_item;
                get_itemInst = get_item.CreateInstance();
                get_itemInst.Volume = VolumeSFX;
                mouse_enter = ATexture.mouse_enter;
                mouse_enterInst = mouse_enter.CreateInstance();
                mouse_enterInst.Volume = 1F;
                VolumeSFX = 0.3F;


                cursor = new Cursor(ATexture.cursor8x8, _game);
                background = new Sprite(ATexture.BG_Main_Menu, 0, 0);
                backgroundPause = new Sprite(ATexture.BG_Pause, 0, 0);
                backgroundGO = new Sprite(ATexture.BG_GO, 0, 0);

               
            }

             state = 7;
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
          /*  if (keyState.IsKeyDown(Keys.Escape) && keyOState.IsKeyUp(Keys.Escape))
            {
                if (state == 0)
                {
                    state = 1;
                    HUD.showhud = false;
                    stage1.End();
                    stage2.End();
                }
                else
                {
                    state = 0;
                    HUD.showhud = true;
                    button1.HandleInput(keyState, mouseState, cursor);
                    button2.HandleInput(keyState, mouseState, cursor);
                    button3.HandleInput(keyState, mouseState, cursor);
                    button4.HandleInput(keyState, mouseState, cursor);
                    button5.HandleInput(keyState, mouseState, cursor);
                    button6.HandleInput(keyState, mouseState, cursor);
                    stage1.End();
                    stage2.End();
                }

            }*/
            if (HUD.HP == 0) // PERSO MORT GAME OVER
            {
                State = 4;
            }

            if (keyState.IsKeyDown(Keys.Escape) && keyOState.IsKeyUp(Keys.Escape))
            {
                if (state == 0)
                {
                    state = 3;
                    HUD.showhud = false;
                    Freezed = true;
                }
                else
                {
                    state = 0;
                    HUD.showhud = true;
                    Freezed = false;
                }

            }


            if (state != 0 )
            {
                button1.HandleInput(keyState, mouseState, cursor);
                button2.HandleInput(keyState, mouseState, cursor);
                button3.HandleInput(keyState, mouseState, cursor);
                button4.HandleInput(keyState, mouseState, cursor);
                button5.HandleInput(keyState, mouseState, cursor);
                button6.HandleInput(keyState, mouseState, cursor);
                button7.HandleInput(keyState, mouseState, cursor);
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
            if (button1.Status == true || button2.Status == true || button3.Status == true || button4.Status == true || button5.Status == true || button6.Status == true || button7.Status == true || buttonVolume1.Status == true || buttonVolume2.Status == true || buttonVolume3.Status == true || buttonVolume4.Status == true)
            {
                mouse_enterInst.Play();

            }

            this.HandleInput(keyState, mouseState, game);
            if (state == 1) // Main Menu
            {
                button1.Text = "Play";
                button1.IsVisible = true;
                button2.Text = "Multiplayer";
                button2.IsVisible = true;
                button3.Text = "Option";
                button3.IsVisible = true;
                button4.Text = "Quit";
                button4.IsVisible = true;
                button5.IsVisible = false;
                button6.IsVisible = false;
                button7.IsVisible = false;
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
                //B4
                if (button4.IsHighLighted)
                    button4.Position = new Vector2(Game1.screenWidth - button1.Width + 15, (Game1.screenHeight / 2) + 3 * button1.Height + 15);
                else
                    button4.Position = new Vector2(Game1.screenWidth - button1.Width + 35, (Game1.screenHeight / 2) + 3 * button1.Height + 15);

                if (button1.Status == true)
                {
                    state = 6;

                    button1.Status = false;
                }
                if (button2.Status == true)
                {
                    Game1.Multi();
                }
                if (button3.Status == true)
                {
                    state = 2;
                    button3.Status = false;
                }
                if (button4.Status == true)
                {
                    game.Exit();
                    button4.Status = false;
                }
            }
            if (state == 2)  // Menu Options
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
                button7.IsVisible = false;
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
                        gameMusicInst.Stop();
                        music_projectInst.Stop();
                        attack1Inst.Stop();
                        jumpInst.Stop();
                        landingInst.Stop();
                        voice_deadInst.Stop();
                        get_itemInst.Stop();
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
                    gameMusicInst.Play();
                    music_projectInst.Play();
                    menuVolumeChangeBGM = 50;
                    VolumeBGM = 0.5f;
                    musicMenuInst.Volume = VolumeBGM;
                    menuVolumeChangeSFX = 50;
                    VolumeSFX = 0.5f;
                    jumpInst.Volume = VolumeSFX;
                    landingInst.Volume = VolumeSFX;
                    attack1Inst.Volume = VolumeSFX;
                    voice_deadInst.Volume = VolumeSFX;
                    get_itemInst.Volume = VolumeSFX;

                }

            }
            if (state == 3)  // Menu Pause
            {
                gameMusicInst.Pause();
                button1.Text = "Sound  :  " + menuSoundState;
                button1.IsVisible = true;
                button2.Text = "Display  :  " + menuDisplayState;
                button2.IsVisible = true;
                button3.Text = "Resume";
                button3.IsVisible = true;
                button4.Text = "BGM  Volume  :        " + menuVolumeChangeBGM;
                button4.IsVisible = true;
                button5.Text = "SFX  Volume  :        " + menuVolumeChangeSFX;
                button5.IsVisible = true;
                button6.Text = "Restore Defaults ";
                button6.IsVisible = true;
                button7.IsVisible = true;
                button7.Text = "Menu";
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
                    button3.Position = new Vector2(Game1.screenWidth - button1.Width - 5, (Game1.screenHeight / 2) - button1.Height - 5);
                else
                    button3.Position = new Vector2(Game1.screenWidth - button1.Width + 15, (Game1.screenHeight / 2) - button1.Height - 5);
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
                //B7
                if (button7.IsHighLighted)
                    button7.Position = new Vector2(Game1.screenWidth - button1.Width + 30, (Game1.screenHeight / 2) + 5 * button1.Height + 25);
                else
                    button7.Position = new Vector2(Game1.screenWidth - button1.Width + 50, (Game1.screenHeight / 2) + 5 * button1.Height + 25);





                if (button1.Status == true)
                {
                    button1.Status = false;
                    if (menuSoundState == "on")
                    {
                        menuSoundState = "off";
                        musicMenuInst.Stop();
                        gameMusicInst.Stop();
                        music_projectInst.Stop();
                        attack1Inst.Stop();
                        jumpInst.Stop();
                        landingInst.Stop();
                        voice_deadInst.Stop();
                        get_itemInst.Stop();
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
                    state = 0;

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
                    gameMusicInst.Play();
                    music_projectInst.Play();
                    menuVolumeChangeBGM = 50;
                    VolumeBGM = 0.5f;
                    musicMenuInst.Volume = VolumeBGM;
                    menuVolumeChangeSFX = 50;
                    VolumeSFX = 0.5f;
                    get_itemInst.Volume = VolumeSFX; ;
                    jumpInst.Volume = VolumeSFX;
                    landingInst.Volume = VolumeSFX;
                    attack1Inst.Volume = VolumeSFX;
                    voice_deadInst.Volume = VolumeSFX;

                }

                if (button7.Status == true)
                {
                    state = 1;
                    stage1.End();
                    stage2.End();

                    button7.Status = false;
                }

            }

            if (state == 4)  // MENU GAME OVER 
            {
                HUD.showhud = false;
                Freezed = true;
                button1.Text = "Restart";
                button1.IsVisible = true;
                button2.Text = "Quit";
                button2.IsVisible = true;
                button3.IsVisible = false;
                button4.IsVisible = false;
                button5.IsVisible = false;
                button6.IsVisible = false;
                button7.IsVisible = false;
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


                if (button1.Status == true)
                {
                    Freezed = false;
                    Enemies.Boss.lockCamera = false;
                    state = 0;
                    HUD.showhud = true;
                    HUD.HP = 4;
                    HUD.Mana = 3;
                    button1.Status = false;
                    //Player.staticHitbox = new Rectangle(200, 0, 87, 170);
                    //Player.staticSpritebox = new Rectangle(200, 0, 175, 175);
                    HUD.playerscore = 0;

                    if (Menu.lvl_selected == 1)
                    {
                        stage1.Restart();
                    }
                    if (Menu.lvl_selected == 2)
                    {
                        stage2.Restart();
                    }

                }

                if (button2.Status == true)
                {
                    game.Exit();
                    button3.Status = false;
                }
            }
            if (state == 5)
            {
                button1.Text = "Stage 1";
                button1.IsVisible = true;
                button2.Text = "Stage 2";
                button2.IsVisible = true;
                button3.IsVisible = false;
                button4.IsVisible = false;
                button5.IsVisible = false;
                button6.IsVisible = false;
                button7.IsVisible = false;
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
                    if (Stages.Stage1.lvl_completed == true)
                    {
                        button2.Position = new Vector2(Game1.screenWidth - button1.Width + 5, (Game1.screenHeight / 2) + button1.Height + 5);
                    }
                    else
                        button2.Position = new Vector2(Game1.screenWidth - button1.Width + 25, (Game1.screenHeight / 2) + button1.Height + 5);


                if (button1.Status == true)
                {
                    Enemies.Boss.lockCamera = false;
                    if (lvl_selected == 2)
                    {
                        stage2.End();
                    }
                    lvl_selected = 1;
                    stage1.Init();

                    state = 0;

                    Drawmessage = false;
                    Freezed = false;
                    HUD.showhud = true;
                    HUD.HP = 4;
                    HUD.Mana = 3;
                    button1.Status = false;
                    //Player.Hitbox = new Rectangle(200, 0, 87, 170);
                    //Player.Spritebox = new Rectangle(200, 0, 175, 175);
                    //Player2.Hitbox = new Rectangle(0, 0, 87, 170);
                    //Player2.Spritebox = new Rectangle(0, 0, 175, 175);
                    HUD.playerscore = 0;


                }

                if (button2.Status == true)
                {
                    if (Stages.Stage1.lvl_completed == true)
                    {
                        Enemies.Boss.lockCamera = false;
                        if (lvl_selected == 1)
                        {
                            
                            stage1.End();
                        }
                        lvl_selected = 2;
                        stage2.Init();
                   
                        state = 0;

                        Freezed = false;
                        HUD.showhud = true;
                        HUD.HP = 4;
                        HUD.Mana = 3;
                        button2.Status = false;
                        //Player.Hitbox = new Rectangle(200, 0, 87, 170);
                        //Player.Spritebox = new Rectangle(200, 0, 175, 175);
                        //Player2.Hitbox = new Rectangle(0, 0, 87, 170);
                        //Player2.Spritebox = new Rectangle(0, 0, 175, 175);
                        HUD.playerscore = 0;
                    }
                    else
                    {
                        Drawmessage = true;
                    }
                }
            }
            if (state == 6)
            {
                button1.Text = "Easy";
                button1.IsVisible = true;
                button2.Text = "Medium";
                button2.IsVisible = true;
                button3.Text = "Hard";
                button3.IsVisible = true;
                button4.IsVisible = false;
                button5.IsVisible = false;
                button6.IsVisible = false;
                button7.IsVisible = false;
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
                    Enemies.Boss.HpBoss = 14;
                    Enemies.Roller.HpDifficult = 2;
                    state = 5;
                    button1.Status = false;
                }

                if (button2.Status == true)
                {
                    Enemies.Boss.HpBoss = 20;
                    Enemies.Roller.HpDifficult = 4;
                    state = 5;
                    button2.Status = false;

                }
                if (button3.Status == true)
                {
                    Enemies.Boss.HpBoss = 30;
                    Enemies.Roller.HpDifficult = 6;
                    state = 5;
                    button3.Status = false;

                }
            }

            if (state == 7 && playIntro == true)
            {
                videoPlayer.Play(Intro);
                playIntro = false;
                

                //videoPlayer.Stop();

            }
            if (state == 7 && playIntro == false)
            {
                Timer = Timer + 1;
                if (Timer == 796 || (keyState.IsKeyDown(Keys.Space)))
                {
                    state = 1;
                }

                  
            }
            
               
            
            // ######################
            if (state != 0 && state != 7)
            {

                lastState = state;
                if (menuSoundState == "on")
                    musicMenuInst.Play();
                gameMusicInst.Stop();
                music_projectInst.Stop();
                attack1Inst.Stop();
                jumpInst.Stop();
                landingInst.Stop();
                voice_deadInst.Stop();
                get_itemInst.Stop();

                musicMenuInst.Volume = VolumeBGM;
            }
            else
            {
                musicMenuInst.Stop();
            }

            if (state == 0 && menuSoundState == "on")
            {
                if (lvl_selected == 1)
                {
                    music_projectInst.Play();
                    music_projectInst.Volume = VolumeBGM;
                }
                if (lvl_selected == 2)
                {
                    gameMusicInst.Play();
                    gameMusicInst.Volume = VolumeBGM;
                }
                
                jumpInst.Volume = VolumeSFX;
                landingInst.Volume = VolumeSFX;
                attack1Inst.Volume = VolumeSFX;
                run_groundInst.Volume = VolumeSFX;
                voice_deadInst.Volume = VolumeSFX;
                get_itemInst.Volume = VolumeSFX;
            }
            
        }


        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime, Rectangle screenRectangle)
        {
            if (state == 7)
            {
                if (videoPlayer.State != MediaState.Stopped)
                {
                    Texture2D texture = videoPlayer.GetTexture();
                    if (texture != null)
                    {
                        spriteBatch.Draw(texture, new Rectangle(0, 0, Game1.screenWidth, Game1.screenHeight),
                            Color.White);
                    }
                }
            
                   
                
            }
            if (state == 6)
            {
                spriteBatch.Draw(background.Texture, screenRectangle, Color.White);
                button1.Draw(spriteBatch, gameTime);
                button2.Draw(spriteBatch, gameTime);
                button3.Draw(spriteBatch, gameTime);
                button4.Draw(spriteBatch, gameTime);
                button5.Draw(spriteBatch, gameTime);
                button6.Draw(spriteBatch, gameTime);
                button7.Draw(spriteBatch, gameTime);
                buttonVolume1.Draw(spriteBatch, gameTime);
                buttonVolume2.Draw(spriteBatch, gameTime);
                buttonVolume3.Draw(spriteBatch, gameTime);
                buttonVolume4.Draw(spriteBatch, gameTime);
                cursor.Draw(spriteBatch, gameTime);
            }
            if (state == 5)
            {
                spriteBatch.Draw(background.Texture, screenRectangle, Color.White);
                button1.Draw(spriteBatch, gameTime);
                button2.Draw(spriteBatch, gameTime);
                button3.Draw(spriteBatch, gameTime);
                button4.Draw(spriteBatch, gameTime);
                button5.Draw(spriteBatch, gameTime);
                button6.Draw(spriteBatch, gameTime);
                button7.Draw(spriteBatch, gameTime);
                buttonVolume1.Draw(spriteBatch, gameTime);
                buttonVolume2.Draw(spriteBatch, gameTime);
                buttonVolume3.Draw(spriteBatch, gameTime);
                buttonVolume4.Draw(spriteBatch, gameTime);
                cursor.Draw(spriteBatch, gameTime);
                if (Drawmessage == true)
                {
                    spriteBatch.DrawString(Fonts.Font1, "You must clear the stage 1 !", new Vector2(Game1.screenWidth / 2, Game1.screenHeight / 2), Color.Red);
                }
            }
            if (state == 4)
            {
                spriteBatch.Draw(backgroundGO.Texture, screenRectangle, Color.White);
                button1.Draw(spriteBatch, gameTime);
                button2.Draw(spriteBatch, gameTime);
                button3.Draw(spriteBatch, gameTime);
                button4.Draw(spriteBatch, gameTime);
                button5.Draw(spriteBatch, gameTime);
                button6.Draw(spriteBatch, gameTime);
                button7.Draw(spriteBatch, gameTime);
                buttonVolume1.Draw(spriteBatch, gameTime);
                buttonVolume2.Draw(spriteBatch, gameTime);
                buttonVolume3.Draw(spriteBatch, gameTime);
                buttonVolume4.Draw(spriteBatch, gameTime);
                spriteBatch.DrawString(Fonts.Font1, "Score : " + HUD.playerscore, new Vector2(Game1.screenWidth / 2, Game1.screenHeight / 2), Color.White);
                cursor.Draw(spriteBatch, gameTime);
            }


            if (state == 3)
            {
                spriteBatch.Draw(backgroundPause.Texture, screenRectangle, Color.White);
                button1.Draw(spriteBatch, gameTime);
                button2.Draw(spriteBatch, gameTime);
                button3.Draw(spriteBatch, gameTime);
                button4.Draw(spriteBatch, gameTime);
                button5.Draw(spriteBatch, gameTime);
                button6.Draw(spriteBatch, gameTime);
                button7.Draw(spriteBatch, gameTime);
                buttonVolume1.Draw(spriteBatch, gameTime);
                buttonVolume2.Draw(spriteBatch, gameTime);
                buttonVolume3.Draw(spriteBatch, gameTime);
                buttonVolume4.Draw(spriteBatch, gameTime);
                cursor.Draw(spriteBatch, gameTime);
            }
            if (state == 1 || state == 2)
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

