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
    class Lists
    {
        public Lists()
        {
            listObstacle = new List<Sprite>();
            listSprite = new List<Sprite>();
            listBackground = new List<Sprite>();
            listMiddleground = new List<Sprite>();
            listForeground = new List<Sprite>();
            listEnemies = new List<Enemy>();
            listPlayers = new List<Player>();
            listItem = new List<Item>();
        }

        public List<Sprite> ListSprite
        {
            get { return listSprite; }
            set { listSprite = value; }
        }
        private List<Sprite> listSprite;

        public List<Sprite> ListBackground
        {
            get { return listBackground; }
            set { listBackground = value; }
        }
        private List<Sprite> listBackground;

        public List<Sprite> ListMiddleground
        {
            get { return listMiddleground; }
            set { listMiddleground = value; }
        }
        private List<Sprite> listMiddleground;

        public List<Sprite> ListForeground
        {
            get { return listForeground; }
            set { listForeground = value; }
        }
        private List<Sprite> listForeground;

        public List<Sprite> ListObstacle
        {
            get { return listObstacle; }
            set { listObstacle = value; }
        }
        private List<Sprite> listObstacle;

        public List<Player> ListPlayers
        {
            get { return listPlayers; }
            set { listPlayers = value; }
        }
        private List<Player> listPlayers;

        public List<Enemy> ListEnemies
        {
            get { return listEnemies; }
            set { listEnemies = value; }
        }
        private List<Enemy> listEnemies;


        public List<Item> ListItem
        {
            get { return listItem; }
            set { listItem = value; }
        }
        private List<Item> listItem;


    }
}
