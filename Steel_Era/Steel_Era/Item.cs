using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.IO;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace Steel_Era
{
    class Item : Sprite
    {
        
        public Item(Texture2D tex, float _x, float _y, int _amount)
            : base(tex, _x, _y)
        {
            amount = _amount;
            exists = true;
        }

        int amount;
        bool exists;

        public void GetBonus()
        {
            if (HUD.HP != 4 && Texture == ATexture.HPB)
            {
                Menu.get_itemInst.Play();
                HUD.HP += amount;
                exists = false;
            }
            if (HUD.Mana != 3 && Texture == ATexture.ManaB)
            {
                Menu.get_itemInst.Play();
                HUD.Mana += amount;
                exists = false;
            }
            if (Texture == ATexture.Pts)
            {
                Menu.get_itemInst.Play();
                HUD.playerscore += amount;
                exists = false;
            }
        }

        public bool Used()
        {
            return !exists;
        }

        public void Delete()
        {
            exists = false;
        }

        
    }
}
