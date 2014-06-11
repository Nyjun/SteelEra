using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Steel_Era
{
    class Camera
    {
        public Matrix transform;
        Viewport view;
        public static Vector2 centre;
        public static int centreX, centreY;

        public Camera(Viewport newView)
        {
            view = newView;
        }

        public void Update(GameTime gameTime, Rectangle LocPlayer)
        {
            //if (LocPlayer.X * 2 >= Game1.screenWidth) 
            {
                centre = new Vector2(LocPlayer.X, LocPlayer.Y);
                transform = Matrix.CreateScale(new Vector3(1, 1, 0)) *
                    Matrix.CreateTranslation(new Vector3(-centre.X + 630, 0, 0));
                centreX = (int)centre.X;
                centreY = (int)centre.Y;
            }
            /*else
            {
                centre = new Vector2(Game1.screenWidth, Game1.screenHeight);
                transform = Matrix.CreateScale(new Vector3(1, 1, 0)) *
                    Matrix.CreateTranslation(new Vector3(0, 0, 0));
                centreX = (int)centre.X;
                centreY = (int)centre.Y;
            }*/

        }


    }
}
