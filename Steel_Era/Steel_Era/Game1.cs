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
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;
using System.IO;

namespace Steel_Era
{


    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {

        public static TcpClient client;
        public static string IP = "127.0.0.1";
        public static int PORT = 1490;
        public static int BUFFER_SIZE = 2048;
        public static byte[] readBuffer;

        public static MemoryStream readStream, writeStream;

        public static BinaryReader reader;
        public static BinaryWriter writer;

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
        public static void Multi()
        {
            client = new TcpClient();
            client.NoDelay = true;
            client.Connect(IP, PORT);
            readBuffer = new byte[BUFFER_SIZE];

            client.GetStream().BeginRead(readBuffer, 0, BUFFER_SIZE, StreamReceived, null);

            readStream = new MemoryStream();
            writeStream = new MemoryStream();

            reader = new BinaryReader(readStream);
            writer = new BinaryWriter(writeStream);
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

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                this.Exit();

            // TODO: Add your update logic here
            stage1.Update(mouseState, keyState, gameTime);
            stage2.Update(mouseState, keyState, gameTime);

            keyState = Keyboard.GetState();
            mouseState = Mouse.GetState();
            menu.Update(gameTime, this, keyState, mouseState);

            keyOState = keyState;
            Camerascroll.Update(gameTime, Player.staticHitbox);

            base.Update(gameTime);
        }

        public static void StreamReceived(IAsyncResult ar)
        {
            int byteRead = 0;

            try
            {
                lock (client.GetStream())
                {
                    byteRead = client.GetStream().EndRead(ar);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            if (byteRead == 0)
            {
                client.Close();
                return;
            }

            byte[] data = new byte[byteRead];

            for (int i = 0; i < byteRead; i++)
            {
                data[i] = readBuffer[i];
            }

            ProcessData(data);

            client.GetStream().BeginRead(readBuffer, 0, BUFFER_SIZE, StreamReceived, null);

        }

        public static void ProcessData(byte[] data)
        {
            readStream.SetLength(0);
            readStream.Position = 0;

            readStream.Write(data, 0, data.Length);
            readStream.Position = 0;

            Protocol p;

            try
            {
                p = (Protocol)reader.ReadByte();

                if (p == Protocol.Connected)
                {
                    byte id = reader.ReadByte();
                    string ip = reader.ReadString();
                    Menu.MultiOn = true;
                    MessageBox.Show(String.Format("Player has connected: {0} The IP adress is :{1}", id, ip));

                    writeStream.Position = 0;
                    writer.Write("Hello World!");
                    SendData(GetDataFromMemoryStream(writeStream));
                }
                else if (p == Protocol.Disconnected)
                {
                    byte id = reader.ReadByte();
                    string ip = reader.ReadString();
                    Menu.MultiOn = false;
                    MessageBox.Show(String.Format("Player has disconnected: {0} The IP adress is :{1}", id, ip));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Converts a MemoryStream to a byte array
        /// </summary>
        /// <param name="ms">MemoryStream to convert</param>
        /// <returns>Byte array representation of the data</returns>
        public static byte[] GetDataFromMemoryStream(MemoryStream ms)
        {
            byte[] result;

            //Async method called this, so lets lock the object to make sure other threads/async calls need to wait to use it.
            lock (ms)
            {
                int bytesWritten = (int)ms.Position;
                result = new byte[bytesWritten];

                ms.Position = 0;
                ms.Read(result, 0, bytesWritten);
            }

            return result;
        }

        /// <summary>
        /// Code to actually send the data to the client
        /// </summary>
        /// <param name="b">Data to send</param>
        public static void SendData(byte[] b)
        {
            //Try to send the data.  If an exception is thrown, disconnect the client
            try
            {
                lock (client.GetStream())
                {
                    client.GetStream().BeginWrite(b, 0, b.Length, null, null);
                }
            }
            catch (Exception e)
            {

            }
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

            if (Menu.lvl_selected == 1)
            {
                spriteBatch.Draw(ATexture.BG_Ciel, /*new Vector2(0, screenHeight - 800)*/ new Rectangle((int)(Camera.centreX * 0.95) - 750, screenHeight - 800, ATexture.BG_Ciel.Width, ATexture.BG_Ciel.Height), Color.White);
                //spriteBatch.Draw(ATexture.Ciel2, new Vector2(-2751, screenHeight - 800), Color.White);
                //spriteBatch.Draw(ATexture.Ciel3, new Vector2(2751 * 2, screenHeight - 800), Color.White);
                spriteBatch.Draw(ATexture.BG_Mont, /*new Vector2(0, screenHeight - 500)*/new Rectangle((int)(Camera.centreX * 0.8) - 750, screenHeight - 500, ATexture.BG_Mont.Width, ATexture.BG_Mont.Height), Color.White);
                spriteBatch.Draw(ATexture.BG_Mont, new Rectangle((int)(Camera.centreX * 0.8) - 50, screenHeight - 500, ATexture.BG_Mont.Width, ATexture.BG_Mont.Height), Color.White);
                //spriteBatch.Draw(ATexture.Mont3, new Vector2(3493 * 2, screenHeight - 500), Color.White);
                spriteBatch.Draw(ATexture.PlateFormeMid, new Vector2(810, screenHeight - 377), Color.White);
                spriteBatch.Draw(ATexture.Solhaut, new Vector2(0, screenHeight - 97), Color.White);
                spriteBatch.Draw(ATexture.Solhaut, new Vector2(4000, screenHeight - 97), Color.White);
                spriteBatch.Draw(ATexture.Solhaut, new Vector2(7000, screenHeight - 97), Color.White);
                spriteBatch.Draw(ATexture.Edge, new Vector2(3000, screenHeight - 97), Color.White);
                spriteBatch.Draw(ATexture.PlatMid, new Vector2(1300, screenHeight - 320), Color.White);
                spriteBatch.Draw(ATexture.PlatMid, new Vector2(1800, screenHeight - 320), Color.White);

                spriteBatch.Draw(ATexture.End, new Vector2(6850, screenHeight - 150), Color.White);
            }
            if (Menu.lvl_selected == 2)
            {
                spriteBatch.Draw(ATexture.Rock, new Rectangle((int)(Camera.centreX * 0.7) - 750, screenHeight - 400, ATexture.Rock.Width, ATexture.Rock.Height), Color.White);


                spriteBatch.Draw(ATexture.Grasshaut, new Vector2(0, screenHeight - 97), Color.White);
                spriteBatch.Draw(ATexture.Grasshaut, new Vector2(4000, screenHeight - 97), Color.White);
                spriteBatch.Draw(ATexture.Grasshaut, new Vector2(7000, screenHeight - 97), Color.White);


            }
            stage1.Draw(spriteBatch, gameTime);
            stage2.Draw(spriteBatch, gameTime);

            base.Draw(gameTime);
            spriteBatch.End();

            spriteBatch.Begin();
            menu.Draw(spriteBatch, gameTime, screenRectangle);
            hud.Draw(spriteBatch);
            spriteBatch.End();

        }

    }
}
