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
        public static Texture2D BoutonSound1;
        public static Texture2D BoutonSound2;
        public static Texture2D buttonOff;
        public static Texture2D buttonOn;
        public static Texture2D button2Off;
        public static Texture2D button2On;
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
        public static SoundEffect jump;
        public static SoundEffect landing;
        public static SoundEffect attack1;

        //HUD
        public static Texture2D Hp1, Hp2, Hp3, Hp4, Mana1, Mana2, Mana3, Portrait, Nav;


        public static void Load(ContentManager cm)
        {
            //Menu
            BoutonSound1 = cm.Load<Texture2D>("Menu/Buttons/BoutonSound1");
            BoutonSound2 = cm.Load<Texture2D>("Menu/Buttons/BoutonSound2");
            buttonOff = cm.Load<Texture2D>("Menu/Buttons/Button_test_1_off");
            button2Off = cm.Load<Texture2D>("Menu/Buttons/ButtonOff");
            buttonOn = cm.Load<Texture2D>("Menu/Buttons/Button_test_1_on");
            button2On = cm.Load<Texture2D>("Menu/Buttons/ButtonOn");
            BG_Main_Menu = cm.Load<Texture2D>("Menu/BG_Main_Menu");
            cursor8x8 = cm.Load<Texture2D>("Menu/curseur_8x8");
            forestTemple = cm.Load<Texture2D>("Menu/forest_temple");

            //Game
            Crow = cm.Load<Texture2D>("Game/Animations/Animation");

            BG_Mont = cm.Load<Texture2D>("Game/Background/Mont");
            BG_Ciel = cm.Load<Texture2D>("Game/Background/Ciel jour");
            ground = cm.Load<Texture2D>("Game/Elements/sol_test");
            Solbas = cm.Load<Texture2D>("Game/Elements/Solbas");
            Solhaut = cm.Load<Texture2D>("Game/Elements/Solhaut");
            PlateFormebas = cm.Load<Texture2D>("Game/Elements/PlateFormebas");
            PlateFormehaut = cm.Load<Texture2D>("Game/Elements/PlateFormehaut");
            PlateFormeMid = cm.Load<Texture2D>("Game/Elements/PlateFormeMid");

            //HUD

            Nav = cm.Load<Texture2D>("Game/HUD/Nav");
            Hp1 = cm.Load<Texture2D>("Game/HUD/HP");
            Hp2 = cm.Load<Texture2D>("Game/HUD/HP");
            Hp3 = cm.Load<Texture2D>("Game/HUD/HP");
            Hp4 = cm.Load<Texture2D>("Game/HUD/HP");

            Mana1 = cm.Load<Texture2D>("Game/HUD/MANA");
            Mana2 = cm.Load<Texture2D>("Game/HUD/MANA");
            Mana3 = cm.Load<Texture2D>("Game/HUD/MANA");
            Portrait = cm.Load<Texture2D>("Game/HUD/Portrait");

            //Divers
            covert = cm.Load<Texture2D>("Covert");
            //Musique
            musicMenu = cm.Load<SoundEffect>("Menu/Music/KodoDrum1");
            jump = cm.Load<SoundEffect>("Menu/Music/jump_up");
            landing = cm.Load<SoundEffect>("Menu/Music/land_ground");
            attack1 = cm.Load<SoundEffect>("Menu/Music/voice_girl_attack_4");
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
