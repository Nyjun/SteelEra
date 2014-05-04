using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Steel_Era
{
    class HUD
    {

        //FIELDS 
        public int playerscore, HP, Mana;
        private Vector2 position;
        private SpriteFont spriteFont;
        // private SpriteBatch spriteBatch;       
        // private GraphicsDevice graphicsDevice;        
        // private String textLabel;

        public Rectangle Hslot1, Hslot2, Hslot3, Hslot4, Mslot1, Mslot2, Mslot3, Pslot, Nslot;

        public static bool showhud;
        //private bool enabled;

        //CONSTRUCTORS

        public HUD()
        {
            HP = 4;
            Mana = 3;
            Nslot = new Rectangle(110, 0, 260, 60);
            Hslot1 = new Rectangle(113, 5, 61, 29);
            Hslot2 = new Rectangle(177, 5, 61, 29);
            Hslot3 = new Rectangle(241, 5, 61, 29);
            Hslot4 = new Rectangle(305, 5, 61, 29);

            Mslot1 = new Rectangle(113, 37, 70, 17);
            Mslot2 = new Rectangle(186, 37, 70, 17);
            Mslot3 = new Rectangle(259, 37, 70, 17);
            Pslot = new Rectangle(0, 0, 110, 130);
            spriteFont = Fonts.Font1;
            playerscore = 0;
            showhud = false;
            //enabled = false;
            position = new Vector2(600, 30);
        }
        //this.textLabel = textLabel.ToUpper();

        public void LoadContent(ContentManager Content)
        {
            spriteFont = Content.Load<SpriteFont>("Menu/Fonts/SpriteFont1");
        }

        /*public void Update(GameTime gameTime)
        {

        }*/

        public void Draw(SpriteBatch spriteBatch)
        {
            if (showhud)
            {
                spriteBatch.Draw(ATexture.Portrait, Pslot, Color.White);
                spriteBatch.Draw(ATexture.Nav, Nslot, Color.White);

                if (HP >= 1)
                {
                    spriteBatch.Draw(ATexture.Hp1, Hslot1, Color.White);
                }
                if (HP >= 2)
                {
                    spriteBatch.Draw(ATexture.Hp2, Hslot2, Color.White);
                }
                if (HP >= 3)
                {
                    spriteBatch.Draw(ATexture.Hp3, Hslot3, Color.White);
                }
                if (HP >= 4)
                {
                    spriteBatch.Draw(ATexture.Hp4, Hslot4, Color.White);
                }

                if (Mana >= 3)
                {
                    spriteBatch.Draw(ATexture.Mana1, Mslot1, Color.White);
                }
                if (Mana >= 3)
                {
                    spriteBatch.Draw(ATexture.Mana2, Mslot2, Color.White);
                }
                if (Mana >= 1)
                {
                    spriteBatch.Draw(ATexture.Mana3, Mslot3, Color.White);
                }
                spriteBatch.DrawString(spriteFont, "Score:" + playerscore, position, Color.Black);
            }
        }
    }


}