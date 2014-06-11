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

        public GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState keyState;
        KeyboardState keyOState;
        public MouseState mouseState;

        public static int screenWidth;
        public static int screenHeight;

        private Rectangle screenRectangle;
        private Menu menu;


        //Vector2 BG_Mont_Pos;
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
            
            stage1 = new Stages.Stage1();
            stage2 = new Stages.Stage2();

            menu = new Menu(stage1, stage2);
            menu.Initialize(this);

            screenWidth = Window.ClientBounds.Width;
            screenHeight = Window.ClientBounds.Height;
            screenRectangle = new Rectangle(0, 0, screenWidth, screenHeight);

            hud = new HUD();
            Camerascroll = new Camera(GraphicsDevice.Viewport);

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
            // Allows the game to exit

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            stage1.Update(mouseState, keyState, gameTime);

            keyState = Keyboard.GetState();
            mouseState = Mouse.GetState();
            menu.Update(gameTime, this, keyState, mouseState);

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
            spriteBatch.Draw(ATexture.PlateFormeMid, new Vector2(810, screenHeight - 377), Color.White);
            spriteBatch.Draw(ATexture.Solhaut, new Vector2(0, screenHeight - 97), Color.White);
            spriteBatch.Draw(ATexture.Solhaut2, new Vector2(4000, screenHeight - 97), Color.White);
            spriteBatch.Draw(ATexture.Solhaut3, new Vector2(7000, screenHeight - 97), Color.White);
            spriteBatch.Draw(ATexture.Edge, new Vector2(3000, screenHeight - 97), Color.White);
            spriteBatch.Draw(ATexture.PlatMid, new Vector2(1300, screenHeight - 320), Color.White);
            spriteBatch.Draw(ATexture.PlatMid2, new Vector2(1800, screenHeight - 320), Color.White);

            spriteBatch.Draw(ATexture.End, new Vector2(6850, screenHeight - 150), Color.White);
            stage1.Draw(spriteBatch, gameTime);

            base.Draw(gameTime);
            spriteBatch.End();

            spriteBatch.Begin();
            menu.Draw(spriteBatch, gameTime, screenRectangle);
            hud.Draw(spriteBatch);
            spriteBatch.End();

        }

    }
}
