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
    class Bonus
    {
        /*public Rectangle Bslot1, Bslot2, Bslot3, Bslot4, Bslot5, Bslot6, Bslot7, Bslot8, Bslot9, Bslot10, Bslot11;
        public static int Checkhp, Checkhp2, Checkmana, Checkmana2, Checkmana3, Checkmana4, Checkpts, Checkpts2, Checkpts3, Checkpts4, Checkpts5;

        public Bonus()
        {
            Bslot1 = new Rectangle(420, 130, 30, 30);
            Bslot2 = new Rectangle(3300, 160, 30, 30);
            Bslot3 = new Rectangle(900, 500, 30, 30);
            Bslot4 = new Rectangle(2500, 500, 30, 30);
            Bslot5 = new Rectangle(4400, 610, 30, 30);
            Bslot6 = new Rectangle(5100, 180, 30, 30);
            Bslot7 = new Rectangle(4770, 180, 30, 30);
            Bslot8 = new Rectangle(4500, 400, 30, 30);
            Bslot9 = new Rectangle(4000, 610, 30, 30);
            Bslot10 = new Rectangle(1900, 600, 30, 30);
            Bslot11 = new Rectangle(1900, 180, 30, 30);
            Checkhp = 0;
            Checkhp2 = 0;
            Checkmana = 0;
            Checkmana2 = 0;
            Checkmana3 = 0;
            Checkmana4 = 0;
            Checkpts = 0;
            Checkpts2 = 0;
            Checkpts3 = 0;
            Checkpts4 = 0;
            Checkpts5 = 0;
        }
        public void IsCatched1(Rectangle bonus)
        {
            if ((Player.Hitbox.X + 44 > bonus.X) && (Player.Hitbox.X + 44 < bonus.X + 30) && (Player.Hitbox.Y + 85 < bonus.Y) && (Player.Hitbox.Y + 85 > bonus.Y - 30))
            {
                Checkhp++;
                Menu.get_itemInst.Play();
                HUD.HP++;
            }
        }
        public void IsCatched2(Rectangle bonus)
        {
            if ((Player.Hitbox.X + 44 > bonus.X) && (Player.Hitbox.X + 44 < bonus.X + 30) && (Player.Hitbox.Y + 85 < bonus.Y) && (Player.Hitbox.Y + 85 > bonus.Y - 30))
            {
                Checkhp2++;
                Menu.get_itemInst.Play();
                HUD.HP++;
            }

        }
        public void IsCatched3(Rectangle bonus)
        {
            if ((Player.Hitbox.X + 44 > bonus.X) && (Player.Hitbox.X + 44 < bonus.X + 30) && (Player.Hitbox.Y + 85 < bonus.Y) && (Player.Hitbox.Y + 85 > bonus.Y - 30))
            {
                Checkmana++;
                Menu.get_itemInst.Play();
                HUD.Mana++;
            }

        }
        public void IsCatched4(Rectangle bonus)
        {
            if ((Player.Hitbox.X + 44 > bonus.X) && (Player.Hitbox.X + 44 < bonus.X + 30) && (Player.Hitbox.Y + 85 < bonus.Y) && (Player.Hitbox.Y + 85 > bonus.Y - 30))
            {
                Checkmana2++;
                Menu.get_itemInst.Play();
                HUD.Mana++;
            }

        }
        public void IsCatched5(Rectangle bonus)
        {
            if ((Player.Hitbox.X + 44 > bonus.X) && (Player.Hitbox.X + 44 < bonus.X + 30) && (Player.Hitbox.Y + 85 < bonus.Y) && (Player.Hitbox.Y + 85 > bonus.Y - 30))
            {
                Checkmana3++;
                Menu.get_itemInst.Play();
                HUD.Mana++;
            }

        }
        public void IsCatched6(Rectangle bonus)
        {
            if ((Player.Hitbox.X + 44 > bonus.X) && (Player.Hitbox.X + 44 < bonus.X + 30) && (Player.Hitbox.Y + 85 < bonus.Y) && (Player.Hitbox.Y + 85 > bonus.Y - 30))
            {
                Checkmana4++;
                Menu.get_itemInst.Play();
                HUD.Mana++;
            }

        }
        public void IsCatched7(Rectangle bonus)
        {
            if ((Player.Hitbox.X + 44 > bonus.X) && (Player.Hitbox.X + 44 < bonus.X + 30) && (Player.Hitbox.Y + 85 < bonus.Y) && (Player.Hitbox.Y + 85 > bonus.Y - 30))
            {
                Checkpts++;
                Menu.get_itemInst.Play();
                HUD.playerscore = HUD.playerscore + 500;
            }

        }
        public void IsCatched8(Rectangle bonus)
        {
            if ((Player.Hitbox.X + 44 > bonus.X) && (Player.Hitbox.X + 44 < bonus.X + 30) && (Player.Hitbox.Y + 85 < bonus.Y) && (Player.Hitbox.Y + 85 > bonus.Y - 30))
            {
                Checkpts2++;
                Menu.get_itemInst.Play();
                HUD.playerscore = HUD.playerscore + 500;
            }

        }
        public void IsCatched9(Rectangle bonus)
        {
            if ((Player.Hitbox.X + 44 > bonus.X) && (Player.Hitbox.X + 44 < bonus.X + 30) && (Player.Hitbox.Y + 85 < bonus.Y) && (Player.Hitbox.Y + 85 > bonus.Y - 30))
            {
                Checkpts3++;
                Menu.get_itemInst.Play();
                HUD.playerscore = HUD.playerscore + 500;
            }

        }
        public void IsCatched10(Rectangle bonus)
        {
            if ((Player.Hitbox.X + 44 > bonus.X) && (Player.Hitbox.X + 44 < bonus.X + 30) && (Player.Hitbox.Y + 85 < bonus.Y) && (Player.Hitbox.Y + 85 > bonus.Y - 30))
            {
                Checkpts4++;
                Menu.get_itemInst.Play();
                HUD.playerscore = HUD.playerscore + 500;
            }

        }
        public void IsCatched11(Rectangle bonus)
        {
            if ((Player.Hitbox.X + 44 > bonus.X) && (Player.Hitbox.X + 44 < bonus.X + 30) && (Player.Hitbox.Y + 85 < bonus.Y) && (Player.Hitbox.Y + 85 > bonus.Y - 30))
            {
                Checkpts5++;
                Menu.get_itemInst.Play();
                HUD.playerscore = HUD.playerscore + 500;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            IsCatched1(Bslot1);
            IsCatched2(Bslot2);
            IsCatched3(Bslot3);
            IsCatched4(Bslot4);
            IsCatched5(Bslot5);
            IsCatched6(Bslot6);
            IsCatched7(Bslot7);
            IsCatched8(Bslot8);
            IsCatched9(Bslot9);
            IsCatched10(Bslot10);
            IsCatched11(Bslot11);

            if (Checkhp == 0)
            {
                spriteBatch.Draw(ATexture.HPB, Bslot1, Color.White);
            }
            if (Checkhp2 == 0)
            {
                spriteBatch.Draw(ATexture.HPB, Bslot2, Color.White);
            }
            if (Checkmana == 0)
            {
                spriteBatch.Draw(ATexture.ManaB, Bslot3, Color.White);
            }
            if (Checkmana2 == 0)
            {
                spriteBatch.Draw(ATexture.ManaB, Bslot4, Color.White);
            }
            if (Checkmana3 == 0)
            {
                spriteBatch.Draw(ATexture.ManaB, Bslot5, Color.White);
            }
            if (Checkmana4 == 0)
            {
                spriteBatch.Draw(ATexture.ManaB, Bslot6, Color.White);
            }
            if (Checkpts == 0)
            {
                spriteBatch.Draw(ATexture.Pts, Bslot7, Color.White);
            }
            if (Checkpts2 == 0)
            {
                spriteBatch.Draw(ATexture.Pts, Bslot8, Color.White);
            }
            if (Checkpts3 == 0)
            {
                spriteBatch.Draw(ATexture.Pts, Bslot9, Color.White);
            }
            if (Checkpts4 == 0)
            {
                spriteBatch.Draw(ATexture.Pts, Bslot10, Color.White);
            }
            if (Checkpts5 == 0)
            {
                spriteBatch.Draw(ATexture.Pts, Bslot11, Color.White);
            }
        }*/
    }
}
