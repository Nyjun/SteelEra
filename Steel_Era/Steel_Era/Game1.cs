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



        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        KeyboardState keyState;
        KeyboardState keyOState;
        MouseState mouseState;
        GameMain Main;

        public static int screenWidth;
        public static int screenHeight;

        private Cursor cursor;
        private Rectangle screenRectangle;
        private Menu menu;

        
        Sprite Solbas;
        Sprite Solhaut;
        Sprite test;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.IsMouseVisible = true;
            graphics.IsFullScreen = true;
            //ATexture.Load(Content);
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
            Fonts.Font1 = Content.Load<SpriteFont>("SpriteFont1");//
            cursor = new Cursor(ATexture.cursor8x8, false, 0, 0);
            menu = new Menu();
            menu.Initialize();

            screenWidth = Window.ClientBounds.Width;
            screenHeight = Window.ClientBounds.Height;
            screenRectangle = new Rectangle(0, 0, screenWidth, screenHeight);

            Solbas = new Sprite(ATexture.Solbas, false, 0, screenHeight-60);
            Solbas.Initialize();
            Solhaut = new Sprite(ATexture.Solhaut, false, 0, screenHeight-97);
            Solhaut.Initialize();

            test = new Sprite(ATexture.covert, false, 300, 100);
            test.Initialize();

            //Sol = new Sprite(ATexture.Sol, false, 0, 

            

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
            Fonts.Font1 = Content.Load<SpriteFont>("SpriteFont1");
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

            cursor.HandleInput(keyState, mouseState);
            menu.HandleInput(keyState, mouseState);
            menu.Update(gameTime);

            


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
            Solbas.Draw(spriteBatch, gameTime);
            Solhaut.Draw(spriteBatch, gameTime);
            Main.Draw(spriteBatch);
            test.Draw(spriteBatch, gameTime);
            
            menu.Draw(spriteBatch, gameTime, screenRectangle);
            cursor.Draw(spriteBatch, gameTime);
            
            spriteBatch.End();          
            base.Draw(gameTime);
            
        }
    }
}
