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
        public float Height { get; set; }
        private float height;

        public float Width { get; set; }
        private float width;

        public Vector2 Position
        {
            get { return pos_box; }
            set { pos_box = new Vector2(value.X + (width / 2), value.Y + (height / 2)); }
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
