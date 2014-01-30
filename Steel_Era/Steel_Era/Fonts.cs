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
    class Fonts
    {
        static public SpriteFont Font
        {
            get { return font; }
            set { font = value; }
        }
        static private SpriteFont font;

        static public SpriteFont Font1
        {
            get { return font1; }
            set { font1 = value; }
        }
        static private SpriteFont font1;
    }
}
