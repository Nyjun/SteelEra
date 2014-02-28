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
    class Cursor : Sprite
    {
        public Cursor(Texture2D tex, bool animated, float x, float y)
            : base(tex, animated, x, y)
        {
            Texture = tex;
        }

        public override void HandleInput(KeyboardState keyState, MouseState mouseState)
        {
            Position = new Vector2(mouseState.X - (Height/2), mouseState.Y - (Width/2));
        }

        
    }
}
