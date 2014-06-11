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


        public static Texture2D RollerSprite;
        public static Texture2D BoutonSound1;
        public static Texture2D BoutonSound2;
        public static Texture2D buttonOff;
        public static Texture2D buttonOn;
        public static Texture2D button2Off;
        public static Texture2D button2On;
        public static Texture2D covert;
        public static Texture2D cursor8x8;
        public static Texture2D forestTemple;
        public static Texture2D Platform;
        public static Texture2D Crow;
        public static Texture2D Solbas;
        public static Texture2D Solhaut;
        public static Texture2D BG_Main_Menu;
        public static Texture2D BG_Mont;
        public static Texture2D BG_Ciel;
        public static Texture2D PlateFormebas;
        public static Texture2D PlateFormeMid;
        public static Texture2D PlateFormehaut;
        public static Texture2D BG_Pause;
        public static Texture2D BG_GO;
        public static Texture2D Boss;

        //Stage1
        public static Texture2D Solbas2, Solbas3, Solhaut2, Solhaut3, PlatMid, PlatMid2, Plat2, Ciel2, Ciel3, Mont2, Mont3, DoublePlat, DoublePlat2, DoublePlat3, Plat4,
            HolePlat, HolePlat2, Edge, Plat3, End, HPB, HPB2, ManaB, ManaB2, ManaB3, ManaB4, Pts, Pts2, Pts3, Pts4, Pts5;

        //Stage2
        public static Texture2D Grass, Grass2, Grass3, Grass4, Grass5, Grasshaut, Grasshaut2, Grasshaut3, Grasshaut4, Grasshaut5, BG, BG2, BG3, BG4, BG5, BG6, Forest, Forest2, Forest3, Forest4,
            Forest5, Forest6, Rock, Rock2;

        public static SoundEffect musicMenu;
        public static SoundEffect jump;
        public static SoundEffect landing;
        public static SoundEffect attack1;
        public static SoundEffect run_ground;
        public static SoundEffect gameMusic;
        public static SoundEffect mouse_enter;
        public static SoundEffect voice_dead;
        public static SoundEffect get_item;
        //HUD
        public static Texture2D Hp1, Hp2, Hp3, Hp4, Mana1, Mana2, Mana3, Portrait, Nav;
        public static Texture2D bullet, bulletR;

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
            BG_Pause = cm.Load<Texture2D>("Menu/Semi_trans");
            BG_GO = cm.Load<Texture2D>("Menu/GAMEOVER");

            //Game
            Crow = cm.Load<Texture2D>("Game/Animations/Animation");
            RollerSprite = cm.Load<Texture2D>("Game/Animations/RollerSheet");

            //Stage1
            BG_Mont = cm.Load<Texture2D>("Game/Background/Mont");
            Mont2 = cm.Load<Texture2D>("Game/Background/Mont");
            Mont3 = cm.Load<Texture2D>("Game/Background/Mont");
            BG_Ciel = cm.Load<Texture2D>("Game/Background/Ciel jour");
            Ciel2 = cm.Load<Texture2D>("Game/Background/Ciel jour");
            Ciel3 = cm.Load<Texture2D>("Game/Background/Ciel jour");
            Platform = cm.Load<Texture2D>("Game/Elements/sol_test");
            Solbas = cm.Load<Texture2D>("Game/Elements/Solbas");
            Solbas2 = cm.Load<Texture2D>("Game/Elements/Solbas");
            Solbas3 = cm.Load<Texture2D>("Game/Elements/Solbas");
            Solhaut = cm.Load<Texture2D>("Game/Elements/Solhaut");
            Solhaut2 = cm.Load<Texture2D>("Game/Elements/Solhaut");
            Solhaut3 = cm.Load<Texture2D>("Game/Elements/Solhaut");
            PlateFormebas = cm.Load<Texture2D>("Game/Elements/PlateFormebas");
            PlateFormehaut = cm.Load<Texture2D>("Game/Elements/PlateFormehaut");
            PlateFormeMid = cm.Load<Texture2D>("Game/Elements/PlateFormeMid");
            Edge = cm.Load<Texture2D>("Game/Elements/Edge");
            HolePlat = cm.Load<Texture2D>("Game/Elements/sol_test");
            HolePlat2 = cm.Load<Texture2D>("Game/Elements/sol_test");
            DoublePlat = cm.Load<Texture2D>("Game/Elements/DoublePlat");
            Plat2 = cm.Load<Texture2D>("Game/Elements/Plat2");
            Plat3 = cm.Load<Texture2D>("Game/Elements/Plat2");
            Plat4 = cm.Load<Texture2D>("Game/Elements/sol_test");
            PlatMid = cm.Load<Texture2D>("Game/Elements/MidPlat");
            PlatMid2 = cm.Load<Texture2D>("Game/Elements/MidPlat");
            DoublePlat2 = cm.Load<Texture2D>("Game/Elements/DoublePlat");
            DoublePlat3 = cm.Load<Texture2D>("Game/Elements/DoublePlat");
            End = cm.Load<Texture2D>("Game/Elements/End");
            HPB = cm.Load<Texture2D>("Game/Elements/HPB");
            HPB2 = cm.Load<Texture2D>("Game/Elements/HPB");
            ManaB = cm.Load<Texture2D>("Game/Elements/ManaB");
            ManaB2 = cm.Load<Texture2D>("Game/Elements/ManaB");
            ManaB3 = cm.Load<Texture2D>("Game/Elements/ManaB");
            ManaB4 = cm.Load<Texture2D>("Game/Elements/ManaB");
            Pts = cm.Load<Texture2D>("Game/Elements/Point");
            Pts2 = cm.Load<Texture2D>("Game/Elements/Point");
            Pts3 = cm.Load<Texture2D>("Game/Elements/Point");
            Pts4 = cm.Load<Texture2D>("Game/Elements/Point");
            Pts5 = cm.Load<Texture2D>("Game/Elements/Point");

            //Stage2
            //BG = cm.Load<Texture2D>("Game/Background/Mont");
            //Forest = cm.Load<Texture2D>("Game/Background/Mont");
            Rock = cm.Load<Texture2D>("Game/Background/Mont");
            Grass = cm.Load<Texture2D>("Game/Elements/Grassbas");
            Grass2 = cm.Load<Texture2D>("Game/Elements/Grassbas");
            Grass3 = cm.Load<Texture2D>("Game/Elements/Grassbas");
            Grass4 = cm.Load<Texture2D>("Game/Elements/Grassbas");
            Grasshaut = cm.Load<Texture2D>("Game/Elements/Grasshaut");
            Grasshaut2 = cm.Load<Texture2D>("Game/Elements/Grasshaut");
            Grasshaut3 = cm.Load<Texture2D>("Game/Elements/Grasshaut");
            Grasshaut4 = cm.Load<Texture2D>("Game/Elements/Grasshaut");


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
            bullet = cm.Load<Texture2D>("Game/Animations/Bullet");
            bulletR = cm.Load<Texture2D>("Game/Animations/BulletReverse");

            //Musique
            musicMenu = cm.Load<SoundEffect>("Menu/Music/KodoDrum1");
            jump = cm.Load<SoundEffect>("Menu/Music/jump_up");
            landing = cm.Load<SoundEffect>("Menu/Music/land_ground");
            attack1 = cm.Load<SoundEffect>("Menu/Music/voice_girl_attack_4");
            run_ground = cm.Load<SoundEffect>("Menu/Music/run_ground_4");
            gameMusic = cm.Load<SoundEffect>("Menu/Music/gameMusic");
            mouse_enter = cm.Load<SoundEffect>("Menu/Music/mouse_enter");
            voice_dead = cm.Load<SoundEffect>("Menu/Music/voice_dead");
            get_item = cm.Load<SoundEffect>("Menu/Music/get_item");
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
