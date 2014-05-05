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

        Enemies.Roller roller;

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

        Sprite covert;

        //Vector2 BG_Mont_Pos;
        Bonus bonus;
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

            Physics.ListObstacle = new List<Sprite>();
            Physics.ListSprite = new List<Sprite>();
            Physics.ListEnemies = new List<Enemy>();
            Physics.ListPlayers = new List<Player>();

            // TODO: use this.Content to load your game content here
            ATexture.Load(Content);
            Fonts.Font1 = Content.Load<SpriteFont>("Menu/Fonts/SpriteFont1");//
            menu = new Menu();
            menu.Initialize(this);


            screenWidth = Window.ClientBounds.Width;
            screenHeight = Window.ClientBounds.Height;
            screenRectangle = new Rectangle(0, 0, screenWidth, screenHeight);

            //BG_Ciel = new Sprite(ATexture.BG_Ciel, 0, screenHeight - 800);
            //BG_Ciel.Initialize();
            Solbas = new Sprite(ATexture.Solbas, 0, screenHeight - 60);
            Solbas.Initialize();
            Solbas2 = new Sprite(ATexture.Solbas2, 4000, screenHeight - 60);
            Solbas2.Initialize();
            Solbas3 = new Sprite(ATexture.Solbas3, 7000, screenHeight - 60);
            Solbas3.Initialize();
            //Solhaut = new Sprite(ATexture.Solhaut, 0, screenHeight - 97);
            //Solhaut.Initialize();
            //BG_Mont = new Sprite(ATexture.BG_Mont, 0, screenHeight - 500);
            //BG_Mont.Initialize();
            PlateFormebas = new Sprite(ATexture.PlateFormebas, 800, screenHeight - 180);
            PlateFormebas.Initialize();
            //PlateFormeMid = new Sprite(ATexture.PlateFormeMid, 810, screenHeight - 377);
            //PlateFormeMid.Initialize();
            PlateFormehaut = new Sprite(ATexture.PlateFormehaut, 800, screenHeight - 400);
            PlateFormehaut.Initialize();

            Plat = new Sprite(ATexture.Platform, 300, 180);
            Plat.Initialize();
            Plat2 = new Sprite(ATexture.Plat2, 1300, screenHeight - 342);
            Plat2.Initialize();
            Plat3 = new Sprite(ATexture.Plat3, 1800, screenHeight - 342);
            Plat3.Initialize();
            Plat4 = new Sprite(ATexture.Plat4, 4700, screenHeight - 440);
            Plat4.Initialize();
            HolePlat = new Sprite(ATexture.HolePlat, 3100, screenHeight - 197);
            HolePlat.Initialize();
            HolePlat2 = new Sprite(ATexture.HolePlat2, 3600, screenHeight - 297);
            HolePlat2.Initialize();
            DoublePlat = new Sprite(ATexture.DoublePlat, 4500, screenHeight - 215);
            DoublePlat.Initialize();
            DoublePlat2 = new Sprite(ATexture.DoublePlat2, 5199, screenHeight - 180);
            DoublePlat2.Initialize();
            DoublePlat3 = new Sprite(ATexture.DoublePlat3, 2100, screenHeight - 180);
            DoublePlat3.Initialize();

            roller = new Enemies.Roller(2200, 100);

            covert = new Sprite(ATexture.covert, 500, 575);
            covert.Initialize();

            hud = new HUD();
            Camerascroll = new Camera(GraphicsDevice.Viewport);
            bonus = new Bonus();
     

            Physics.ListObstacle.Add(PlateFormehaut);
            Physics.ListObstacle.Add(PlateFormebas);
            Physics.ListObstacle.Add(Solbas);
            Physics.ListObstacle.Add(Solbas2);
            Physics.ListObstacle.Add(Solbas3);
            Physics.ListObstacle.Add(Plat);
            Physics.ListObstacle.Add(Plat2);
            Physics.ListObstacle.Add(Plat3);
            Physics.ListObstacle.Add(Plat4);
            Physics.ListObstacle.Add(HolePlat);
            Physics.ListObstacle.Add(HolePlat2);
            Physics.ListObstacle.Add(DoublePlat);
            Physics.ListObstacle.Add(DoublePlat2);
            Physics.ListObstacle.Add(DoublePlat3);

            Physics.ListEnemies.Add(roller);

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
            Main = new GameMain();

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
            keyState = Keyboard.GetState();
            mouseState = Mouse.GetState();
            menu.Update(gameTime, this, keyState, mouseState);
            roller.Update(gameTime);

            keyOState = keyState;
            Camerascroll.Update(gameTime, Player.Hitbox);
            covert.Update(gameTime);

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
            Main.Draw(spriteBatch);
            
            
            Plat.Draw(spriteBatch, gameTime);
            Plat2.Draw(spriteBatch, gameTime);
            Plat3.Draw(spriteBatch, gameTime);
            Plat4.Draw(spriteBatch, gameTime);
            spriteBatch.Draw(ATexture.End, new Vector2(6850, screenHeight - 150), Color.White);
            bonus.Draw(spriteBatch);

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
