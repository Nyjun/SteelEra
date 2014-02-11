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
    class ATexture
    {
        public static Texture2D buttonOff;
        public static Texture2D buttonOn;
        public static Texture2D covert;
        public static Texture2D cursor8x8;
        public static Texture2D forestTemple;



        public static void Load(ContentManager cm)
        {
            buttonOff = cm.Load<Texture2D>("Button_test_1_off");
            buttonOn = cm.Load<Texture2D>("Button_test_1_on");
            covert = cm.Load<Texture2D>("Covert");
            cursor8x8 = cm.Load<Texture2D>("curseur_8x8");
            forestTemple = cm.Load<Texture2D>("forest_temple");
        }
    }
}
