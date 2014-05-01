using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Steel_Era
{
    class Cursor : Sprite
    {
        MouseState mOSt;
        public Cursor(Texture2D tex, Game1 game)
            : base(tex, game.mouseState.X, game.mouseState.Y)
        {
            Position = new Vector2(x, y);
            Texture = tex;
        }

        public void HandleInput(KeyboardState keyState, MouseState mouseState, Game1 game)
        {
            Position = Position + 1.5f*(new Vector2(mouseState.X, mouseState.Y) - new Vector2(mOSt.X, mOSt.Y));

            //Position = new Vector2(mouseState.X - (Height/2), mouseState.Y - (Width/2));
            mOSt = mouseState;
        }

        
    }
}
