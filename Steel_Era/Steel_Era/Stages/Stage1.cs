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

namespace Steel_Era.Stages
{
    class Stage1 : Stage
    {
        public Stage1()
        {
            SpawnItems();
        }


        Item hp1, hp2;
        Item mana1, mana2, mana3, mana4;
        Item pts1, pts2, pts3, pts4, pts5;

        void SpawnItems()
        {
            hp1 = new Item(ATexture.HPB, 420, 130, 1);
            hp2 = new Item(ATexture.HPB, 3300, 160, 1);
            mana1 = new Item(ATexture.ManaB, 900, 500, 1);
            mana2 = new Item(ATexture.ManaB, 2500, 500, 1);
            mana3 = new Item(ATexture.ManaB, 4400, 610, 1);
            mana4 = new Item(ATexture.ManaB, 5100, 180, 1);
            pts1 = new Item(ATexture.Pts, 4770, 180, 500);
            pts2 = new Item(ATexture.Pts, 4500, 400, 500);
            pts3 = new Item(ATexture.Pts, 4000, 610, 500);
            pts4 = new Item(ATexture.Pts, 1900, 600, 500);
            pts5 = new Item(ATexture.Pts, 1900, 180, 500);
            lists.ListItem.Add(hp1);
            lists.ListItem.Add(hp2);
            lists.ListItem.Add(mana1);
            lists.ListItem.Add(mana2);
            lists.ListItem.Add(mana3);
            lists.ListItem.Add(mana4);
            lists.ListItem.Add(pts1);
            lists.ListItem.Add(pts2);
            lists.ListItem.Add(pts3);
            lists.ListItem.Add(pts4);
            lists.ListItem.Add(pts5);
            
        }

        public override void Update()
        {
            UpdateItems();
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            DrawItems(spriteBatch, gameTime);
        }


        void UpdateItems()
        {
            for (int i = 0; i < lists.ListItem.Count; i++)
            {
                if (lists.ListItem.ElementAt(i).Used())
                {
                    lists.ListItem.Remove(lists.ListItem.ElementAt(i));
                }
            }
        }

        void DrawItems(SpriteBatch spriteBatch, GameTime gameTime)
        {
            for (int i = 0; i < lists.ListItem.Count; i++)
            {
                lists.ListItem.ElementAt(i).Draw(spriteBatch, gameTime);
            }
        }

        
    }
}
