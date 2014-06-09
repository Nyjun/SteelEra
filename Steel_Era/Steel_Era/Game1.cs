using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Steel_Era
{


    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {

        static Stages.Stage1 stage1;
        static Stages.Stage2 stage2;

        Enemies.Roller roller;
        Enemies.Roller roller1;
        Enemies.Roller roller2;

        public GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState keyState;
        KeyboardState keyOState;
        public MouseState mouseState;
        GameMain Main;

        public static int screenWidth;
        public static int screenHeight;

        private Rectangle screenRectangle;
        private Menu menu;


        Sprite Solbas;       
        Sprite PlateFormebas;
        Sprite PlateFormehaut;
        Sprite Plat, HolePlat, HolePlat2, DoublePlat, DoublePlat2, DoublePlat3, Solbas2, Solbas3, Plat2, Plat3, Plat4;


        //Vector2 BG_Mont_Pos;
        //Bonus bonus;
        Camera Camerascroll;
        HUD hud;



        // MUSIQUE + BRUITAGES Xact method
        /*public AudioEngine audioEngine;
        public WaveBank waveBank;
        public SoundBank soundBank;
        public Cue currentSong;

        // Music volume.
       // float musicVolume = 1.0f;*/


        /*SoundEffect jump;
        SoundEffectInstance jumpInst;
        SoundEffect landing;
        SoundEffectInstance landingInst;
        SoundEffect attack1;
        SoundEffectInstance attack1Inst;*/

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = false;
            //graphics.IsFullScreen = false;

            graphics.PreferredBackBufferHeight = 765;
            graphics.PreferredBackBufferWidth = 1366;
            //Changes the settings that you just applied
            graphics.ApplyChanges();

            

        }


        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {

            // TODO: Add your initialization logic here
            //// Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            

            // TODO: use this.Content to load your game content here
            ATexture.Load(Content);
            Fonts.Font1 = Content.Load<SpriteFont>("Menu/Fonts/SpriteFont1");//
            menu = new Menu();
            menu.Initialize(this);

            stage1 = new Stages.Stage1();
            stage2 = new Stages.Stage2();


            screenWidth = Window.ClientBounds.Width;
            screenHeight = Window.ClientBounds.Height;
            screenRectangle = new Rectangle(0, 0, screenWidth, screenHeight);

            //BG_Ciel = new Sprite(ATexture.BG_Ciel, 0, screenHeight - 800);
            Solbas = new Sprite(ATexture.Solbas, 0, screenHeight - 60);
            Solbas2 = new Sprite(ATexture.Solbas2, 4000, screenHeight - 60);
            Solbas3 = new Sprite(ATexture.Solbas3, 7000, screenHeight - 60);
            //Solhaut = new Sprite(ATexture.Solhaut, 0, screenHeight - 97);
            //BG_Mont = new Sprite(ATexture.BG_Mont, 0, screenHeight - 500);
            PlateFormebas = new Sprite(ATexture.PlateFormebas, 800, screenHeight - 180);
            //PlateFormeMid = new Sprite(ATexture.PlateFormeMid, 810, screenHeight - 377);
            PlateFormehaut = new Sprite(ATexture.PlateFormehaut, 800, screenHeight - 400);

            Plat = new Sprite(ATexture.Platform, 300, 180);
            Plat2 = new Sprite(ATexture.Plat2, 1300, screenHeight - 342);
            Plat3 = new Sprite(ATexture.Plat3, 1800, screenHeight - 342);
            Plat4 = new Sprite(ATexture.Plat4, 4700, screenHeight - 440);
            HolePlat = new Sprite(ATexture.HolePlat, 3100, screenHeight - 197);
            HolePlat2 = new Sprite(ATexture.HolePlat2, 3600, screenHeight - 297);
            DoublePlat = new Sprite(ATexture.DoublePlat, 4500, screenHeight - 215);
            DoublePlat2 = new Sprite(ATexture.DoublePlat2, 5199, screenHeight - 180);
            DoublePlat3 = new Sprite(ATexture.DoublePlat3, 2100, screenHeight - 180);

            roller = new Enemies.Roller(2200, 100, stage1);
            roller1 = new Enemies.Roller(1300, 100, stage1);
            roller2 = new Enemies.Roller(5000, 100, stage1);


            hud = new HUD();
            Camerascroll = new Camera(GraphicsDevice.Viewport);
            //bonus = new Bonus();


            Game1.stage1.lists.ListObstacle.Add(PlateFormehaut);
            Game1.stage1.lists.ListObstacle.Add(PlateFormebas);
            Game1.stage1.lists.ListObstacle.Add(Solbas);
            Game1.stage1.lists.ListObstacle.Add(Solbas2);
            Game1.stage1.lists.ListObstacle.Add(Solbas3);
            Game1.stage1.lists.ListObstacle.Add(Plat);
            Game1.stage1.lists.ListObstacle.Add(Plat2);
            Game1.stage1.lists.ListObstacle.Add(Plat3);
            Game1.stage1.lists.ListObstacle.Add(Plat4);
            Game1.stage1.lists.ListObstacle.Add(HolePlat);
            Game1.stage1.lists.ListObstacle.Add(HolePlat2);
            Game1.stage1.lists.ListObstacle.Add(DoublePlat);
            Game1.stage1.lists.ListObstacle.Add(DoublePlat2);
            Game1.stage1.lists.ListObstacle.Add(DoublePlat3);

            Game1.stage1.lists.ListEnemies.Add(roller);
            Game1.stage1.lists.ListEnemies.Add(roller1);
            Game1.stage1.lists.ListEnemies.Add(roller2);


            base.Initialize();


        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            ATexture.Load(Content);

            //Fonts.Font1 = Content.Load<SpriteFont>("Menu/Fonts/SpriteFont1");
            Main = new GameMain(stage1);

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            Content.Unload();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            Main.Update(Mouse.GetState(), Keyboard.GetState());
            // Allows the game to exit

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            stage1.Update();

            keyState = Keyboard.GetState();
            mouseState = Mouse.GetState();
            menu.Update(gameTime, this, keyState, mouseState);
            roller.Update(gameTime);
            roller1.Update(gameTime);
            roller2.Update(gameTime);

            keyOState = keyState;
            Camerascroll.Update(gameTime, Player.Hitbox);

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Gray);

            // TODO: Add your drawing code here
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.LinearWrap, null, null, null, Camerascroll.transform);
            spriteBatch.Draw(ATexture.BG_Ciel, new Vector2(0, screenHeight - 800), Color.White);
            spriteBatch.Draw(ATexture.Ciel2, new Vector2(2751, screenHeight - 800), Color.White);
            spriteBatch.Draw(ATexture.Ciel3, new Vector2(2751 * 2, screenHeight - 800), Color.White);
            spriteBatch.Draw(ATexture.BG_Mont, new Vector2(0, screenHeight - 500), Color.White);
            spriteBatch.Draw(ATexture.Mont2, new Vector2(3493, screenHeight - 500), Color.White);
            spriteBatch.Draw(ATexture.Mont3, new Vector2(3493 * 2, screenHeight - 500), Color.White);
            HolePlat.Draw(spriteBatch, gameTime);
            HolePlat2.Draw(spriteBatch, gameTime);
            PlateFormehaut.Draw(spriteBatch, gameTime);
            spriteBatch.Draw(ATexture.PlateFormeMid, new Vector2(810, screenHeight - 377), Color.White);
            spriteBatch.Draw(ATexture.Solhaut, new Vector2(0, screenHeight - 97), Color.White);
            spriteBatch.Draw(ATexture.Solhaut2, new Vector2(4000, screenHeight - 97), Color.White);
            spriteBatch.Draw(ATexture.Solhaut3, new Vector2(7000, screenHeight - 97), Color.White);
            spriteBatch.Draw(ATexture.Edge, new Vector2(3000, screenHeight - 97), Color.White);
            spriteBatch.Draw(ATexture.PlatMid, new Vector2(1300, screenHeight - 320), Color.White);
            spriteBatch.Draw(ATexture.PlatMid2, new Vector2(1800, screenHeight - 320), Color.White);
            PlateFormebas.Draw(spriteBatch, gameTime);
            DoublePlat.Draw(spriteBatch, gameTime);
            DoublePlat2.Draw(spriteBatch, gameTime);
            DoublePlat3.Draw(spriteBatch, gameTime);
            Solbas.Draw(spriteBatch, gameTime);
            Solbas2.Draw(spriteBatch, gameTime);
            Solbas3.Draw(spriteBatch, gameTime);


            roller.Draw(spriteBatch, gameTime);
            roller1.Draw(spriteBatch, gameTime);
            roller2.Draw(spriteBatch, gameTime);
            Main.Draw(spriteBatch);
            
            
            Plat.Draw(spriteBatch, gameTime);
            Plat2.Draw(spriteBatch, gameTime);
            Plat3.Draw(spriteBatch, gameTime);
            Plat4.Draw(spriteBatch, gameTime);
            spriteBatch.Draw(ATexture.End, new Vector2(6850, screenHeight - 150), Color.White);
            //bonus.Draw(spriteBatch);
            stage1.Draw(spriteBatch, gameTime);

            /*BG_Mont.Draw(spriteBatch, gameTime);
            PlateFormehaut.Draw(spriteBatch, gameTime);
            PlateFormeMid.Draw(spriteBatch, gameTime);
            Solhaut.Draw(spriteBatch, gameTime);
            PlateFormebas.Draw(spriteBatch, gameTime);
            Solbas.Draw(spriteBatch, gameTime);
            Main.Draw(spriteBatch);
            Plat.Draw(spriteBatch, gameTime);
            covert.Draw(spriteBatch, gameTime);*/
            base.Draw(gameTime);
            spriteBatch.End();

            spriteBatch.Begin();
            menu.Draw(spriteBatch, gameTime, screenRectangle);
            hud.Draw(spriteBatch);
            spriteBatch.End();

        }

    }
}
