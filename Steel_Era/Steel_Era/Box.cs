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

namespace Steel_Era
{
    class Box
    {
        public Box(Vector2 position, float Hei, float Wid, float up, float down, float left, float right)
        {
            height = Hei;
            width = Wid;
            pos_box = new Vector2(position.X + (width / 2), position.Y + (height / 2));
            if (up == 0)
            {
                sideUp = pos_box.Y - (height / 2);
            }
            else
            {
                sideUp = pos_box.Y - up;
            }

            if (down == 0)
            {
                sideDown = pos_box.Y + (height / 2);
            }
            else
            {
                sideDown = pos_box.Y + down;
            }

            if (left == 0)
            {
                sideLeft = pos_box.X - (width / 2);
            }
            else
            {
                sideLeft = pos_box.X - left;
            }

            if (right == 0)
            {
                sideRight = pos_box.X + (width / 2);
            }
            else
            {
                sideRight = pos_box.X + right;
            }
        }


        public float Height { get; set; }
        private float height;

        public float Width { get; set; }
        private float width;

        public Vector2 Position
        {
            get { return pos_box; }
        }
        private Vector2 pos_box;

        public float SideUp
        {
            get { return sideUp; }
            set { sideUp = pos_box.Y - value; }
        }
        private float sideUp;

        public float SideRight
        {
            get { return sideRight; }
            set { sideRight = pos_box.X + value; }
        }
        private float sideRight;

        public float SideDown
        {
            get { return sideDown; }
            set { sideDown = pos_box.Y + value; }
        }
        private float sideDown;

        public float SideLeft
        {
            get { return sideLeft; }
            set { sideLeft = pos_box.X - value; }
        }
        private float sideLeft;
    }
}
