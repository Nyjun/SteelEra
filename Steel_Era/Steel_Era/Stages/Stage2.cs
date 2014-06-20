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
    class Stage2 : Stage
    {
        public Stage2()
        {
        }


        Player player;
        Enemies.Boss boss;
        Enemies.Roller roller, roller1, roller2;
        Enemies.Shooter shooter1, shooter2;
        Item hp1, hp2;
        Item mana1, mana2, mana3, mana4;
        Item pts1, pts2, pts3, pts4, pts5;
        Sprite Grass, Grass2, Grass3,PlateFormebas, PlateFormehaut, Plat, HolePlat, HolePlat2, HolePlat3, HolePlat4, HolePlat5,
            DoublePlat, DoublePlat2, DoublePlat3,DoublePlat1, Plat2, Plat3, Plat4;

        ///                           ///
        ///   FONCTIONS PRINCIPALES   ///
        ///                           ///
        public override void Init()
        {
            SpawnObstacles();
            SpawnItems();
            SpawnEnemies();
            player = new Player(this);
            lists.ListPlayers.Add(player);
        }
        public override void Update(MouseState ms, KeyboardState ks, GameTime gt)
        {
            UpdateEnemies(gt);
            UpdateItems();
            UpdatePlayers(ms, ks);
        }
        public void Draw(SpriteBatch sb, GameTime gt)
        {
            DrawItems(sb, gt);
            DrawEnemies(sb, gt);
            DrawPlayers(sb);
            DrawObstacles(sb, gt);
        }
        public override void End()
        {
            DeleteItems();
            DeleteEnemies();
            DeletePlayers();
            DeleteObstacle();
        }


        ///                   ///
        ///   ITEMS           ///
        ///                   ///
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
        void DeleteItems()
        {
            for (int i = 0; i < lists.ListItem.Count; i++)
            {
                lists.ListItem.ElementAt(i).Delete();
            }
        }


        ///                   ///
        ///   ENEMIES         ///
        ///                   ///
        void SpawnEnemies()
        {
            roller = new Enemies.Roller(5500, 100, this);
            roller1 = new Enemies.Roller(800, 100, this);
            roller2 = new Enemies.Roller(5000, 100, this);
            shooter1 = new Enemies.Shooter(6750, 100, this);
            shooter2 = new Enemies.Shooter(6600, 100, this);

            boss = new Enemies.Boss(10450, 100, this);

            lists.ListEnemies.Add(roller);
            lists.ListEnemies.Add(roller1);
            lists.ListEnemies.Add(roller2);
            lists.ListEnemies.Add(shooter1);
            lists.ListEnemies.Add(shooter2);
            lists.ListEnemies.Add(boss);
        }
        void UpdateEnemies(GameTime gt)
        {
            for (int i = 0; i < lists.ListEnemies.Count; i++)
            {
                if (lists.ListEnemies.ElementAt(i).Killed())
                {
                    lists.ListEnemies.Remove(lists.ListEnemies.ElementAt(i));
                    HUD.playerscore += 1000;
                }
                else
                {
                    lists.ListEnemies.ElementAt(i).Update(gt);
                }
            }
        }
        void DrawEnemies(SpriteBatch spriteBatch, GameTime gameTime)
        {
            for (int i = 0; i < lists.ListEnemies.Count; i++)
            {
                lists.ListEnemies.ElementAt(i).Draw(spriteBatch, gameTime);
            }
        }
        void DeleteEnemies()
        {
            for (int i = 0; i < lists.ListEnemies.Count; i++)
            {
                lists.ListEnemies.ElementAt(i).Delete();
            }
        }


        ///                   ///
        ///   PLAYERS         ///
        ///                   ///
        void UpdatePlayers(MouseState ms, KeyboardState ks)
        {
            for (int i = 0; i < lists.ListPlayers.Count; i++)
            {
                if (lists.ListPlayers.ElementAt(i).Killed())
                {
                    lists.ListPlayers.Remove(lists.ListPlayers.ElementAt(i));
                }
                else
                {
                    lists.ListPlayers.ElementAt(i).Update(ms, ks);
                }
            }
        }
        void DrawPlayers(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < lists.ListPlayers.Count; i++)
            {
                lists.ListPlayers.ElementAt(i).Draw(spriteBatch);
            }
        }
        void DeletePlayers()
        {
            for (int i = 0; i < lists.ListPlayers.Count; i++)
            {
                lists.ListPlayers.ElementAt(i).Delete();
            }
        }

        ///                   ///
        ///   OBSTACLES       ///
        ///                   ///
        void SpawnObstacles()
        {
            Grass = new Sprite(ATexture.DemiGrass, 0, Game1.screenHeight - 60);
            Grass2 = new Sprite(ATexture.Grass, 5000, Game1.screenHeight - 60);
            Grass3 = new Sprite(ATexture.Grass, 8200, Game1.screenHeight - 60);
            PlateFormebas = new Sprite(ATexture.PlateFormebas, 5070, Game1.screenHeight - 180);
            PlateFormehaut = new Sprite(ATexture.PlateFormehaut, 5070, Game1.screenHeight - 396);
            Plat = new Sprite(ATexture.HolePlat, 9700, Game1.screenHeight - 297);
            Plat2 = new Sprite(ATexture.HolePlat, 10100, Game1.screenHeight - 297);
            //Plat3 = new Sprite(ATexture.Plat3, 1800, Game1.screenHeight - 342);
            //Plat4 = new Sprite(ATexture.Plat4, 4700, Game1.screenHeight - 440);
            HolePlat = new Sprite(ATexture.HolePlat, 1700, Game1.screenHeight - 297);
            HolePlat2 = new Sprite(ATexture.HolePlat, 2250, Game1.screenHeight - 397);
            HolePlat3 = new Sprite(ATexture.HolePlat, 2800, Game1.screenHeight - 200);
            HolePlat4 = new Sprite(ATexture.HolePlat, 4200, Game1.screenHeight - 297);
            HolePlat5 = new Sprite(ATexture.HolePlat, 4600, Game1.screenHeight - 397);
            DoublePlat = new Sprite(ATexture.DoublePlat, 750, Game1.screenHeight - 215);
            DoublePlat1 = new Sprite(ATexture.DoublePlat, 3350, Game1.screenHeight - 215);
            DoublePlat2 = new Sprite(ATexture.DoublePlat, 6300, Game1.screenHeight - 180);
            DoublePlat3 = new Sprite(ATexture.DoublePlat, 7000, Game1.screenHeight - 180);
            lists.ListObstacle.Add(PlateFormehaut);
            lists.ListObstacle.Add(PlateFormebas);
            lists.ListObstacle.Add(Grass);
            lists.ListObstacle.Add(Grass2);
            lists.ListObstacle.Add(Grass3);
            lists.ListObstacle.Add(Plat);
            lists.ListObstacle.Add(Plat2);
            //lists.ListObstacle.Add(Plat3);
            //lists.ListObstacle.Add(Plat4);
            lists.ListObstacle.Add(HolePlat);
            lists.ListObstacle.Add(HolePlat2);
            lists.ListObstacle.Add(HolePlat3);
            lists.ListObstacle.Add(HolePlat4);
            lists.ListObstacle.Add(HolePlat5);
            lists.ListObstacle.Add(DoublePlat);
            lists.ListObstacle.Add(DoublePlat1);
            lists.ListObstacle.Add(DoublePlat2);
            lists.ListObstacle.Add(DoublePlat3);
        }
        void UpdateObstacles()
        {
        }
        void DrawObstacles(SpriteBatch spriteBatch, GameTime gameTime)
        {
            for (int i = 0; i < lists.ListObstacle.Count; i++)
            {
                lists.ListObstacle.ElementAt(i).Draw(spriteBatch, gameTime);
            }
        }
        void DeleteObstacle()
        {
                lists.ListObstacle.RemoveRange(0, lists.ListObstacle.Count);
        }

        ///                   ///
        ///   SPRITES         ///
        ///                   ///
        void SpawnSprites()
        {

        }
        void UpdateSprites()
        {
        }
        void DrawSprites(SpriteBatch spriteBatch, GameTime gameTime)
        {
            for (int i = 0; i < lists.ListSprite.Count; i++)
            {
                lists.ListSprite.ElementAt(i).Draw(spriteBatch, gameTime);
            }
        }
        void DeleteSprites()
        {
            for (int i = 0; i < lists.ListSprite.Count; i++)
            {
                lists.ListSprite.ElementAt(i).Delete();
            }
        }
    }
}
