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
        Sprite Solhaut;
        Sprite BG_Ciel;
        Sprite BG_Mont;
        Sprite PlateFormebas;
        Sprite PlateFormeMid;
        Sprite PlateFormehaut;
        Sprite test;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            graphics.IsFullScreen = false;
            
            //graphics.PreferredBackBufferHeight = 700;
            //graphics.PreferredBackBufferWidth = 900;
            //Changes the settings that you just applied
            //graphics.ApplyChanges();
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

            // TODO: use this.Content to load your game content here
            ATexture.Load(Content);
            Fonts.Font1 = Content.Load<SpriteFont>("Menu/Fonts/SpriteFont1");//
            menu = new Menu();
            menu.Initialize(this);


            screenWidth = Window.ClientBounds.Width;
            screenHeight = Window.ClientBounds.Height;
            screenRectangle = new Rectangle(0, 0, screenWidth, screenHeight);

            BG_Ciel = new Sprite(ATexture.BG_Ciel, 0, screenHeight - 800);
            BG_Ciel.Initialize();
            Solbas = new Sprite(ATexture.Solbas, 0, screenHeight - 60);
            Solbas.Initialize();
            Solhaut = new Sprite(ATexture.Solhaut, 0, screenHeight - 97);
            Solhaut.Initialize();
            BG_Mont = new Sprite(ATexture.BG_Mont, 0, screenHeight - 500);
            BG_Mont.Initialize();
            PlateFormebas = new Sprite(ATexture.PlateFormebas, 800, screenHeight - 180);
            PlateFormebas.Initialize();
            PlateFormeMid = new Sprite(ATexture.PlateFormeMid, 810, screenHeight - 377);
            PlateFormeMid.Initialize();
            PlateFormehaut = new Sprite(ATexture.PlateFormehaut, 800, screenHeight - 400);
            PlateFormehaut.Initialize();

            test = new Sprite(ATexture.ground, 300, 180);
            test.Initialize();

            //Sol = new Sprite(ATexture.Sol, false, 0, 

            Physics.ListObstacle.Add(PlateFormehaut);
            Physics.ListObstacle.Add(PlateFormebas);
            Physics.ListObstacle.Add(Solbas);
            Physics.ListObstacle.Add(test);


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


            keyOState = keyState;
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
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            BG_Ciel.Draw(spriteBatch, gameTime);
            BG_Mont.Draw(spriteBatch, gameTime);
            PlateFormehaut.Draw(spriteBatch, gameTime);
            PlateFormeMid.Draw(spriteBatch, gameTime);
            Solhaut.Draw(spriteBatch, gameTime);
            PlateFormebas.Draw(spriteBatch, gameTime);
            Solbas.Draw(spriteBatch, gameTime);
            Main.Draw(spriteBatch);
            test.Draw(spriteBatch, gameTime);

            menu.Draw(spriteBatch, gameTime, screenRectangle);

            spriteBatch.End();
            base.Draw(gameTime);

        }

    }
}
