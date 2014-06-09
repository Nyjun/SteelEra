using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Steel_Era
{
    class GameMain
    {
        // Fields
        Player LocalPlayer;

        //Constructors
        public GameMain(Stages.Stage stage)
        {
            this.LocalPlayer = new Player(stage);
        }

        // Methods

        //Update & Draw
        public void Update(MouseState mouse, KeyboardState keyboard)
        {
            LocalPlayer.Update(mouse, keyboard);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            LocalPlayer.Draw(spriteBatch);
        }
    }
}
