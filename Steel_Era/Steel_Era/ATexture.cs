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
    static class ATexture
    {
        public static Texture2D buttonOff;
        public static Texture2D buttonOn;
        public static Texture2D covert;
        public static Texture2D cursor8x8;
        public static Texture2D forestTemple;
        public static Texture2D ground;
        public static Texture2D Crow;
        public static Texture2D Solbas;
        public static Texture2D Solhaut;
        public static Texture2D BG_Main_Menu;
        public static Texture2D BG_Mont;
        public static Texture2D BG_Ciel;
        public static Texture2D PlateFormebas;
        public static Texture2D PlateFormeMid;
        public static Texture2D PlateFormehaut;

        public static SoundEffect musicMenu;



        public static void Load(ContentManager cm)
        {
            buttonOff = cm.Load<Texture2D>("Button_test_1_off");
            buttonOn = cm.Load<Texture2D>("Button_test_1_on");
            covert = cm.Load<Texture2D>("Covert");
            cursor8x8 = cm.Load<Texture2D>("curseur_8x8");
            forestTemple = cm.Load<Texture2D>("forest_temple");
            ground = cm.Load<Texture2D>("sol_test");
            Crow = cm.Load<Texture2D>("Animation");
            BG_Ciel = cm.Load<Texture2D>("Ciel");
            Solbas = cm.Load<Texture2D>("Solbas");
            Solhaut = cm.Load<Texture2D>("Solhaut");
            BG_Main_Menu = cm.Load<Texture2D>("BG_Main_Menu");
            BG_Mont = cm.Load<Texture2D>("Mont");

            PlateFormebas = cm.Load<Texture2D>("PlateFormebas");
            PlateFormehaut = cm.Load<Texture2D>("PlateFormehaut");
            PlateFormeMid = cm.Load<Texture2D>("PlateFormeMid");

            musicMenu = cm.Load<SoundEffect>("KodoDrum1");
        }

        /*public virtual void Initialize(GraphicsDevice gDevice)
        {
            buttonOff = new Texture2D(gDevice, (int)width, (int)height);
            buttonOn = new Texture2D(gDevice, (int)width, (int)height);
            covert = new Texture2D(gDevice, (int)width, (int)height);
            cursor8x8 = new Texture2D(gDevice, (int)width, (int)height);
            forestTemple = new Texture2D(gDevice, (int)width, (int)height);
        }*/
        //
    }//
}
